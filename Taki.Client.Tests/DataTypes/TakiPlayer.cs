using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taki.Client.Tests
{
    public class TakiPlayer
    {
        private bool _canDropCards;
        
        //TODO: Fire EVENT for UI
        public bool CanDropCards
        {
            get { return _canDropCards; }
            set {
                _canDropCards = value;
                if (_canDropCards == true)
                {
                    if (PlayerCanDropCards != null)
                    {
                        PlayerCanDropCards();
                    }
                }            
            }
        }

        public List<ITakiCard> Cards
        {
            get;
            private set;
        }
        
        #region Events and Delegates for UI

        public delegate void PlayerCanDropCardsDel();
        public event PlayerCanDropCardsDel PlayerCanDropCards;
        
        public delegate void CardAddedDel(ITakiCard theCard);
        public event CardAddedDel CardAdded;

        public delegate void CardRemovedDel(ITakiCard theCard);
        public event CardRemovedDel CardRemoved;
       
        public delegate void PlayerDropCardDel(ITakiCard theCard,TakiPlayer thePlayer);
        public event PlayerDropCardDel PlayerDropCard;

        public delegate void PlayerDropDeniedDel();
        public event PlayerDropDeniedDel PlayerDropDenied;

        public delegate void PlayerCardRequestedDel(TakiPlayer thePlayer);
        public event PlayerCardRequestedDel PlayerCardRequested;

        public delegate void PlayerCanDecideToDoneReceivedDel();
        public event PlayerCanDecideToDoneReceivedDel PlayerCanDecideToDoneReceived;

        public delegate void PlayerDoneTakiTurnDel(TakiPlayer thePlayer);
        public event PlayerDoneTakiTurnDel PlayerDoneTakiTurn;


        #endregion

        public void DropDenied()
        {
            if (PlayerDropDenied != null)
            {
                PlayerDropDenied();
            }
        }
        
        public void PlayerCanDecideToDone()
        {
            if (PlayerCanDecideToDoneReceived != null)
            {
                PlayerCanDecideToDoneReceived();
            }
        }

        public void PlayerCardRequest()
        {
            if (PlayerCardRequested != null)
            {
                PlayerCardRequested(this);
            }
        }


        public void PlayerDoneTheTakiTurn()
        {
            if (PlayerDoneTakiTurn != null)
            {
                PlayerDoneTakiTurn(this);
            }
        }

        public void AddCard(ITakiCard cardToAdd)
        {
            Cards.Add(cardToAdd);

            //fire the event.
            if (CardAdded != null)
            {
                CardAdded(cardToAdd);
            }
        }
     
        public void RemoveCard(ITakiCard cardToRemove)
        {
            if (Cards.Contains(cardToRemove))
            {
                Cards.Remove(cardToRemove);

                //fire the event.
                if (CardRemoved != null)
                {
                    CardRemoved(cardToRemove);
                }
            }
            else
            {
                throw new Exception("Can't remove a card that not in that player hand.");
            }
        }

        public void PlayerTryToDropCard(ITakiCard theCard)
        {
            if (PlayerDropCard != null)
            {
                PlayerDropCard(theCard,this);
            }
            else
            {
                throw new Exception("This request will not reach the target");
            }
        }

        public int CardsLeft
        {
            get { return Cards.Count; }
        }

        public string Name
        {
            get;
            private set;
        }

        public TakiPlayer(string name)
        {
            Cards = new List<ITakiCard>();
            Name = name;
        }
    }
}
