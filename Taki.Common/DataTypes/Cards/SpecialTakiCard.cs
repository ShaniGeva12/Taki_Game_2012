using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes.Enums;



namespace Taki.Common.DataTypes.Cards
{
    [Serializable]
    class SpecialTakiCard : ITakiCard
    {
        #region Properties

        public string Name
        {
            get;
            private set;
        }

        public SpecialCards Type
        {
            get;
            private set;
        } 
        
        public CardColors Color
        {
            get;
            private set;
        }

        #endregion

        #region Ctor

        public SpecialTakiCard(CardColors color,SpecialCards type)
        {
            Type = type;
            Color = color;

            Name = Color.ToString() + Type.ToString();
        }

        #endregion 

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is SpecialTakiCard)
            {
                SpecialTakiCard other = obj as SpecialTakiCard;
                if (other.Color == Color)
                {
                    if (other.Type == Type)
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
