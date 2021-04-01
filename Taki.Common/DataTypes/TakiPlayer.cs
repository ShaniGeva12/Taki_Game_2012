using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes.Enums;
using Taki.Common.DataTypes.Cards;
//----------------------------------

namespace Taki.Common.DataTypes
{
    public class TakiPlayer
    {
        #region Properties
      
        private bool _canDropCards { get; set; }

        public bool CanDropCards
        {
            get { return _canDropCards; }
            set
            {
                _canDropCards = value;
                if (_canDropCards == true)
                {
                    if (PlayerCanDropCards != null)
                    {
                        PlayerCanDropCards(this);
                    }
                }
            }
        }

        public List<ITakiCard> Cards
        {
            get;
            private set;
        }

        #endregion
        
        #region Events and Delegates for UI

        public delegate void PlayerCanDropCardsDel(TakiPlayer player);
        public event PlayerCanDropCardsDel PlayerCanDropCards;
        
        public delegate void CardAddedDel(TakiPlayer player,ITakiCard theCard);
        public event CardAddedDel CardAdded;

        public delegate void CardRemovedDel(TakiPlayer player,ITakiCard theCard);
        public event CardRemovedDel CardRemoved;
       
        public delegate void PlayerDropCardDel(ITakiCard theCard,TakiPlayer thePlayer);
        public event PlayerDropCardDel PlayerDropCard;

        public delegate void PlayerDropDeniedDel(TakiPlayer player);
        public event PlayerDropDeniedDel PlayerDropDenied;

        public delegate void PlayerCardRequestedDel(TakiPlayer thePlayer);
        public event PlayerCardRequestedDel PlayerCardRequested;

        public delegate void PlayerCanDecideToDoneReceivedDel(TakiPlayer player);
        public event PlayerCanDecideToDoneReceivedDel PlayerCanDecideToDoneReceived;

        public delegate void PlayerDoneTakiTurnDel(TakiPlayer thePlayer);
        public event PlayerDoneTakiTurnDel PlayerDoneTakiTurn;

        public delegate void ChooseColorRequestDel(TakiPlayer player);
        public event ChooseColorRequestDel ChooseColorRequest;

        public delegate void PlayerSelectColorDel(CardColors color);
        public event PlayerSelectColorDel PlayerSelectColor;

        #endregion

        #region PublicMehtods

        public void RemoveAllCards()
        {
            while (Cards.Count > 0)
            {
                RemoveCard(Cards[0]);              
            }
        }

        public void DropDenied()
        {
            if (PlayerDropDenied != null)
            {
                PlayerDropDenied(this);
            }
        }
        
        public void PlayerCanDecideToDone()
        {
            if (PlayerCanDecideToDoneReceived != null)
            {
                PlayerCanDecideToDoneReceived(this);
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
                CardAdded(this,cardToAdd);
            }
        }
     
        public void RemoveCard(ITakiCard cardToRemove)
        {
            if (Cards.Contains(cardToRemove))
            {
                Cards.Remove(cardToRemove);
              
                if (CardRemoved != null)
                {
                    CardRemoved(this,cardToRemove);
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
            set;
        }
        public TakiPlayer() : this(null) { }


        public TakiPlayer(string name)
        {
            Cards = new List<ITakiCard>();
            Name = name;
        }

        public void ChooseColor()
        {
            if (ChooseColorRequest != null)
            {
                ChooseColorRequest(this);
            }
        }

        public void SendSelectedColor(CardColors color)
        {
            if(PlayerSelectColor!=null)
            {
                PlayerSelectColor(color);
            }
        }

        #endregion
    }
}
