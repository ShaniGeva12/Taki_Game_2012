namespace Taki.Client
{
    partial class PlayerMainWindow
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayerMainWindow));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.hostNameTextBox = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.PlayersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lastDropperNameLabel = new System.Windows.Forms.Label();
            this.currentCardFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.notYourTurnButton = new VistaButtonTest.VistaButton();
            this.closeTakiButton = new VistaButtonTest.VistaButton();
            this.newCardButton = new VistaButtonTest.VistaButton();
            this.dropCardButton = new VistaButtonTest.VistaButton();
            this.yourHandFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.sleepPlayersTimer = new System.Windows.Forms.Timer(this.components);
            this.killingClientTimer = new System.Windows.Forms.Timer(this.components);
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.startGameButton = new VistaButtonTest.VistaButton();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutTheGameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.creditsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreditLabel = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.hostNameTextBox);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(620, 19);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(149, 87);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Taki server info";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(44, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 24);
            this.label2.TabIndex = 4;
            this.label2.Text = "Host name";
            // 
            // hostNameTextBox
            // 
            this.hostNameTextBox.Location = new System.Drawing.Point(15, 50);
            this.hostNameTextBox.Name = "hostNameTextBox";
            this.hostNameTextBox.Size = new System.Drawing.Size(125, 29);
            this.hostNameTextBox.TabIndex = 0;
            this.hostNameTextBox.Text = "127.0.0.1";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.PlayersFlowLayoutPanel);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(246, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(508, 193);
            this.groupBox3.TabIndex = 4;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Players";
            // 
            // PlayersFlowLayoutPanel
            // 
            this.PlayersFlowLayoutPanel.AutoScroll = true;
            this.PlayersFlowLayoutPanel.Location = new System.Drawing.Point(6, 28);
            this.PlayersFlowLayoutPanel.Name = "PlayersFlowLayoutPanel";
            this.PlayersFlowLayoutPanel.Size = new System.Drawing.Size(495, 159);
            this.PlayersFlowLayoutPanel.TabIndex = 0;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.label1);
            this.groupBox4.Controls.Add(this.lastDropperNameLabel);
            this.groupBox4.Controls.Add(this.currentCardFlowLayoutPanel);
            this.groupBox4.Controls.Add(this.groupBox3);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.Location = new System.Drawing.Point(9, 117);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(760, 227);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Game Zone";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(2, 162);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "Last drop by :";
            // 
            // lastDropperNameLabel
            // 
            this.lastDropperNameLabel.AutoSize = true;
            this.lastDropperNameLabel.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lastDropperNameLabel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lastDropperNameLabel.Location = new System.Drawing.Point(6, 195);
            this.lastDropperNameLabel.Name = "lastDropperNameLabel";
            this.lastDropperNameLabel.Size = new System.Drawing.Size(60, 20);
            this.lastDropperNameLabel.TabIndex = 2;
            this.lastDropperNameLabel.Text = "jackpot";
            // 
            // currentCardFlowLayoutPanel
            // 
            this.currentCardFlowLayoutPanel.AllowDrop = true;
            this.currentCardFlowLayoutPanel.Location = new System.Drawing.Point(108, 28);
            this.currentCardFlowLayoutPanel.Name = "currentCardFlowLayoutPanel";
            this.currentCardFlowLayoutPanel.Size = new System.Drawing.Size(132, 180);
            this.currentCardFlowLayoutPanel.TabIndex = 1;
            this.currentCardFlowLayoutPanel.DragDrop += new System.Windows.Forms.DragEventHandler(this.currentCardFlowLayoutPanel_DragDrop);
            this.currentCardFlowLayoutPanel.DragOver += new System.Windows.Forms.DragEventHandler(this.currentCardFlowLayoutPanel_DragOver);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(2, 104);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(106, 20);
            this.label4.TabIndex = 0;
            this.label4.Text = "Current card :";
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.AutoSize = true;
            this.welcomeLabel.Font = new System.Drawing.Font("Modern No. 20", 20.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.welcomeLabel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.welcomeLabel.Location = new System.Drawing.Point(237, 24);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(193, 29);
            this.welcomeLabel.TabIndex = 6;
            this.welcomeLabel.Text = "Welcome XXX";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.notYourTurnButton);
            this.groupBox1.Controls.Add(this.closeTakiButton);
            this.groupBox1.Controls.Add(this.newCardButton);
            this.groupBox1.Controls.Add(this.dropCardButton);
            this.groupBox1.Controls.Add(this.yourHandFlowLayoutPanel);
            this.groupBox1.Font = new System.Drawing.Font("Modern No. 20", 14.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(9, 350);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(760, 255);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Your hand";
            // 
            // notYourTurnButton
            // 
            this.notYourTurnButton.BackColor = System.Drawing.Color.Transparent;
            this.notYourTurnButton.BaseColor = System.Drawing.Color.PaleGreen;
            this.notYourTurnButton.ButtonText = "Not Your Turn ";
            this.notYourTurnButton.Enabled = false;
            this.notYourTurnButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.notYourTurnButton.Location = new System.Drawing.Point(664, 24);
            this.notYourTurnButton.Name = "notYourTurnButton";
            this.notYourTurnButton.Size = new System.Drawing.Size(90, 225);
            this.notYourTurnButton.TabIndex = 9;
            // 
            // closeTakiButton
            // 
            this.closeTakiButton.BackColor = System.Drawing.Color.Transparent;
            this.closeTakiButton.ButtonColor = System.Drawing.Color.Gray;
            this.closeTakiButton.ButtonText = "Close Taki";
            this.closeTakiButton.Location = new System.Drawing.Point(664, 121);
            this.closeTakiButton.Name = "closeTakiButton";
            this.closeTakiButton.Size = new System.Drawing.Size(87, 31);
            this.closeTakiButton.TabIndex = 11;
            this.closeTakiButton.Visible = false;
            this.closeTakiButton.Click += new System.EventHandler(this.closeTakiButton_Click);
            // 
            // newCardButton
            // 
            this.newCardButton.BackColor = System.Drawing.Color.Transparent;
            this.newCardButton.ButtonText = "New Card";
            this.newCardButton.Location = new System.Drawing.Point(664, 186);
            this.newCardButton.Name = "newCardButton";
            this.newCardButton.Size = new System.Drawing.Size(87, 63);
            this.newCardButton.TabIndex = 10;
            this.newCardButton.Visible = false;
            this.newCardButton.Click += new System.EventHandler(this.newCardButton_Click);
            // 
            // dropCardButton
            // 
            this.dropCardButton.BackColor = System.Drawing.Color.Transparent;
            this.dropCardButton.ButtonText = "Drop";
            this.dropCardButton.Location = new System.Drawing.Point(664, 24);
            this.dropCardButton.Name = "dropCardButton";
            this.dropCardButton.Size = new System.Drawing.Size(87, 63);
            this.dropCardButton.TabIndex = 9;
            this.dropCardButton.Visible = false;
            this.dropCardButton.Click += new System.EventHandler(this.dropCardButton_Click);
            // 
            // yourHandFlowLayoutPanel
            // 
            this.yourHandFlowLayoutPanel.AutoScroll = true;
            this.yourHandFlowLayoutPanel.Location = new System.Drawing.Point(11, 24);
            this.yourHandFlowLayoutPanel.Name = "yourHandFlowLayoutPanel";
            this.yourHandFlowLayoutPanel.Size = new System.Drawing.Size(650, 225);
            this.yourHandFlowLayoutPanel.TabIndex = 0;
            // 
            // sleepPlayersTimer
            // 
            this.sleepPlayersTimer.Interval = 1000;
            this.sleepPlayersTimer.Tick += new System.EventHandler(this.sleepPlayersTimer_Tick);
            // 
            // killingClientTimer
            // 
            this.killingClientTimer.Interval = 20000;
            this.killingClientTimer.Tick += new System.EventHandler(this.killingClientTimer_Tick);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taki.Client.Properties.Resources.Taki;
            this.pictureBox1.Location = new System.Drawing.Point(15, 24);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(205, 88);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // startGameButton
            // 
            this.startGameButton.BackColor = System.Drawing.Color.Transparent;
            this.startGameButton.ButtonText = "Start Game";
            this.startGameButton.Location = new System.Drawing.Point(243, 69);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(370, 37);
            this.startGameButton.TabIndex = 8;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // menuStrip
            // 
            this.menuStrip.BackColor = System.Drawing.Color.Transparent;
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(779, 24);
            this.menuStrip.TabIndex = 9;
            this.menuStrip.Text = "menuStrip1";
            this.menuStrip.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.menuStrip_ItemClicked);
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutTheGameToolStripMenuItem,
            this.creditsToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.fileToolStripMenuItem.Text = "File ";
            // 
            // aboutTheGameToolStripMenuItem
            // 
            this.aboutTheGameToolStripMenuItem.Name = "aboutTheGameToolStripMenuItem";
            this.aboutTheGameToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aboutTheGameToolStripMenuItem.Text = "Instructions";
            this.aboutTheGameToolStripMenuItem.Click += new System.EventHandler(this.aboutTheGameToolStripMenuItem_Click);
            // 
            // creditsToolStripMenuItem
            // 
            this.creditsToolStripMenuItem.Name = "creditsToolStripMenuItem";
            this.creditsToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.creditsToolStripMenuItem.Text = "Credits";
            this.creditsToolStripMenuItem.Click += new System.EventHandler(this.creditsToolStripMenuItem_Click_1);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click_1);
            // 
            // CreditLabel
            // 
            this.CreditLabel.AutoSize = true;
            this.CreditLabel.BackColor = System.Drawing.Color.Transparent;
            this.CreditLabel.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.CreditLabel.Font = new System.Drawing.Font("Verdana", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreditLabel.ForeColor = System.Drawing.Color.DarkOrchid;
            this.CreditLabel.Location = new System.Drawing.Point(264, 6);
            this.CreditLabel.Name = "CreditLabel";
            this.CreditLabel.Size = new System.Drawing.Size(15, 18);
            this.CreditLabel.TabIndex = 10;
            this.CreditLabel.Text = "/";
            this.CreditLabel.Click += new System.EventHandler(this.CreditLabel_Click);
            // 
            // PlayerMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(779, 611);
            this.Controls.Add(this.CreditLabel);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.menuStrip);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.ForeColor = System.Drawing.Color.Purple;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 650);
            this.Name = "PlayerMainWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Taki game";
            this.Load += new System.EventHandler(this.PlayerMainWindow_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox hostNameTextBox;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.FlowLayoutPanel currentCardFlowLayoutPanel;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label welcomeLabel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel yourHandFlowLayoutPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lastDropperNameLabel;
        private System.Windows.Forms.FlowLayoutPanel PlayersFlowLayoutPanel;
        private System.Windows.Forms.Timer sleepPlayersTimer;
        private System.Windows.Forms.Timer killingClientTimer;
        private VistaButtonTest.VistaButton startGameButton;
        private VistaButtonTest.VistaButton closeTakiButton;
        private VistaButtonTest.VistaButton newCardButton;
        private VistaButtonTest.VistaButton dropCardButton;
        private VistaButtonTest.VistaButton notYourTurnButton;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutTheGameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.Label CreditLabel;
        private System.Windows.Forms.ToolStripMenuItem creditsToolStripMenuItem;
    }
}

