using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taki.Client.Tests
{
    public partial class MainWin : Form
    {
        private TakiGame ThisGame
        {
            get;
            set;
        }

        public MainWin()
        {
            ThisGame = new TakiGame();
            ThisGame.TopCardChanged += new TakiGame.TopCardChangedDel(ThisGame_TopCardChanged);

            InitializeComponent();
        }

        void ThisGame_TopCardChanged(ITakiCard newCard)
        {
            CurrentCardPanel.Controls.Clear();

            var newControl = new CardUserControl(newCard);
            newControl.radioButton.Visible = false;

            CurrentTopCardLabel.Text = newControl.CardName;

            CurrentCardPanel.Controls.Add(newControl);
        }

       
        private void UpdateJackPotCounter()
        {
            RemainingCardsLabel.Text = ThisGame.CardLeftAtJackPot.ToString();
        }
      
        private void LoadButton_Click(object sender, EventArgs e)
        {  
            UpdateJackPotCounter();
            LoadButton.Enabled = false;
        }

        
        private void SplitCardsButton_Click(object sender, EventArgs e)
        {
            //Split 8 card each                  
            ThisGame.SplitCardsToPlayers(8);
              
            ThisGame.StartGame();
        }
 
          

        private void createNewPlayerButton_Click(object sender, EventArgs e)
        {
            TakiPlayer newPlayer = new TakiPlayer(Guid.NewGuid().ToString());

            ThisGame.AddNewPlayer(newPlayer);
      
            TakiPlayerHandUserControl newControl = new TakiPlayerHandUserControl(newPlayer);

            playersFlowLayoutPanel.Controls.Add(newControl);
        }

       

      


    
    }
}
