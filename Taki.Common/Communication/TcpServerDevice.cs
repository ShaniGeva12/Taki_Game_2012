using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using Taki.Common.DataTypes;
using System.IO;
using System.Net;

namespace Taki.Common.Communication
{
    public class TcpServerDevice
    {
        public int ServerOpenPort
        {
            get;
            set;
        }

        private TcpListener mTcpServer;

        private Dictionary<Socket, Queue<TcpDeviceEvent>> mDataForClients;

        public void SendMessageToClient(Socket ClientSocket, TcpDeviceEvent Message)
        {
            lock (mDataForClients)
            {
                if (mDataForClients.ContainsKey(ClientSocket))
                {
                    mDataForClients[ClientSocket].Enqueue(Message);
                }
                else
                {
                    throw new Exception("this user not contains the this server !");
                }
            }
        }

        public int ClientCount
        {
            get;
            private set;
        }

        private bool IsRunning;

        public delegate void ClientDownDelegate(Socket socket);
        public event ClientDownDelegate ClientDown;

        public delegate void NewClientUpDelegate(Socket socket);
        public event NewClientUpDelegate NewClientUp;

        public delegate void NewMessagedelegate(Socket socket, byte[] Message, MessageTypes Type);
        public event NewMessagedelegate NewMessage;

        public TcpServerDevice(int ListenForNewConnctionsPort)
        {
            ServerOpenPort = ListenForNewConnctionsPort;

            IsRunning = true;
            ClientCount = 0;

            mDataForClients = new Dictionary<Socket, Queue<TcpDeviceEvent>>();
            IPAddress localAddr = IPAddress.Parse("127.0.0.1");

            mTcpServer = new TcpListener(localAddr, ListenForNewConnctionsPort);
            mTcpServer.Start();

            Thread GetClientsTask = new Thread(new ParameterizedThreadStart(GetClients));
            GetClientsTask.IsBackground = true;
            GetClientsTask.Start();
        }

        public void Close()
        {
            lock (mDataForClients)
            {
                foreach (var Client in mDataForClients)
                {
                    if (ClientDown != null)
                    {
                        Client.Key.Close();
                        ClientDown(Client.Key);
                    }
                }
            }
            IsRunning = false;
            mTcpServer.Stop();

        }

        public bool IsMyClient(Socket ClientToCheck)
        {
            lock (mDataForClients)
            {
                return mDataForClients.ContainsKey(ClientToCheck);
            }
        }


        private void GetClients(object o)
        {
            while (IsRunning)
            {
                try
                {
                    Socket NewUserSocket = mTcpServer.AcceptSocket();

                    Thread HandelClientTask = new Thread(new ParameterizedThreadStart(HandelClient));
                    HandelClientTask.IsBackground = true;
                    HandelClientTask.Start(NewUserSocket);

                    ClientCount++;
                }
                catch
                {
                    Thread.Sleep(200);
                }
            }
        }

        private void HandelClient(object SocketFromClientObject)
        {
            Socket SocketFromClient = SocketFromClientObject as Socket;

            SocketFromClient.NoDelay = false;

            lock (mDataForClients)
            {
                mDataForClients.Add(SocketFromClient, new Queue<TcpDeviceEvent>());
            }

            byte[] EmptyByte = new byte[] { 1 };

            try
            {
                if (NewClientUp != null)
                {
                    NewClientUp(SocketFromClient);
                }

                while (IsRunning)
                {

                    int ReceivedBufferSize;


                    byte[] MessageHedaer = new byte[5];
                    byte[] RespondHedaer = new byte[5];



                    MessageHedaer = PacketLostHandel.GetDataFromSocket(SocketFromClient, MessageHedaer.Length);
                    /*  SocketFromClient.ReceiveBufferSize = MessageHedaer.Length;
               ReceivedBufferSize =  SocketFromClient.Receive(MessageHedaer);*/




                    #region Handel the MessageHedaer

                    int Length = BitConverter.ToInt32(MessageHedaer, 0);
                    MessageTypes MessgeType = TcpDeviceEvent.GetTypeFromByte(MessageHedaer[4]);

                    if (MessgeType == MessageTypes.ERROR)
                    {
                        SocketFromClient.Close();
                        throw new Exception("Error in data");
                    }
                    #endregion

                    //send a approval the get more data
                    SocketFromClient.SendBufferSize = EmptyByte.Length;
                    SocketFromClient.Send(EmptyByte);

                    byte[] Data = new byte[Length];


                    Data = PacketLostHandel.GetDataFromSocket(SocketFromClient, Length);
                    /*SocketFromClient.ReceiveBufferSize = Length;
                        ReceivedBufferSize = SocketFromClient.Receive(Data);*/


                    //handel this data
                    if (NewMessage != null)
                    {
                        NewMessage(SocketFromClient, Data, MessgeType);
                    }

                    TcpDeviceEvent eventToSend = null;

                    lock (mDataForClients)
                    {
                        if (mDataForClients[SocketFromClient].Count > 0)
                        {
                            eventToSend = mDataForClients[SocketFromClient].Dequeue();
                        }
                    }

                    if (eventToSend == null)
                    {
                        eventToSend = new TcpDeviceEvent(EmptyByte, MessageTypes.None);
                    }

                    #region build the RespondHedaer
                    byte[] DataLengthInBytes = BitConverter.GetBytes(eventToSend.Data.Length);
                    DataLengthInBytes.CopyTo(RespondHedaer, 0);
                    RespondHedaer[4] = eventToSend.ByteMessageType;
                    #endregion

                    //send the haeder
                    SocketFromClient.SendBufferSize = RespondHedaer.Length; ;
                    SocketFromClient.Send(RespondHedaer);

                    //wait for client to prepare 


                    EmptyByte = PacketLostHandel.GetDataFromSocket(SocketFromClient, EmptyByte.Length);

                    /*  SocketFromClient.ReceiveBufferSize = EmptyByte.Length;
                 ReceivedBufferSize =  SocketFromClient.Receive(EmptyByte);*/



                    //send the ServerRespond
                    SocketFromClient.SendBufferSize = eventToSend.Data.Length; ;
                    SocketFromClient.Send(eventToSend.Data);
                }
            }
            catch (Exception ex)
            {
                if (ClientDown != null)
                {
                    ClientDown(SocketFromClient);
                }
            }
        }
    }

}
