namespace Taki.Server
{
    partial class ServerUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ServerUI));
            this.closeServerButton = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.connectedPlayerCounterLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.startGameButton = new System.Windows.Forms.Button();
            this.logoPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.serverPortLabel = new System.Windows.Forms.Label();
            this.restartServerButton = new System.Windows.Forms.Button();
            this.yourIPlabel = new System.Windows.Forms.Label();
            this.IPtextBox = new System.Windows.Forms.TextBox();
            this.CreditLabel = new System.Windows.Forms.Label();
            this.statusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // closeServerButton
            // 
            this.closeServerButton.Location = new System.Drawing.Point(24, 254);
            this.closeServerButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.closeServerButton.Name = "closeServerButton";
            this.closeServerButton.Size = new System.Drawing.Size(212, 39);
            this.closeServerButton.TabIndex = 2;
            this.closeServerButton.Text = "Close server";
            this.closeServerButton.UseVisualStyleBackColor = true;
            this.closeServerButton.Click += new System.EventHandler(this.closeServerButton_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.connectedPlayerCounterLabel});
            this.statusStrip.Location = new System.Drawing.Point(0, 365);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(260, 22);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(111, 17);
            this.toolStripStatusLabel1.Text = "Connected players :";
            // 
            // connectedPlayerCounterLabel
            // 
            this.connectedPlayerCounterLabel.Name = "connectedPlayerCounterLabel";
            this.connectedPlayerCounterLabel.Size = new System.Drawing.Size(13, 17);
            this.connectedPlayerCounterLabel.Text = "0";
            // 
            // startGameButton
            // 
            this.startGameButton.Location = new System.Drawing.Point(24, 105);
            this.startGameButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.startGameButton.Name = "startGameButton";
            this.startGameButton.Size = new System.Drawing.Size(211, 39);
            this.startGameButton.TabIndex = 4;
            this.startGameButton.Text = "Start taki game";
            this.startGameButton.UseVisualStyleBackColor = true;
            this.startGameButton.Click += new System.EventHandler(this.startGameButton_Click);
            // 
            // logoPictureBox
            // 
            this.logoPictureBox.Image = global::Taki.Server.Properties.Resources.Tak2i;
            this.logoPictureBox.Location = new System.Drawing.Point(31, 15);
            this.logoPictureBox.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.logoPictureBox.Name = "logoPictureBox";
            this.logoPictureBox.Size = new System.Drawing.Size(204, 82);
            this.logoPictureBox.TabIndex = 0;
            this.logoPictureBox.TabStop = false;
            this.logoPictureBox.Click += new System.EventHandler(this.logoPictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(28, 148);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(207, 19);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server set on port";
            // 
            // serverPortLabel
            // 
            this.serverPortLabel.AutoSize = true;
            this.serverPortLabel.Location = new System.Drawing.Point(102, 178);
            this.serverPortLabel.Name = "serverPortLabel";
            this.serverPortLabel.Size = new System.Drawing.Size(42, 19);
            this.serverPortLabel.TabIndex = 6;
            this.serverPortLabel.Text = "XXX";
            // 
            // restartServerButton
            // 
            this.restartServerButton.Location = new System.Drawing.Point(23, 207);
            this.restartServerButton.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.restartServerButton.Name = "restartServerButton";
            this.restartServerButton.Size = new System.Drawing.Size(212, 39);
            this.restartServerButton.TabIndex = 7;
            this.restartServerButton.Text = "Restart server";
            this.restartServerButton.UseVisualStyleBackColor = true;
            this.restartServerButton.Click += new System.EventHandler(this.restartServerButton_Click);
            // 
            // yourIPlabel
            // 
            this.yourIPlabel.AutoSize = true;
            this.yourIPlabel.Location = new System.Drawing.Point(2, 324);
            this.yourIPlabel.Name = "yourIPlabel";
            this.yourIPlabel.Size = new System.Drawing.Size(97, 19);
            this.yourIPlabel.TabIndex = 8;
            this.yourIPlabel.Text = "Your IP:";
            // 
            // IPtextBox
            // 
            this.IPtextBox.Font = new System.Drawing.Font("Miriam Fixed", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.IPtextBox.Location = new System.Drawing.Point(97, 321);
            this.IPtextBox.Name = "IPtextBox";
            this.IPtextBox.ReadOnly = true;
            this.IPtextBox.Size = new System.Drawing.Size(151, 24);
            this.IPtextBox.TabIndex = 9;
            this.IPtextBox.TextChanged += new System.EventHandler(this.IPtextBox_TextChanged);
            // 
            // CreditLabel
            // 
            this.CreditLabel.AutoSize = true;
            this.CreditLabel.BackColor = System.Drawing.Color.Transparent;
            this.CreditLabel.Location = new System.Drawing.Point(82, 85);
            this.CreditLabel.Name = "CreditLabel";
            this.CreditLabel.Size = new System.Drawing.Size(20, 19);
            this.CreditLabel.TabIndex = 10;
            this.CreditLabel.Text = "^";
            this.CreditLabel.Click += new System.EventHandler(this.CreditLabel_Click);
            // 
            // ServerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 387);
            this.Controls.Add(this.CreditLabel);
            this.Controls.Add(this.IPtextBox);
            this.Controls.Add(this.yourIPlabel);
            this.Controls.Add(this.restartServerButton);
            this.Controls.Add(this.serverPortLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startGameButton);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.closeServerButton);
            this.Controls.Add(this.logoPictureBox);
            this.Font = new System.Drawing.Font("Miriam Fixed", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 4, 6, 4);
            this.Name = "ServerUI";
            this.Opacity = 0.85D;
            this.Text = "Taki game server";
            this.Load += new System.EventHandler(this.ServerUI_Load);
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.logoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox logoPictureBox;
        private System.Windows.Forms.Button closeServerButton;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel connectedPlayerCounterLabel;
        private System.Windows.Forms.Button startGameButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label serverPortLabel;
        private System.Windows.Forms.Button restartServerButton;
        private System.Windows.Forms.Label yourIPlabel;
        private System.Windows.Forms.TextBox IPtextBox;
        private System.Windows.Forms.Label CreditLabel;
    }
}

