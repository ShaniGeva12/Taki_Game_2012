using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Client.Tests.Enums;

namespace Taki.Client.Tests.Cards
{
    class SpecialUniversalTakiCard : ITakiCard
    {
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

        public SpecialUniversalTakiCard(SpecialUniversalCards type)
        {
            Type = type;
            Name = Type.ToString();
        }
    }
}
