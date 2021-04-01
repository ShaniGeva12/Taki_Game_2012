using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Taki.Client.UserControls
{
    public partial class GetNameDialog : Form
    {
        public string PlayerName { get; set; }
        private string nameError = "Enter your name HERE";
        private Bitmap nullBitmap = new Bitmap(1, 1); // create a 1 pixel bitmap
        //Bitmap myImage = new Bitmap("Load your Image Here"); // Load your image
        private bool showImage;  // boolean variable so we know what image is assigned

        public GetNameDialog()
        {
            InitializeComponent();
            this.showImage = true;
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if ((!string.IsNullOrEmpty(playerNameTextBox.Text)) && playerNameTextBox.Text != "Enter your name HERE")
            {
                PlayerName = playerNameTextBox.Text;
                base.OnClosing(e);
            }
            else
            {
                playerNameTextBox.BackColor = Color.IndianRed;
                playerNameTextBox.Text = nameError;
                e.Cancel = true;
            } 

        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void okButton_Click(object sender, EventArgs e)
        {
           Close();
        }

        private void playerNameTextBox_MouseHover(object sender, EventArgs e)
        {
            playerNameTextBox.BackColor = Color.White;
        }

        private void exitGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void playerNameTextBox_MouseLeave(object sender, EventArgs e)
        {
            if (playerNameTextBox.Text == nameError)
            {
                playerNameTextBox.BackColor = Color.IndianRed;
            }
        }

        private void logoPicture_Click(object sender, EventArgs e)
        {
            if (this.showImage)
            {
                this.labelC.Text = "Taki game originally was created by Haim Shafir";
                this.showImage = false;
            }
            else
            {
                this.labelC.Text = " ";
                this.showImage = true;
            }
            
        }


    }
}
