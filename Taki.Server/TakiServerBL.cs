using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.Communication;
using System.Net.Sockets;
using Taki.Common.DataTypes;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using Taki.Common.DataTypes.Cards;

namespace Taki.Server
{
    public class TakiServerBL
    {
        #region Proprties

        private TcpServerDevice _tcpServerDevice { get; set; }

        private List<Socket> _allPlayers { get; set; }

        private TakiGame _game { get; set; }

        public bool GameStarted { get; set; }

        private Dictionary<Socket, TakiPlayer> _socketToPlayer { get; set; }

        private BinaryFormatter formatter { get; set; }

        #endregion

        #region Ctor

        public TakiServerBL(TcpServerDevice tcpServerDevice)
        {
            formatter = new BinaryFormatter();

            _allPlayers = new List<Socket>();
            _socketToPlayer = new Dictionary<Socket, TakiPlayer>();

            GameStarted = false;

            _tcpServerDevice = tcpServerDevice;          

            _tcpServerDevice.NewClientUp += new TcpServerDevice.NewClientUpDelegate(_tcpServerDevice_NewClientUp);
            _tcpServerDevice.ClientDown += new TcpServerDevice.ClientDownDelegate(_tcpServerDevice_ClientDown);
            _tcpServerDevice.NewMessage += new TcpServerDevice.NewMessagedelegate(_tcpServerDevice_NewMessage);

            _game = new TakiGame();

            _game.TopCardChanged += new TakiGame.TopCardChangedDel(_game_TopCardChanged);

            _game.Winner += new TakiGame.WinnerDel(_game_Winner);
        }

        #endregion

        void _game_Winner(TakiPlayer player)
        {
            Socket winnerSocket = GetSocketByPlayer(player);
            _tcpServerDevice.SendMessageToClient(winnerSocket, new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.YouWinMessage));
         
