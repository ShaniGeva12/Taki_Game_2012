using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes.Enums;
using Taki.Common.DataTypes.Cards;


namespace Taki.Common.DataTypes
{
    public class TakiGame
    {
        #region Events

        public delegate void TopCardChangedDel(ITakiCard newCard);
        public event TopCardChangedDel TopCardChanged;

        public delegate void WinnerDel(TakiPlayer player);
        public event WinnerDel Winner;

        #endregion

        #region current top card

        private ITakiCard _currentTopCard;

        public ITakiCard CurrentTopCard
        {
            get { return _currentTopCard; }
            set
            {
                _currentTopCard = value;

                if (TopCardChanged != null)
                {
                    TopCardChanged(value);
                }

            }
        }

        #endregion

        #region Properties

        private List<TakiPlayer> Players;

        private List<ITakiCard> JackPot;

        private bool _isTakiSession;

        public int CardLeftAtJackPot
        {
            get { return JackPot.Count; }
        }

        #endregion

        #region current player

        private TakiPlayer _currentPlayer;

        public TakiPlayer CurrentPlayer
        {
            get { return _currentPlayer; }
            set
            {
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

        #region HandelPlayerEvents

        public void newPlayer_PlayerSelectColor(CardColors color)
        {
            //TODO: Check !!
            CurrentTopCard = new SpecialTakiCard(color, SpecialCards.Taki);
            NextTurn();
        }

        void newPlayer_PlayerDoneTakiTurn(TakiPlayer thePlayer)
        {
            _isTakiSession = false;
            NextTurn();
        }

        public void newPlayer_PlayerCardRequested(TakiPlayer thePlayer)
        {
            thePlayer.AddCard(GetNewCardFromJackPot());
            NextTurn();
        }


        //For Cheats use ONLY!!!
        public void AddSpecificCardToPlayer(ITakiCard theCard, TakiPlayer player)
        {
            player.AddCard(theCard);
        }

        public void RemovePlayer(TakiPlayer playerToRemove)
        {
            Players.Remove(playerToRemove);

            if (CurrentPlayer == playerToRemove)
            {
                NextTurn();
            }
        }

        #endregion

        #region Ctor

        public TakiGame()
        {
            JackPot = TakiStore.Instance.GetShuffledCardsPackage(1);

            Players = new List<TakiPlayer>();
        }

        #endregion

        #region PublicMethods

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

        public void AddNewPlayer(TakiPlayer newPlayer)
        {
            newPlayer.PlayerDropCard += new TakiPlayer.PlayerDropCardDel(PlayerDropCard);
            newPlayer.PlayerCardRequested += new TakiPlayer.PlayerCardRequestedDel(newPlayer_PlayerCardRequested);
            newPlayer.PlayerDoneTakiTurn += new TakiPlayer.PlayerDoneTakiTurnDel(newPlayer_PlayerDoneTakiTurn);
            newPlayer.PlayerSelectColor += new TakiPlayer.PlayerSelectColorDel(newPlayer_PlayerSelectColor);

            Players.Add(newPlayer);

            //add full taki package for each player
            JackPot.AddRange(TakiStore.Instance.GetShuffledCardsPackage(1));
        }

        public TableStatus GetTableStatus()
        {
            if (CurrentPlayer != null)
            {
                return new TableStatus(Players, CurrentPlayer.Name);
            }
            return new TableStatus(Players, "None");
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
            return GetNewCardFromJackPot(TakiStore.Instance.GetAllCardsPackage(1));
        }

        #endregion

        #region PrivateMethods

        private TakiPlayer GetNextPlayer()
        {
            int index = Players.IndexOf(CurrentPlayer);

            if (index + 1 <= Players.Count - 1)
            {
                return Players[index + 1];
            }
            return Players[0];
        }

        private void PlayerDropCard(ITakiCard theCard, TakiPlayer thePlayer)
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
                                _isTakiSession = false;
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
                                thePlayer.ChooseColor();
                            } break;
                        case SpecialUniversalCards.MasterTaki:
                            {
                                thePlayer.ChooseColor();
                                CurrentPlayer = thePlayer;
                                thePlayer.PlayerCanDecideToDone();
                                _isTakiSession = true;
                            } break;
                        case SpecialUniversalCards.Shifter:
                            {
                                List<List<ITakiCard>> playersHands = new List<List<ITakiCard>>();

                                foreach (var player in Players)
                                {
                                    playersHands.Add(new List<ITakiCard>(player.Cards));

                                    player.RemoveAllCards();
                                }

                                for (int i = 0; i < Players.Count - 1; i++)
                                {
                                    foreach (var card in playersHands[i])
                                    {
                                        Players[i + 1].AddCard(card);
                                    }
                                }

                                foreach (var card in playersHands[Players.Count - 1])
                                {
                                    Players[0].AddCard(card);
                                }

                                NextTurn();

                            } break;
                    }
                }
            }
            else
            {
                thePlayer.DropDenied();

                if (_isTakiSession)
                {
                    thePlayer.PlayerCanDecideToDone();
                }
            }

            if (thePlayer.CardsLeft == 0)
            {
                if (!Taki.Common.DataTypes.TakiStore.Instance.GetAllPlusCards().Contains(CurrentTopCard))
                {
                    if (Winner != null)
                    {
                        Winner(thePlayer);
                        //TODO : close the game and bla bla...
                    }
                }
            }
        }

        private void MovedCurrentTurn(int jumps)
        {
            //for singal player mode !
            if (Players.Count == 1)
            {
                CurrentPlayer = Players[0];
            }
            else
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
            else
            {
                //let the player keep drop cards
                CurrentPlayer = CurrentPlayer;
                //player can done his turn
                CurrentPlayer.PlayerCanDecideToDone();
            }
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

        #endregion
    }
}
