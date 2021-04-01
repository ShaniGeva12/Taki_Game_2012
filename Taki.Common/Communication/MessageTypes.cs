using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Taki.Common.DataTypes
{
    public enum MessageTypes
    {
        None,
        ERROR,

        PlayerName,
        CardMessage,
        CardRemoveMessage,
        TopCard,
        LastPlayerName,
        PlayerCanDropCards,
        DropDenied,
        NewCardRequest,
        PlayerCanDecideToDoneReceived,
        SelectedColorByUser,
        PlayerDoneTheTakiTurn,
        ChooseColorRequest,
        WinnerName,
        YouWinMessage,
        TableStatus,
        NewPlayerRejected
    }
}