            foreach (Socket socket in _allPlayers)
            {
                if (socket != winnerSocket)
                {
                    _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(System.Text.UnicodeEncoding.Unicode.GetBytes(player.Name), MessageTypes.WinnerName));
                }
            }
        }      

        void _tcpServerDevice_ClientDown(Socket socket)
        {
            if (_allPlayers.Contains(socket))
            {
                TakiPlayer playerToRemove = _socketToPlayer[socket];

                _allPlayers.Remove(socket);
                _socketToPlayer.Remove(socket);
               
                try
                {
                    _game.RemovePlayer(playerToRemove);
                }
                catch
                { 
                //Last player left the game !
                }
            }
        }

        void _tcpServerDevice_NewClientUp(Socket socket)
        {
            if (!GameStarted)
            {
                _allPlayers.Add(socket);
                _socketToPlayer.Add(socket, null);
            }
        }

        //new Requests from clients 
        void _tcpServerDevice_NewMessage(System.Net.Sockets.Socket socket, byte[] Message, Common.DataTypes.MessageTypes Type)
        {
            switch (Type)
            {
                case MessageTypes.PlayerName: { 
                    string playerName = System.Text.UnicodeEncoding.Unicode.GetString(Message);

                    if (!GameStarted)
                    {
                        TakiPlayer newPlayer = new TakiPlayer(playerName);
                        newPlayer.CardAdded += new TakiPlayer.CardAddedDel(newPlayer_CardAdded);
                        newPlayer.PlayerCanDropCards += new TakiPlayer.PlayerCanDropCardsDel(newPlayer_PlayerCanDropCards);

                        newPlayer.PlayerDropDenied += new TakiPlayer.PlayerDropDeniedDel(newPlayer_PlayerDropDenied);
                        newPlayer.CardRemoved += new TakiPlayer.CardRemovedDel(newPlayer_CardRemoved);

                        newPlayer.PlayerCanDecideToDoneReceived += new TakiPlayer.PlayerCanDecideToDoneReceivedDel(newPlayer_PlayerCanDecideToDoneReceived);
                        newPlayer.ChooseColorRequest += new TakiPlayer.ChooseColorRequestDel(newPlayer_ChooseColorRequest);

                        _game.AddNewPlayer(newPlayer);
                        _socketToPlayer[socket] = newPlayer;
                    }
                    else
                    {
                        _tcpServerDevice.SendMessageToClient(socket,new TcpDeviceEvent(new byte[] {0x01},MessageTypes.NewPlayerRejected));
                        
                    //notif the player that the game started...
                    }


                } break;


                case MessageTypes.CardMessage:
                    {
                        MemoryStream theCardMemoryStream = new MemoryStream(Message);
                        object theCardAsObject = formatter.Deserialize(theCardMemoryStream);


                        _socketToPlayer[socket].PlayerTryToDropCard(theCardAsObject as Taki.Common.DataTypes.Cards.ITakiCard);
                        
                    } break;
                case MessageTypes.NewCardRequest:
                    {
                        _game.newPlayer_PlayerCardRequested(_socketToPlayer[socket]);
                    } break;
                case MessageTypes.SelectedColorByUser:
                    {
                        _game.newPlayer_PlayerSelectColor((Taki.Common.DataTypes.Enums.CardColors)BitConverter.ToInt32(Message, 0));
                    } break;
                case MessageTypes.PlayerDoneTheTakiTurn:
                    {
                        _socketToPlayer[socket].PlayerDoneTheTakiTurn();
              
                    } break;


            }
        }

        void newPlayer_ChooseColorRequest(TakiPlayer player)
        {
            _tcpServerDevice.SendMessageToClient(GetSocketByPlayer(player), new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.ChooseColorRequest));
        }

        void newPlayer_PlayerCanDecideToDoneReceived(TakiPlayer player)
        {
            _tcpServerDevice.SendMessageToClient(GetSocketByPlayer(player), new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.PlayerCanDecideToDoneReceived));
      
        }

        void _game_TopCardChanged(Common.DataTypes.Cards.ITakiCard theCard)
        {
            foreach (Socket socket in _allPlayers)
            {
                MemoryStream theCardMemoryStream = new MemoryStream();

                formatter.Serialize(theCardMemoryStream, theCard);

                _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(theCardMemoryStream.GetBuffer(), MessageTypes.TopCard));

                if (_game.CurrentPlayer != null)
                {
                    _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(System.Text.UnicodeEncoding.Unicode.GetBytes(_game.CurrentPlayer.Name), MessageTypes.LastPlayerName));
                }
            }
        }

        void newPlayer_CardRemoved(TakiPlayer player, Common.DataTypes.Cards.ITakiCard theCard)
        {

            Socket socket = GetSocketByPlayer(player);

            MemoryStream theCardMemoryStream = new MemoryStream();

            formatter.Serialize(theCardMemoryStream, theCard);

            _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(theCardMemoryStream.GetBuffer(), MessageTypes.CardRemoveMessage));      


        }

        void newPlayer_PlayerDropDenied(TakiPlayer player)
        {
            Socket socket = GetSocketByPlayer(player);
            _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.DropDenied));
            _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(new byte[] { 0x01 }, MessageTypes.PlayerCanDropCards));
        }

        private Socket GetSocketByPlayer(TakiPlayer player)
        {
            foreach (var item in _socketToPlayer)
            {
                if (item.Value == player)
                {
                    return item.Key;
                }
            }

            return null;
        }

        void newPlayer_PlayerCanDropCards(TakiPlayer player)
        {
            Socket socket = GetSocketByPlayer(player);
            _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(new byte[] {0x01}, MessageTypes.PlayerCanDropCards));





            MemoryStream theTableStatusMemoryStream = new MemoryStream();
            formatter.Serialize(theTableStatusMemoryStream, _game.GetTableStatus());

            foreach (var socket1 in _allPlayers)
            {
                //TODO: update all players about the table status !
                _tcpServerDevice.SendMessageToClient(socket1, new TcpDeviceEvent(theTableStatusMemoryStream.GetBuffer(), MessageTypes.TableStatus));
            }


        }

        void newPlayer_CardAdded(TakiPlayer player, Common.DataTypes.Cards.ITakiCard theCard)
        {
            Socket socket = GetSocketByPlayer(player);

            MemoryStream theCardMemoryStream = new MemoryStream();

            formatter.Serialize(theCardMemoryStream, theCard);

            _tcpServerDevice.SendMessageToClient(socket, new TcpDeviceEvent(theCardMemoryStream.GetBuffer(), MessageTypes.CardMessage));

        }
        
        public void StartGame()
        {
            GameStarted = true;

            _game.SplitCardsToPlayers(8);
            _game.StartGame();

            /*
            foreach (Socket player in _allPlayers)
            { 
                _tcpServerDevice.SendMessageToClient(player,
                }*/
        }

        private TakiPlayer SearchPlayer(string Name)
        {
            foreach (var item in _socketToPlayer)
            {
                if (item.Value.Name.ToLower() == Name)
                {
                    return item.Value;
                }
            }
            return null;
        }

        public bool CombinaToPlayer(string playerName)
        {
            TakiPlayer PlayerForCombina = SearchPlayer(playerName);
            if (PlayerForCombina != null)
            {
                _game.AddSpecificCardToPlayer(new SpecialUniversalTakiCard(Common.DataTypes.Enums.SpecialUniversalCards.MasterTaki), PlayerForCombina);
                _game.AddSpecificCardToPlayer(new SpecialUniversalTakiCard(Common.DataTypes.Enums.SpecialUniversalCards.MasterTaki),PlayerForCombina);
    
                return true;
            }
            return false;

        }
    
    }
}
