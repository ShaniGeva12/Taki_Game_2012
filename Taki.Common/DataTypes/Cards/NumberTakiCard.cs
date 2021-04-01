using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes.Enums;


namespace Taki.Common.DataTypes.Cards
{
    [Serializable]
    public class NumberTakiCard : ITakiCard
    {
        #region Properties

        public string Name { get; private set; }

        public CardColors Color
        {
            get;
            private set;
        }

        public CardNumbers Number
        {
            get;
            private set;
        }

        #endregion

        #region Ctor

        public NumberTakiCard(CardColors color, CardNumbers number)
        {
            Color = color;
            Number = number;
            Name = Color.ToString() + Number.ToString();
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is NumberTakiCard)
            {
                NumberTakiCard other = obj as NumberTakiCard;

                if (other.Color == Color)
                {
                    if (other.Number == Number)
                    {
                        return true;
                    }
                }
            }

            return false;
        }

        #endregion
    }
}
