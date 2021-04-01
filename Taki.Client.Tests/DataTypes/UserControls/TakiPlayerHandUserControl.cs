using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taki.Client.Tests
{
    public partial class TakiPlayerHandUserControl : UserControl
    {
        public ITakiCard MySelectedCard
        {
            get;
            set;        
        }

        public TakiPlayer Player
        {
            get;
            private set;
        }

        public string PlayerName
        {
            get { return Player.Name; }
           
        }

        public TakiPlayerHandUserControl(TakiPlayer player)
        {
            Player = player;
            player.CardAdded += new TakiPlayer.CardAddedDel(player_CardAdded);
            player.CardRemoved += new TakiPlayer.CardRemovedDel(player_CardRemoved);
            player.PlayerCanDropCards += new TakiPlayer.PlayerCanDropCardsDel(player_PlayerCanDropCards);
            player.PlayerDropDenied += new TakiPlayer.PlayerDropDeniedDel(player_PlayerDropDenied);
            player.PlayerCanDecideToDoneReceived += new TakiPlayer.PlayerCanDecideToDoneReceivedDel(player_PlayerCanDecideToDoneReceived);
            




            InitializeComponent();

            PlayerNameGroupBox.Text = PlayerName;
        }

        void player_PlayerCanDecideToDoneReceived()
        {
            CardsFlowlayout.Enabled = false;
                       
            DoneTurnButton.Enabled = true;           

            CardsFlowlayout.Enabled = true;   
        }

        void player_PlayerDropDenied()
        {
            MessageBox.Show("Can't drop this card", "Action is denied",MessageBoxButtons.OK,MessageBoxIcon.Error);
            SetPlayerTurn(true);
        }

        void player_PlayerCanDropCards()
        {
            SetPlayerTurn(true);
        }

        private void SetPlayerTurn(bool isPlayerTurn)
        {
            CardsFlowlayout.Enabled = false;

            SendACardButton.Enabled = isPlayerTurn;
            GetNewCardButton.Enabled = isPlayerTurn;

            if (isPlayerTurn == false)
            {
                DoneTurnButton.Enabled = isPlayerTurn; //false;
            }

            CardsFlowlayout.Enabled = true;         
        }



        void player_CardRemoved(ITakiCard theCard)
        {
            CardUserControl controlToRemove = null;

            foreach (var contorl in CardsFlowlayout.Controls)
            {
                CardUserControl contorlToCheck = contorl as CardUserControl;
                if (contorlToCheck != null)
                {
                    if (contorlToCheck.Card == theCard)
                    {
                        controlToRemove = contorlToCheck;
                        break;
                    }
                }
            }


            controlToRemove.ImChecked -= new CardUserControl.ImCheckedDel(newControl_ImChecked);
            CardsFlowlayout.Controls.Remove(controlToRemove);
        }

        void player_CardAdded(ITakiCard theCard)
        {
            CardUserControl newControl = new CardUserControl(theCard);
            newControl.ImChecked += new CardUserControl.ImCheckedDel(newControl_ImChecked);

            CardsFlowlayout.Controls.Add(newControl);
        }       
        void newControl_ImChecked(CardUserControl checkedControl)
        {
            MySelectedCard = checkedControl.Card;

            foreach (var control in CardsFlowlayout.Controls)
            {
                if (control is CardUserControl)
                {
                    if (control != checkedControl)
                    {
                        (control as CardUserControl).radioButton.Checked = false;
                    }
                }
            }
        }        

        private void SendACardButton_Click(object sender, EventArgs e)
        {
            if (MySelectedCard != null)
            {
                SetPlayerTurn(false);
                Player.PlayerTryToDropCard(MySelectedCard);               
            }
            else
            {
                throw new Exception("The request will not reach the target");
            }
        }

        private void GetNewCardButton_Click(object sender, EventArgs e)
        {          
            SetPlayerTurn(false);
            Player.PlayerCardRequest();         
        }

        private void DoneTurnButton_Click(object sender, EventArgs e)
        {
            SetPlayerTurn(false);


            //For done the turn after Taki Bulk...
            //TODO:
        }       
    }
}
