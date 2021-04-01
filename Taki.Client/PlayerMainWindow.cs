using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taki.Common;
using Taki.Common.DataTypes;
using Taki.Client.UserControls;
using Taki.Common.Communication;
using System.Runtime.InteropServices;
using Taki.Common.DataTypes.Cards;
using System.Configuration;

namespace Taki.Client
{
    public partial class PlayerMainWindow : Form
    {
        #region Win32 Api Call
       
        [DllImport("User32.dll")]
        static extern IntPtr GetDC(IntPtr hwnd);

        #endregion

        #region Ctor

        public PlayerMainWindow()
        {
            InitializeComponent();

            InnerTakiPlayer_CardAddedDel1 = new InnerTakiPlayer_CardAddedDel(InnerTakiPlayer_CardAdded);
            InnerTakiPlayer_PlayerCanDropCardsDel1 = new InnerTakiPlayer_PlayerCanDropCardsDel(InnerTakiPlayer_PlayerCanDropCards);
            InnerTakiPlayer_PlayerDropDeniedDel1 = new InnerTakiPlayer_PlayerDropDeniedDel(InnerTakiPlayer_PlayerDropDenied);
            InnerTakiPlayer_CardRemovedDel1 = new InnerTakiPlayer_CardRemovedDel(InnerTakiPlayer_CardRemoved);
            _player_NewTopCarddel1 = new _player_NewTopCarddel(_player_NewTopCard);
            _player_LastPlayerNameChangedDel1 = new _player_LastPlayerNameChangedDel(_player_LastPlayerNameChanged);
            _player_OpenColorPickerDialogDel1 = new _player_OpenColorPickerDialogDel(_player_OpenColorPickerDialog);
            _player_EnableCloseTakiButtonDel1 = new _player_EnableCloseTakiButtonDel(_player_EnableCloseTakiButton);
            _player_YouWonDel1 = new _player_YouWonDel(_player_YouWon);
            _player_WinnerDel1 = new _player_WinnerDel(_player_Winner);
            _player_NewTableSatusDel1 = new _player_NewTableSatusDel(_player_NewTableSatus);
            _player_ServerDownDel1 = new _player_ServerDownDel(_player_ServerDown);
            _player_YouRejectedDel1 = new _player_YouRejectedDel(_player_YouRejected);
            this.creditsString = false;
        }

        #endregion

        #region Properties

        private string _playerName { get; set; }
        private bool creditsString { get; set; }
        TakiPlayerOverTcp _player { get; set; }
        
        private int secToAutoNewCard = 20;

        #endregion
       
        #region Server2UI Methods 
        private delegate void _player_YouRejectedDel();
        private _player_YouRejectedDel _player_YouRejectedDel1;
       
