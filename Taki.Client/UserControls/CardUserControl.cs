using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taki.Common.DataTypes.Cards;

namespace Taki.Client
{
    public partial class CardUserControl : UserControl
    {
        public string CardName
        {
            get { return Card.Name; }
        }

        public ITakiCard Card
        {
            get;
            private set;
        }

        public CardUserControl(ITakiCard card)
        {
            Card = card;
            InitializeComponent();

          //    this.pictureBox1.Image = global::Taki.Client.Tests.Properties.Resources.YellowTurnSwitch;

            

            this.cardPictureBox.Image = (Image)Properties.Resources.ResourceManager.GetObject(CardName);


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            radioButton.Checked = !radioButton.Checked;
        }

        public delegate void ImCheckedDel(CardUserControl me);

        public event ImCheckedDel ImChecked;

        private void radioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton.Checked == true)
            {
                if (ImChecked != null)
                { 
                    ImChecked(this); 
                }
            }
        }
        
        public override bool Equals(object obj)
        {
            var otherControl = obj as CardUserControl;

            if(otherControl != null)
            {
                if (otherControl.Card == Card)
                {
                    return true;
                }
            }
            //return false if the ref different...
            return base.Equals(obj);
        }
        
        private void cardPictureBox_MouseDown(object sender, MouseEventArgs e)
        {
            radioButton.Checked = !radioButton.Checked;

            if (EnableDoDragDrop)
            {
                DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private bool EnableDoDragDrop = true;
        
        internal void CancelDoDargDrop()
        {
            EnableDoDragDrop = false;
        }
    }
}
