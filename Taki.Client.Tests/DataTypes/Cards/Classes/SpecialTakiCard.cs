using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Client.Tests.Enums;

namespace Taki.Client.Tests.Cards
{
    class SpecialTakiCard : ITakiCard
    {
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

        public SpecialTakiCard(CardColors color,SpecialCards type)
        {
            Type = type;
            Color = color;

            Name = Color.ToString() + Type.ToString();
        }       
    }
}
