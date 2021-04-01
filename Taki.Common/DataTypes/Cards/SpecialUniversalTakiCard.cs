using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes.Enums;

namespace Taki.Common.DataTypes.Cards
{
    [Serializable]
    public class SpecialUniversalTakiCard : ITakiCard
    {
        #region Properties

        public SpecialUniversalCards Type
        {
            get;
            private set; 
        }

        public string Name
        {
            get;
            private set;
        }

        #endregion

        #region Ctor

        public SpecialUniversalTakiCard(SpecialUniversalCards type)
        {
            Type = type;
            Name = Type.ToString();
        }

        #endregion

        #region Overrides

        public override bool Equals(object obj)
        {
            if (obj is SpecialUniversalTakiCard)
            {
                SpecialUniversalTakiCard other = obj as SpecialUniversalTakiCard;
                if (other.Type == Type)
                {
                    return true;
                }
            }
            return false;

        }

        #endregion
    }
}