        void _player_YouRejected()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(_player_YouRejectedDel1);
            }
            else
            {
                startGameButton.ButtonColor = Color.Red;
                startGameButton.ButtonText = "The game has already started";
              
                killingClientTimer.Start();
            }
        }

        private delegate void _player_ServerDownDel();
        private _player_ServerDownDel _player_ServerDownDel1;
        void _player_ServerDown()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(_player_ServerDownDel1);
            }
            else
            {
                this.Hide();
                killingClientTimer.Start();

                StopAutoClickTimer();

                IntPtr desktop = GetDC(IntPtr.Zero);
                using (Graphics g = Graphics.FromHdc(desktop))
                {
                    g.DrawImage(Properties.Resources.ServerFail, 0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                }
            }
        }
        
        private delegate void _player_NewTableSatusDel(TableStatus status);
        private _player_NewTableSatusDel _player_NewTableSatusDel1;
        private void _player_NewTableSatus(TableStatus status)
        {
            if (PlayersFlowLayoutPanel.InvokeRequired)
            {
                PlayersFlowLayoutPanel.Invoke(_player_NewTableSatusDel1, new object[] { status });
            }
            else
            {
                PlayersFlowLayoutPanel.Controls.Clear();

                foreach (var item in status.PlayerNamesToLeftCards)
                {

                    PlayersFlowLayoutPanel.Controls.Add(new PlayerUserControl(item.Key, item.Value, item.Key == status.CurrentPlayer));
                  
                }
            }
        }

        private delegate void _player_YouWonDel();
        private  _player_YouWonDel _player_YouWonDel1;
        private void _player_YouWon()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(_player_YouWonDel1);
            }
            else
            {
                this.Hide();
                killingClientTimer.Start();

                StopAutoClickTimer();

                IntPtr desktop = GetDC(IntPtr.Zero);
                using (Graphics g = Graphics.FromHdc(desktop))
                {
                    g.DrawImage(Properties.Resources.winner, 0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                }
            }
        }
        
        private delegate void _player_WinnerDel(string name);
        private _player_WinnerDel _player_WinnerDel1;
        private void _player_Winner(string name)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(_player_WinnerDel1, new object[] { name });
            }
            else
            {
                this.Hide();
                killingClientTimer.Start();

                StopAutoClickTimer();

                IntPtr desktop = GetDC(IntPtr.Zero);
                using (Graphics g = Graphics.FromHdc(desktop))
                {
                    Bitmap loserBitmap = Properties.Resources.loser;
                    Graphics gBmp = Graphics.FromImage(loserBitmap);
                    gBmp.DrawString("And the winner is : " + name, new Font(FontFamily.Families[0], 35), Brushes.White, new Point(0, loserBitmap.Height - 50));

                    g.DrawImage(loserBitmap, 0, 0, Screen.PrimaryScreen.WorkingArea.Width, Screen.PrimaryScreen.WorkingArea.Height);
                }
            }
        }
        
        delegate void _player_OpenColorPickerDialogDel();
        private _player_OpenColorPickerDialogDel _player_OpenColorPickerDialogDel1;
        private void _player_OpenColorPickerDialog()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(_player_OpenColorPickerDialogDel1);
            }
            else
            {
                ColorPickerDialog d = new ColorPickerDialog();
                d.ShowDialog();
                _player.SendSelectedColor(d.SelectedColor);
            }
        }

        delegate void _player_EnableCloseTakiButtonDel();
        private _player_EnableCloseTakiButtonDel _player_EnableCloseTakiButtonDel1;
        private void _player_EnableCloseTakiButton()
        {
            if (closeTakiButton.InvokeRequired)
            {
                closeTakiButton.BeginInvoke(_player_EnableCloseTakiButtonDel1);

            }
            else
            {
                closeTakiButton.Visible = true;
            }
        }

        delegate void _player_LastPlayerNameChangedDel(string name);
        private _player_LastPlayerNameChangedDel _player_LastPlayerNameChangedDel1;
        private void _player_LastPlayerNameChanged(string name)
            {
                if (lastDropperNameLabel.InvokeRequired)
                {
                    lastDropperNameLabel.Invoke(_player_LastPlayerNameChangedDel1, new object[] { name });
                }
                else
                {
                    lastDropperNameLabel.Text = name;
                }
            }
        
        delegate void _player_NewTopCarddel(Common.DataTypes.Cards.ITakiCard theCard);
        private _player_NewTopCarddel _player_NewTopCarddel1;
        private void _player_NewTopCard(Common.DataTypes.Cards.ITakiCard theCard)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(_player_NewTopCarddel1, new object[] { theCard });
            }
            else
            {
                startGameButton.Visible = false;
                groupBox2.Visible = false;
                this.Height = 650;
                
                currentCardFlowLayoutPanel.Controls.Clear();

                var currentCardControl = new CardUserControl(theCard);
                currentCardControl.radioButton.Visible = false;
                currentCardControl.CancelDoDargDrop();
                currentCardFlowLayoutPanel.Controls.Add(currentCardControl);
            }
        }
        
        delegate void InnerTakiPlayer_CardRemovedDel(TakiPlayer player, Common.DataTypes.Cards.ITakiCard theCard);
        private InnerTakiPlayer_CardRemovedDel InnerTakiPlayer_CardRemovedDel1;
        private void InnerTakiPlayer_CardRemoved(TakiPlayer player, Common.DataTypes.Cards.ITakiCard theCard)
        {
            if (yourHandFlowLayoutPanel.InvokeRequired)
            {
                yourHandFlowLayoutPanel.Invoke(InnerTakiPlayer_CardRemovedDel1, new object[] { player, theCard });
            }

            else
            {
                Control controlToRemove = null;
                foreach (var control in yourHandFlowLayoutPanel.Controls)
                {
                    CardUserControl controlCardUserControl = control as CardUserControl;
                    if (controlCardUserControl!=null)
                    {
                        if (controlCardUserControl.Card.Equals(theCard))
                        {
                            controlToRemove = controlCardUserControl; break;
                        }
                    }
                }

                if (controlToRemove != null)
                {
                    yourHandFlowLayoutPanel.Controls.Remove(controlToRemove);
                }
            }
        }
        
        delegate void InnerTakiPlayer_PlayerDropDeniedDel(TakiPlayer player);
        private  InnerTakiPlayer_PlayerDropDeniedDel InnerTakiPlayer_PlayerDropDeniedDel1;
        private void InnerTakiPlayer_PlayerDropDenied(TakiPlayer player)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(InnerTakiPlayer_PlayerDropDeniedDel1, new object[] { player });
            }
            else
            {

               CardUserControl otherCard = new CardUserControl(GetSelectedHandCard());
                otherCard.radioButton.Visible = false;


                DropErrorDialog dialog = new DropErrorDialog(currentCardFlowLayoutPanel.Controls[0] as CardUserControl, otherCard);
                dialog.ShowDialog();

               // MessageBox.Show("Can't drop this card now ...");
            }
        }

        delegate void InnerTakiPlayer_PlayerCanDropCardsDel(TakiPlayer player);
        private InnerTakiPlayer_PlayerCanDropCardsDel InnerTakiPlayer_PlayerCanDropCardsDel1;
        private void InnerTakiPlayer_PlayerCanDropCards(TakiPlayer player)
        {
            if (dropCardButton.InvokeRequired)
            {
                dropCardButton.BeginInvoke(InnerTakiPlayer_PlayerCanDropCardsDel1, new object[] { player });
            }
            else
            {
                sleepPlayersTimer.Start();

                dropCardButton.Visible = true;
                newCardButton.Visible = true;

                notYourTurnButton.Visible = false;
            }
        }

        delegate void InnerTakiPlayer_CardAddedDel(TakiPlayer player, Common.DataTypes.Cards.ITakiCard theCard);
        private InnerTakiPlayer_CardAddedDel InnerTakiPlayer_CardAddedDel1;
        private void InnerTakiPlayer_CardAdded(TakiPlayer player, Common.DataTypes.Cards.ITakiCard theCard)
        {

            if (yourHandFlowLayoutPanel.InvokeRequired)
            {
                yourHandFlowLayoutPanel.BeginInvoke(InnerTakiPlayer_CardAddedDel1, new object[] { player, theCard });
            }
            else
            {

                CardUserControl newControl = new CardUserControl(theCard);

                newControl.ImChecked += new CardUserControl.ImCheckedDel(newControl_ImChecked);
                
                yourHandFlowLayoutPanel.Controls.Add(newControl);                
            }
        }

        #endregion

        #region PrivateMethods
      
        private void startGameButton_Click(object sender, EventArgs e)
        {
            try
            {
                int ServerPort;

                if (!int.TryParse(ConfigurationSettings.AppSettings["ServerPort"], out ServerPort))
                {
                    ServerPort = 28;
                }

                _player = new TakiPlayerOverTcp(new TakiPlayer(_playerName), new TcpDevice(hostNameTextBox.Text, ServerPort));


                _player.InnerTakiPlayer.CardAdded += new TakiPlayer.CardAddedDel(InnerTakiPlayer_CardAdded);
                _player.InnerTakiPlayer.PlayerCanDropCards += new TakiPlayer.PlayerCanDropCardsDel(InnerTakiPlayer_PlayerCanDropCards);
                _player.InnerTakiPlayer.PlayerDropDenied += new TakiPlayer.PlayerDropDeniedDel(InnerTakiPlayer_PlayerDropDenied);

                _player.InnerTakiPlayer.CardRemoved += new TakiPlayer.CardRemovedDel(InnerTakiPlayer_CardRemoved);
                _player.NewTopCard += new TakiPlayerOverTcp.NewTopCardDel(_player_NewTopCard);
                _player.LastPlayerNameChanged += new TakiPlayerOverTcp.LastPlayerNameChangedDel(_player_LastPlayerNameChanged);
                _player.EnableCloseTakiButton += new TakiPlayerOverTcp.EnableCloseTakiButtonDel(_player_EnableCloseTakiButton);
                _player.OpenColorPickerDialog += new TakiPlayerOverTcp.OpenColorPickerDialogDel(_player_OpenColorPickerDialog);

                _player.Winner += new TakiPlayerOverTcp.WinnerNameDel(_player_Winner);
                _player.YouWon += new TakiPlayerOverTcp.YouWonDel(_player_YouWon);
                _player.NewTableSatus += new TakiPlayerOverTcp.NewTableSatusDel(_player_NewTableSatus);
                _player.ServerDown += new TakiPlayerOverTcp.ServerDownDel(_player_ServerDown);
                _player.YouRejected += new TakiPlayerOverTcp.YouRejectedDel(_player_YouRejected);




                startGameButton.Enabled = false;
                hostNameTextBox.Enabled = false;

                startGameButton.ButtonColor = Color.LightGreen;
                startGameButton.ButtonText = "Wating for more players";


            }
            catch (Exception ex)
            {
                startGameButton.BackColor = Color.IndianRed;
                MessageBox.Show("Check your server info.", "Connection error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

       

        private void newControl_ImChecked(CardUserControl me)
        {
            foreach (var control in yourHandFlowLayoutPanel.Controls)
            {
                if (control != me)
                {
                    if (control is CardUserControl)
                    {
                        (control as CardUserControl).radioButton.Checked = false;
                    }
                }
            }
        }

        private void PlayerMainWindow_Load(object sender, EventArgs e)
        {
            this.Height = 160;

            GetNameDialog dialog = new GetNameDialog();
            dialog.ShowDialog();
            
            _playerName = dialog.PlayerName;

            welcomeLabel.Text = "Welcome " + _playerName + ",";         


        }

        private ITakiCard GetSelectedHandCard()
        {
            ITakiCard theCard = null;

            foreach (var control in yourHandFlowLayoutPanel.Controls)
            {
                if (control is CardUserControl)
                {
                    if ((control as CardUserControl).radioButton.Checked)
                    {
                        theCard = (control as CardUserControl).Card;
                    }
                }
            }

            return theCard;
        }

        private void dropCardButton_Click(object sender, EventArgs e)
        {
            ITakiCard theCard = GetSelectedHandCard();

            if (theCard != null)
            {
                _player.SendCardToServer(theCard);

                dropCardButton.Visible = false;
                newCardButton.Visible = false;
              
                closeTakiButton.Visible = false;

                notYourTurnButton.Visible = true;

                StopAutoClickTimer();
            }         
        }

        private void newCardButton_Click(object sender, EventArgs e)
        {
            _player.RequestNewCardFromServer();

            StopAutoClickTimer();

            dropCardButton.Visible = false;
            newCardButton.Visible = false;         
            closeTakiButton.Visible = false;

            notYourTurnButton.Visible = true;

        }

        private void closeTakiButton_Click(object sender, EventArgs e)
        {
            _player.PlayerDoneTheTakiTurn();

            dropCardButton.Visible = false;
            newCardButton.Visible = false;          
            closeTakiButton.Visible = false;
         
            notYourTurnButton.Visible = true;

            StopAutoClickTimer();
        }

        private void StopAutoClickTimer()
        {
            newCardButton.Text = "New Card";
            sleepPlayersTimer.Stop();             
            secToAutoNewCard = 20;        
        }

        private void sleepPlayersTimer_Tick(object sender, EventArgs e)
        {
            if (--secToAutoNewCard > 0)
            {
                newCardButton.ButtonText = "New Card (" + secToAutoNewCard + ")";
            }
            else
            {
                newCardButton.ButtonText = "New Card";
                newCardButton_Click(null, null);
                secToAutoNewCard = 20;
                sleepPlayersTimer.Stop();
            }           
        }

        private void killingClientTimer_Tick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void currentCardFlowLayoutPanel_DragOver(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(typeof(CardUserControl));

            if (data != null)
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void currentCardFlowLayoutPanel_DragDrop(object sender, DragEventArgs e)
        {
            var data = e.Data.GetData(typeof(CardUserControl));

            if (data != null)
            {
                (data as CardUserControl).radioButton.Checked = true;
                if (dropCardButton.Visible == true)
                {
                    dropCardButton_Click(null, null);
                }
            }
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutTheGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("http://www.keepandshare.com/doc/4055284/pdf-may-30-2012-5-54-am-331k?da=y");
            }
            catch {
            }
        }

        #endregion

        private void CreditLabel_Click(object sender, EventArgs e)
        {
            
            if(this.creditsString){
                this.CreditLabel.Text = "This program has been made by - Shani Geva";
                this.creditsString = false;
            }
            else{
                this.CreditLabel.Text = "Yes, all made by me - SG :)";
                this.creditsString = true;
            }
            
        }

        private void creditsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.CreditLabel.Text = "This program has been made by - Shani Geva";
        }

        private void creditsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.CreditLabel.Text = "This program has been made by - Shani Geva";
        }
    }
}
