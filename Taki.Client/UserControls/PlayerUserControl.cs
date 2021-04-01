using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taki.Client.UserControls
{
    public partial class PlayerUserControl : UserControl
    { 
        public PlayerUserControl(string playerName, int leftCards,bool currentPlayer)
        {
            InitializeComponent();

            nameLabel.Text = playerName;
            cardsLeftLabel.Text = leftCards.ToString();

            pictureBox1.Visible = currentPlayer;
            pictureBox2.Visible = currentPlayer;
        }
    }
}
