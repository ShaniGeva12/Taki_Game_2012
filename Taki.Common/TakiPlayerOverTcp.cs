using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes;
using Taki.Common.Communication;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Threading;
using Taki.Common.DataTypes.Cards;


namespace Taki.Common
{
    public class TakiPlayerOverTcp
    {
        #region Properties

        public TakiPlayer InnerTakiPlayer { get; set; }

        private TcpDevice _tcpDevice { get; set; }

        private BinaryFormatter formatter { get; set; }

        #endregion

        #region Ctor

        public TakiPlayerOverTcp(TakiPlayer takiPlayer, TcpDevice tcpDevice)
        {
            formatter = new BinaryFormatter();

            InnerTakiPlayer = takiPlayer;
            _tcpDevice = tcpDevice;

            _tcpDevice.NewMessage += new TcpDevice.NewMessagedelegate(_tcpDevice_NewMessage);

            _tcpDevice.SendMessageToServer(new TcpDeviceEvent(System.Text.UnicodeEncoding.Unicode.GetBytes(takiPlayer.Name), MessageTypes.PlayerName));
          
            _tcpDevice.ServerDown += new TcpDevice.ServerDownDelegate(NotifAboutServerDown);

            Thread ReviveConnectionThread = new Thread(new ParameterizedThreadStart(ReviveConnection));
            ReviveConnectionThread.IsBackground = true;
            ReviveConnectionThread.Start();        
        }

        #endregion

        public void ReviveConnection(object none)
        {
            while (true)
            {
                Thread.Sleep(1500);
                _tcpDevice.SendMessageToServer(new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.None));
            }        
        }

        #region Delegate&Events

        public delegate void OpenColorPickerDialogDel();
        public event OpenColorPickerDialogDel OpenColorPickerDialog;
       
        public delegate void EnableCloseTakiButtonDel();
        public event EnableCloseTakiButtonDel EnableCloseTakiButton;
        
        public delegate void LastPlayerNameChangedDel(string name);
        public event LastPlayerNameChangedDel LastPlayerNameChanged;

        public delegate void NewTopCardDel(ITakiCard theCard);
        public event NewTopCardDel NewTopCard;
    
        public delegate void NewTableSatusDel(TableStatus status);
        public event NewTableSatusDel NewTableSatus;

        public delegate void WinnerNameDel(string name);
        public event WinnerNameDel Winner;
       
        public delegate void YouWonDel();
        public event YouWonDel YouWon;

        public delegate void YouRejectedDel();
        public event YouRejectedDel YouRejected;
        
        public delegate void ServerDownDel();
        public event ServerDownDel ServerDown;

        #endregion

        private void NotifAboutServerDown()
        {
            if (ServerDown != null)
            {
                ServerDown();
            }
        }

        public void SendCardToServer(ITakiCard theCard)
        { 
            
            MemoryStream theCardMemoryStream = new MemoryStream();

            formatter.Serialize(theCardMemoryStream, theCard);

            _tcpDevice.SendMessageToServer(new TcpDeviceEvent(theCardMemoryStream.GetBuffer(), MessageTypes.CardMessage));

        }

        void _tcpDevice_NewMessage(byte[] Message, MessageTypes Type)
        {
            System.Diagnostics.Trace.WriteLine(Type.ToString());
            switch (Type)
            {
                case MessageTypes.CardMessage:
                    {
                        MemoryStream theCardMemoryStream = new MemoryStream(Message);
                        object theCardAsObject = formatter.Deserialize(theCardMemoryStream);

                        InnerTakiPlayer.AddCard(theCardAsObject as ITakiCard);

                    } break;
                case MessageTypes.CardRemoveMessage:
                    {
                        MemoryStream theCardMemoryStream = new MemoryStream(Message);
                        object theCardAsObject = formatter.Deserialize(theCardMemoryStream);

                        InnerTakiPlayer.RemoveCard(theCardAsObject as ITakiCard);

                    } break;
                case MessageTypes.TopCard:
                    {
                        MemoryStream theCardMemoryStream = new MemoryStream(Message);
                        object theCardAsObject = formatter.Deserialize(theCardMemoryStream);

                        if (NewTopCard != null)
                        {
                            NewTopCard(theCardAsObject as ITakiCard);
                        }

                    } break;
                case MessageTypes.TableStatus:
                    {
                        MemoryStream theTableStatusMemoryStream = new MemoryStream(Message);
                        object TableStatusAsObject = formatter.Deserialize(theTableStatusMemoryStream);

                        if (NewTableSatus != null)
                        {
                            NewTableSatus(TableStatusAsObject as TableStatus);
                        }

                    } break;
                case MessageTypes.PlayerCanDropCards:
                    {
                        InnerTakiPlayer.CanDropCards = true;
                    } break;

                case MessageTypes.DropDenied:
                    {
                        InnerTakiPlayer.DropDenied();
                    } break;
                case MessageTypes.ChooseColorRequest:
                    {
                        if (OpenColorPickerDialog != null)
                        {
                            OpenColorPickerDialog();
                        }
                    } break;
                case MessageTypes.PlayerCanDecideToDoneReceived:
                    {
                        if (EnableCloseTakiButton != null)
                        {
                            EnableCloseTakiButton();
                        }

                    } break;

                case MessageTypes.LastPlayerName:
                    {
                        string LastPlayerName = System.Text.UnicodeEncoding.Unicode.GetString(Message);

                        if (LastPlayerNameChanged != null)
                        {
                            LastPlayerNameChanged(LastPlayerName);
                        }

                    } break;
                case MessageTypes.WinnerName:
                    {
                        string WinnerName = System.Text.UnicodeEncoding.Unicode.GetString(Message);

                        if (Winner != null)
                        {
                            Winner(WinnerName);
                        }
                    } break;
                case MessageTypes.YouWinMessage:
                    {
                        if(YouWon!=null)
                        {
                            YouWon();
                        }

                    } break;
                case MessageTypes.NewPlayerRejected:
                    {
                        if (YouRejected != null)
                        {
                            YouRejected();
                        }

                    } break;
            }
        }

        public void RequestNewCardFromServer()
        {
            _tcpDevice.SendMessageToServer(new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.NewCardRequest));
        }

        public void SendSelectedColor(DataTypes.Enums.CardColors cardColors)
        {            
            _tcpDevice.SendMessageToServer(new TcpDeviceEvent(BitConverter.GetBytes((Int32)cardColors), MessageTypes.SelectedColorByUser));
        }

        public void PlayerDoneTheTakiTurn()
        {
            _tcpDevice.SendMessageToServer(new TcpDeviceEvent(new byte[] {0x01}, MessageTypes.PlayerDoneTheTakiTurn));
       
        }
    }
}
