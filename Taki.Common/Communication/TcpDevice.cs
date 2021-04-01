using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Taki.Common.DataTypes;

namespace Taki.Common.Communication
{
    public class TcpDevice
    {
        private NetworkStream mStreamFromServer;

        public delegate void ServerDownDelegate();
        public event ServerDownDelegate ServerDown;

        public delegate void NewMessagedelegate(byte[] Message, MessageTypes Type);
        public event NewMessagedelegate NewMessage;

        public bool IsRunning
        {
            get;
            set;
        }

        private Queue<TcpDeviceEvent> mSendToServerQueue;

        public void SendMessageToServer(TcpDeviceEvent Event)
        {
            lock (mSendToServerQueue)
            {
                if (mSendToServerQueue.Count > 0)
                {
                    if (Event.MessageType != MessageTypes.None)
                    {
                        mSendToServerQueue.Enqueue(Event);
                    }
                }
                else
                {
                    mSendToServerQueue.Enqueue(Event);
                }               
            }
        }

        public TcpDevice(string ServerHostName, int ServerListenPort)
        {
            TcpClient client = new TcpClient();
            client.Connect(ServerHostName, ServerListenPort);

            IsRunning = true;
            mSendToServerQueue = new Queue<TcpDeviceEvent>();

            mStreamFromServer = client.GetStream();


            Thread LiveTask = new Thread(new ParameterizedThreadStart(Live));
            LiveTask.IsBackground = true;
            LiveTask.Start();
        }

        private void Live(object o)
        {
            mStreamFromServer.ReadTimeout = 20000;

            try
            {
                while (IsRunning)
                {
                    int QueueDeep;

                    lock (mSendToServerQueue)
                    {
                        QueueDeep = mSendToServerQueue.Count;
                    }

                    if (QueueDeep == 0)
                    {
                        Thread.Sleep(100);
                    }
                    else
                    {
                        TcpDeviceEvent EventToSend;

                        lock (mSendToServerQueue)
                        {
                            EventToSend = mSendToServerQueue.Dequeue();
                        }

                        byte[] MessageHedaer = new byte[5];
                        byte[] RespondHedaer = new byte[5];

                        #region build the MessageHedaer

                        byte[] DataLengthInBytes = BitConverter.GetBytes(EventToSend.Data.Length);
                        DataLengthInBytes.CopyTo(MessageHedaer, 0);
                        MessageHedaer[4] = EventToSend.ByteMessageType;

                        #endregion

                        byte[] WaitByte = new byte[1];

                        mStreamFromServer.Write(MessageHedaer, 0, MessageHedaer.Length);
                        mStreamFromServer.Flush();


                        //wait for server to prepare     
                        WaitByte = PacketLostHandel.GetDataFroStream(mStreamFromServer, WaitByte.Length);
                        // mStreamFromServer.Read(WaitByte, 0, WaitByte.Length);
                        mStreamFromServer.Flush();


                        //send the event data
                        mStreamFromServer.Write(EventToSend.Data, 0, EventToSend.Data.Length);
                        mStreamFromServer.Flush();
                        
                        //get the RespondHedaer

                        RespondHedaer = PacketLostHandel.GetDataFroStream(mStreamFromServer, RespondHedaer.Length);
                        // mStreamFromServer.Read(RespondHedaer, 0, RespondHedaer.Length);
                        mStreamFromServer.Flush();

                        #region Handel RespondHedaer

                        int Length = BitConverter.ToInt32(RespondHedaer, 0);
                        MessageTypes MessageType = TcpDeviceEvent.GetTypeFromByte(RespondHedaer[4]);
                        byte[] ServerRespond = new byte[Length];

                        #endregion

                        //wait for server to prepare 
                        mStreamFromServer.Write(WaitByte, 0, WaitByte.Length);
                        mStreamFromServer.Flush();

                        //get the RespondHedaer
                        mStreamFromServer.Read(ServerRespond, 0, ServerRespond.Length);
                        mStreamFromServer.Flush();

                        if (NewMessage != null)
                        {
                            //New !!!
                            if (MessageType != MessageTypes.None)
                            {
                                NewMessage.BeginInvoke(ServerRespond, MessageType, null, null);

                                if (mSendToServerQueue.Count == 0)
                                {
                                    mSendToServerQueue.Enqueue(new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.None));
                                }
                            }
                        }
                    }
                }
            }
            catch
            {
                if (ServerDown != null)
                {
                    ServerDown();
                }
            }
        }
    }

}
