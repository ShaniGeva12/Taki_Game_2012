using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Taki.Client.Tests.Enums;

namespace Taki.Client.Tests
{
   public class NumberTakiCard : ITakiCard
    {
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

        public NumberTakiCard(CardColors color, CardNumbers number)
        {
            Color = color;
            Number = number;
            Name = Color.ToString() + Number.ToString();
        }            
    }
}
