using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using Taki.Common.DataTypes.Enums;
using System.Windows.Forms;

namespace Taki.Client
{
    public partial class ColorPickerDialog : Form
    {    
        public ColorPickerDialog()
        {            
            InitializeComponent();
        }

        public CardColors SelectedColor
        {
            get;
            set;
        }

        private void redTouchPanel_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedColor = CardColors.Red;
            Close();
        }

        private void yellowTouchPanel_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedColor = CardColors.Yellow;
            Close();
        }

        private void blueTouchPanel_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedColor = CardColors.Blue;
            Close();
        }

        private void greenTouchPanel_MouseClick(object sender, MouseEventArgs e)
        {
            SelectedColor = CardColors.Green;
            Close();
        }    
    }
}
