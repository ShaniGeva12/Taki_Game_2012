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
    public partial class DropErrorDialog : Form
    {
        public DropErrorDialog(CardUserControl currentTopCard, CardUserControl otherCard)
        {
            InitializeComponent();

            fromCardPictureBox.Image = currentTopCard.cardPictureBox.Image;
            toCardPictureBox.Image = otherCard.cardPictureBox.Image;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.Enter)
            {
                this.Close();
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }        
    }
}
