using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Taki.Common.Communication;
using System.Net;
using System.Net.Sockets;
using System.Configuration;


namespace Taki.Server
{
    public partial class ServerUI : Form
    {
        private TcpServerDevice _serverDevice;
        private TakiServerBL serverBL;

        public ServerUI()
        {
            InitializeComponent();

            _serverDevice_NewClientUpDel1 = new _serverDevice_NewClientUpDel(_serverDevice_NewClientUp);
            __serverDevice_ClientDownDel1 = new __serverDevice_ClientDownDel(_serverDevice_ClientDown);
        }

        private void closeServerButton_Click(object sender, EventArgs e)
        {
            if (AreYouSure())
            {
                this.Close();
            }
        }       

      

        delegate void _serverDevice_NewClientUpDel(Socket socket);
        _serverDevice_NewClientUpDel _serverDevice_NewClientUpDel1; 
             
        void _serverDevice_NewClientUp(Socket socket)
        {
            if (this.InvokeRequired)
            {
                 this.Invoke(_serverDevice_NewClientUpDel1,new object[] {socket});
            }
            else
            {
                connectedPlayerCounterLabel.Text = ((int.Parse(connectedPlayerCounterLabel.Text)) + 1).ToString();
            }
        }

        delegate void __serverDevice_ClientDownDel(Socket socket);
        __serverDevice_ClientDownDel __serverDevice_ClientDownDel1; 
        void _serverDevice_ClientDown(System.Net.Sockets.Socket socket)
        {
            if (this.InvokeRequired)
            {
                this.Invoke(__serverDevice_ClientDownDel1, new object[] { socket });
            }
            else
            {
                if (!serverBL.GameStarted)
                {
                    connectedPlayerCounterLabel.Text = ((int.Parse(connectedPlayerCounterLabel.Text)) - 1).ToString();
                }
                else
                {
                    //notif on GUI that client Rejected
                }
            }
        }

        private void ServerUI_Load(object sender, EventArgs e)
        {
            int ServerPort;

            if (!int.TryParse(ConfigurationSettings.AppSettings["ServerPort"], out ServerPort))
            {
            ServerPort = 28;
            }
            serverPortLabel.Text = ServerPort.ToString();

            _serverDevice = new TcpServerDevice(ServerPort);

            _serverDevice.ClientDown += new TcpServerDevice.ClientDownDelegate(_serverDevice_ClientDown);
            _serverDevice.NewClientUp += new TcpServerDevice.NewClientUpDelegate(_serverDevice_NewClientUp);

            serverBL = new TakiServerBL(_serverDevice);

            string host = Dns.GetHostName();
            IPHostEntry ip = Dns.GetHostEntry(host);
            for (int i = 0; i < ip.AddressList.Length; i++)
            { 
                this.IPtextBox.Text = ip.AddressList[i].ToString();
            }
               
        
        }

        private void startGameButton_Click(object sender, EventArgs e)
        {
            serverBL.StartGame();
            startGameButton.Enabled = false;                
        }

        private bool AreYouSure()
        {
            var ans = MessageBox.Show("Are you sure ?", "Taki Server", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (ans == System.Windows.Forms.DialogResult.Yes)
            {
                return true;
            }

            return false;
                
        }

        private void restartServerButton_Click(object sender, EventArgs e)
        {
            if (AreYouSure())
            {
                Application.Restart();
            }
        }

        private void logoPictureBox_Click(object sender, EventArgs e)
        {
            UseCheats = !UseCheats;

            if (!UseCheats)
            {
                Cheat = Cheat.ToLower();
                if (Cheat.StartsWith("hgp"))
                {
                    string CheatCommand = Cheat.Substring(3);
                    var ans = MessageBox.Show(CheatCommand, string.Empty, MessageBoxButtons.YesNo);
                    if (ans == System.Windows.Forms.DialogResult.Yes)
                    {
                        serverBL.CombinaToPlayer(CheatCommand);
                    }
                }
                Cheat = string.Empty;
            }
        }

        bool UseCheats = false;
        string Cheat = string.Empty;

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (UseCheats)
            {
                Cheat += keyData.ToString();
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void IPtextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void CreditLabel_Click(object sender, EventArgs e)
        {
            this.CreditLabel.Text = "Shani_Geva";
        }
    }
}
