using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Client.Tests.Cards;
using Taki.Client.Tests.Enums;

namespace Taki.Client.Tests
{
    public class TakiGame
    {
        #region Events 

        public delegate void TopCardChangedDel(ITakiCard newCard);
        public event TopCardChangedDel TopCardChanged;

        #endregion

        #region current top card

        private ITakiCard _currentTopCard;

        public ITakiCard CurrentTopCard
        {
            get { return _currentTopCard; }
            set {
                _currentTopCard = value;

                if (TopCardChanged != null)
                {
                    TopCardChanged(value);
                }
                
                }
        }

        #endregion

        private List<TakiPlayer> Players;

        private List<ITakiCard> JackPot;

        private bool _isTakiSession;
        
        #region current player

        private TakiPlayer _currentPlayer;

        private TakiPlayer CurrentPlayer
        {
            get { return _currentPlayer;}
            set {
                //if it's the first init...
                if (_currentPlayer != null)
                {
                    _currentPlayer.CanDropCards = false;
                }
                _currentPlayer = value;
                _currentPlayer.CanDropCards = true;
            }   
        }

        #endregion

        public void StartGame()
        {
            if (CurrentTopCard == null)
            {
             CurrentTopCard = GetNewCardFromJackPot(TakiStore.Instance.GetAllNumberCards());

                if (Players.Count > 0)
                {
                    CurrentPlayer = Players[0];
                }
                else
                {
                    throw new Exception("No players At This Game.");
                }
            }
            else
            {
                throw new Exception("This Games Already started");
            }
        }

        public int CardLeftAtJackPot
        {
            get { return JackPot.Count; }
        }
        
        public TakiGame()
        {
            JackPot = TakiStore.Instance.GetShuffledCardsPackage();

            Players = new List<TakiPlayer>();
           // JackPot = new List<ITakiCard>();
        }

        public void AddNewPlayer(TakiPlayer newPlayer)
        {
            newPlayer.PlayerDropCard += new TakiPlayer.PlayerDropCardDel(PlayerDropCard);
            newPlayer.PlayerCardRequested += new TakiPlayer.PlayerCardRequestedDel(newPlayer_PlayerCardRequested);
            newPlayer.PlayerDoneTakiTurn += new TakiPlayer.PlayerDoneTakiTurnDel(newPlayer_PlayerDoneTakiTurn);
            Players.Add(newPlayer);
        }

        void newPlayer_PlayerDoneTakiTurn(TakiPlayer thePlayer)
        {
            _isTakiSession = false;
            NextTurn();
        }

        private void newPlayer_PlayerCardRequested(TakiPlayer thePlayer)
        {
            thePlayer.AddCard(GetNewCardFromJackPot());
            NextTurn();
        }

        private TakiPlayer GetNextPlayer()
        {
            int index = Players.IndexOf(CurrentPlayer);

            if (index + 1 <= Players.Count - 1)
            {
                return Players[index + 1];
            }
            return Players[0];
        }


        void PlayerDropCard(ITakiCard theCard,TakiPlayer thePlayer)
        {         
            if (TakiStore.Instance.CanFollow(CurrentTopCard).Contains(theCard)) //if can drop this card
            {                  
                thePlayer.RemoveCard(theCard);
                CurrentTopCard = theCard;

                if (CurrentTopCard is NumberTakiCard)
                {
                    //TODO: Check for past special (like open taki)
                    
                    NextTurn();
                }
                //check for specials...
                else if (CurrentTopCard is SpecialTakiCard)
                {
                    SpecialTakiCard CurrentSpecialCard = CurrentTopCard as SpecialTakiCard;
                    switch (CurrentSpecialCard.Type)
                    {
                        case SpecialCards.Plus:
                            {
                                //player can keep drop cards
                                CurrentPlayer = thePlayer;
                            } break;
                        case SpecialCards.Plus2:
                            {//Not the real behavior
                                GetNextPlayer().AddCard(GetNewCardFromJackPot());
                                GetNextPlayer().AddCard(GetNewCardFromJackPot());
                                JumpOneTurn();
                            } break;
                        case SpecialCards.Stop:
                            {
                                JumpOneTurn();
                            } break;
                        case SpecialCards.Taki:
                            {
                                //player can keep drop cards
                                CurrentPlayer = thePlayer;
                                //player can done his turn
                                thePlayer.PlayerCanDecideToDone();
                                _isTakiSession = true;
                            } break;
                        case SpecialCards.TurnSwitch:
                            {
                                Players.Reverse();
                                NextTurn();
                            } break;
                    }
                }
                else if (CurrentTopCard is SpecialUniversalTakiCard)
                {
                    SpecialUniversalTakiCard CurrentSpecialCard = CurrentTopCard as SpecialUniversalTakiCard;
                    switch (CurrentSpecialCard.Type)
                    {
                        case SpecialUniversalCards.ColorPicker:
                            {
                                NextTurn();
                            } break;
                        case SpecialUniversalCards.MasterTaki:
                            {
                                NextTurn();
                            } break;
                        case SpecialUniversalCards.Shifter:
                            {
                                //TODO !
                            } break;
                    }
                }             
            }
            else
            {
                thePlayer.DropDenied();
            }
        }


        private void MovedCurrentTurn(int jumps)
        {
            int index = Players.IndexOf(CurrentPlayer);
            if (index + jumps <= Players.Count - 1)
            {
                CurrentPlayer = Players[index + jumps];
            }
            else
            {
                CurrentPlayer = Players[index + jumps - Players.Count];
            }
        }

        private void JumpOneTurn()
        {
            MovedCurrentTurn(2);
        }

        private void NextTurn()
        {
            if (!_isTakiSession)
            {
                MovedCurrentTurn(1);
            }
        }

        public void SplitCardsToPlayers(int HowMany)
        {
            for (int i = 0; i < HowMany; i++)
            {
                foreach (var player in Players)
                {
                    player.AddCard(GetNewCardFromJackPot());
                }
            }
        }

        
        public ITakiCard GetNewCardFromJackPot()
        {
            return GetNewCardFromJackPot(TakiStore.Instance.GetAllCardsPackage());
        }

        private ITakiCard GetNewCardFromJackPot(List<ITakiCard> fromThisList)
        {
            ITakiCard returnedCard = null;
            
            foreach (var cardAtJackPot in JackPot)
            {
                if (fromThisList.Contains(cardAtJackPot))
                {
                    returnedCard = cardAtJackPot;
                    break;
                }
            }

            if (returnedCard != null)
            {
                JackPot.Remove(returnedCard);
                return returnedCard;
            }

            throw new Exception("No More Cards At this JackPot.");
        }


        private void PlayerTryToDropCard(TakiPlayer player, ITakiCard theCard)
        {
            if (TakiStore.Instance.CanFollow(CurrentTopCard).Contains(theCard))
            {
                //operation succsses

                player.RemoveCard(theCard);

                //fire EVENT HERE !
                CurrentTopCard = theCard;
            }
            else
            {
                //faild !
            }
        }
    }
}
