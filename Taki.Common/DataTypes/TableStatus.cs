using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taki.Common.DataTypes
{

    [Serializable]
    public class TableStatus
    {
        #region Properties
        
        public Dictionary<string,int> PlayerNamesToLeftCards { get; set; }

        public string CurrentPlayer{get;set;}

        #endregion

        #region Ctor

        public TableStatus(List<TakiPlayer> players,string currentPlayer)
        {
            PlayerNamesToLeftCards = new Dictionary<string, int>();

            foreach(var player in players)
            {
                PlayerNamesToLeftCards.Add(player.Name, player.CardsLeft);
            }

            CurrentPlayer = currentPlayer;
        }


        #endregion
   }
}
