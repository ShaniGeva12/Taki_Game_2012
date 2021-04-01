using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Client.Tests.Enums;
using Taki.Client.Tests.Cards;

namespace Taki.Client.Tests
{
    public static class TakiStore
    {
        private static TakiStoreNonSingleton instance;

        public static TakiStoreNonSingleton Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TakiStoreNonSingleton();
                }
                return instance;
            }
        }
    }
    
    public class TakiStoreNonSingleton
    {
        private int _clonesAtPackge = 2;

        public int  ClonesAtPackge
        {
            get { return _clonesAtPackge; }
            set { _clonesAtPackge = value; }
        }

        #region card groups

        private List<ITakiCard> _allCards;
        private List<ITakiCard> _allSpecialUniversalTakiCards;
        private List<ITakiCard> _allTakiCards;
        private List<ITakiCard> _allNumberCards;
        private List<ITakiCard> _allNumberAndTakiCards;
        
        //Retuns 5 cards (taki at 4 color + masterTaki)
        public List<ITakiCard> GetAllTakiCards()
        {
            if (_allTakiCards == null)
            {
                _allTakiCards = new List<ITakiCard>();

                _allTakiCards.Add(new SpecialTakiCard(CardColors.Blue, SpecialCards.Taki));
                _allTakiCards.Add(new SpecialTakiCard(CardColors.Green, SpecialCards.Taki));
                _allTakiCards.Add(new SpecialTakiCard(CardColors.Red, SpecialCards.Taki));
                _allTakiCards.Add(new SpecialTakiCard(CardColors.Yellow, SpecialCards.Taki));

                _allTakiCards.Add(new SpecialUniversalTakiCard(SpecialUniversalCards.MasterTaki));
            }

            return _allTakiCards;
        }
        
        public List<ITakiCard> GetAllNumberCards()
        {
            if (_allNumberCards == null)
            {
                _allNumberCards = new List<ITakiCard>();

                foreach (var card in GetAllCardsPackage())
                {
                    if (card is NumberTakiCard)
                    {
                        _allNumberCards.Add(card as NumberTakiCard);
                    }
                }
            }

            return _allNumberCards;
        }
        
        public List<ITakiCard> GetAllNumberAndTakiCards()
        {
            if (_allNumberAndTakiCards == null)
            {
                _allNumberAndTakiCards = new List<ITakiCard>();

                _allNumberAndTakiCards.AddRange(GetAllNumberCards());
                _allNumberAndTakiCards.AddRange(GetAllTakiCards());               
            }

            return _allNumberAndTakiCards;
        }

        public List<ITakiCard> GetAllSpecialUniversalTakiCards()
        {
            if (_allSpecialUniversalTakiCards == null)
            {
                _allSpecialUniversalTakiCards = new List<ITakiCard>();
                foreach (var card in _allCards)
                {
                    if (card is SpecialUniversalTakiCard)
                    {
                        _allSpecialUniversalTakiCards.Add(card);
                    }
                }
            }

            return _allSpecialUniversalTakiCards;
        }

        #endregion

        public List<ITakiCard> CanFollow(ITakiCard LowestCard)
        {
            List<ITakiCard> returnValue = new List<ITakiCard>();

            //SpecialUniversalTakiCards can be used at any time
            returnValue.AddRange(GetAllSpecialUniversalTakiCards());

            if (LowestCard == null)
            {
                return GetAllNumberCards();
            }
            else if (LowestCard is SpecialUniversalTakiCard)
            {                
                return GetAllNumberAndTakiCards();
            }
            else if (LowestCard is NumberTakiCard)
            {
                NumberTakiCard theCard = (LowestCard as NumberTakiCard);

                foreach (var card in _allCards)
                {
                    if (card is NumberTakiCard)
                    {
                        NumberTakiCard theOther = card as NumberTakiCard;

                        if (theOther.Number == theCard.Number || theOther.Color == theCard.Color)
                        {
                            returnValue.Add(theOther);
                        }
                    }
                    else if (card is SpecialTakiCard)
                    {
                        SpecialTakiCard theOther = card as SpecialTakiCard;
                        if (theOther.Color == theCard.Color)
                        {
                            returnValue.Add(theOther);
                        }
                    }
                }
            }
            else if (LowestCard is SpecialTakiCard)
            {
                SpecialTakiCard theCard = (LowestCard as SpecialTakiCard);

                foreach (var card in _allCards)
                {
                    if (card is NumberTakiCard)
                    {
                        NumberTakiCard theOther = card as NumberTakiCard;

                        if (theOther.Color == theCard.Color)
                        {
                            returnValue.Add(theOther);
                        }
                    }
                    else if (card is SpecialTakiCard)
                    {
                        SpecialTakiCard theOther = card as SpecialTakiCard;
                        if (theOther.Color == theCard.Color || theOther.Type == theCard.Type)
                        {
                            returnValue.Add(theOther);
                        }
                    }
                }

            }

            return returnValue;
        }

        public int HowManyCardsCanFollow(ITakiCard Card)
        {
            if (Card is NumberTakiCard)
            {
                return 0;
            }
            else if(Card is SpecialTakiCard)
            {
                switch ((Card as SpecialTakiCard).Type)
                {
                    case SpecialCards.Plus: { return 1; };
                    case SpecialCards.TurnSwitch:
                    case SpecialCards.Stop: { return 0; };
                    case SpecialCards.Taki: { return -1; }; 
               
                    default: { return 0; };
                }
            }

            return 0;
        }

        public List<ITakiCard> GetAllCardsPackage()
        {            
            if (_allCards == null)
            {
                _allCards = new List<ITakiCard>();

                var Colors = Enum.GetNames(typeof(CardColors));
                var SpecialCardsArray = Enum.GetNames(typeof(SpecialCards));
                var CardNumbersArray = Enum.GetNames(typeof(CardNumbers));

                var SpecialUniversalCardsArray = Enum.GetNames(typeof(SpecialUniversalCards));


                foreach (var color in Colors)
                {
                    CardColors theColor = (CardColors)(Enum.Parse((typeof(CardColors)), color));
                    
                    foreach (var number in CardNumbersArray)
                    {
                        CardNumbers theNumber = (CardNumbers)(Enum.Parse(typeof(CardNumbers), number));
                                                
                        //each card appears twice
                        for (int i = 0; i < ClonesAtPackge; i++)
                        {
                            NumberTakiCard NewCard = new NumberTakiCard(theColor, theNumber);
                            _allCards.Add(NewCard);
                        }
                    }
               
                    foreach (var special in SpecialCardsArray)
                    {
                         SpecialCards theNumber = (SpecialCards)(Enum.Parse(typeof(SpecialCards), special));                        
                        
                        //each card appears twice
                         for (int i = 0; i < ClonesAtPackge; i++)
                        {
                            SpecialTakiCard NewCard = new SpecialTakiCard(theColor, theNumber);
                            _allCards.Add(NewCard);
                        }
                    }
                }

                foreach (var SpecialUniversalCard in SpecialUniversalCardsArray)
                {
                    SpecialUniversalCards theSpecialUniversalType = (SpecialUniversalCards)(Enum.Parse(typeof(SpecialUniversalCards), SpecialUniversalCard));                        
                    
                    //each card appears twice
                    for (int i = 0; i < ClonesAtPackge; i++)
                    {
                        SpecialUniversalTakiCard NewCard3 = new SpecialUniversalTakiCard(theSpecialUniversalType);
                        _allCards.Add(NewCard3);
                    }
                }
            }

          return _allCards;
        }
       
        public List<ITakiCard> GetShuffledCardsPackage()
        {
            //Shuffle It...
            return ShuffleList<ITakiCard>(GetAllCardsPackage());
        }      

        private List<E> ShuffleList<E>(List<E> inputList)
        {
            List<E> inputListCopy = new List<E>();
            inputListCopy.AddRange(inputList);

            List<E> randomList = new List<E>();

            Random r = new Random();
            int randomIndex = 0;
            while (inputListCopy.Count > 0)
            {
                randomIndex = r.Next(0, inputListCopy.Count); //Choose a random object in the list
                randomList.Add(inputListCopy[randomIndex]); //add it to the new, random list
                inputListCopy.RemoveAt(randomIndex); //remove to avoid duplicates
            }

            return randomList; //return the new random list
        }

    }
}
