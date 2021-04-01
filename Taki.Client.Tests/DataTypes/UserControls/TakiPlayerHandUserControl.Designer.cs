namespace Taki.Client.Tests
{
    partial class TakiPlayerHandUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PlayerNameGroupBox = new System.Windows.Forms.GroupBox();
            this.CardsFlowlayout = new System.Windows.Forms.FlowLayoutPanel();
            this.SendACardButton = new System.Windows.Forms.Button();
            this.GetNewCardButton = new System.Windows.Forms.Button();
            this.DoneTurnButton = new System.Windows.Forms.Button();
            this.PlayerNameGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // PlayerNameGroupBox
            // 
            this.PlayerNameGroupBox.Controls.Add(this.DoneTurnButton);
            this.PlayerNameGroupBox.Controls.Add(this.CardsFlowlayout);
            this.PlayerNameGroupBox.Controls.Add(this.SendACardButton);
            this.PlayerNameGroupBox.Controls.Add(this.GetNewCardButton);
            this.PlayerNameGroupBox.Location = new System.Drawing.Point(3, 3);
            this.PlayerNameGroupBox.Name = "PlayerNameGroupBox";
            this.PlayerNameGroupBox.Size = new System.Drawing.Size(596, 265);
            this.PlayerNameGroupBox.TabIndex = 1;
            this.PlayerNameGroupBox.TabStop = false;
            this.PlayerNameGroupBox.Text = "Player Name HERE";
            // 
            // CardsFlowlayout
            // 
            this.CardsFlowlayout.AllowDrop = true;
            this.CardsFlowlayout.AutoScroll = true;
            this.CardsFlowlayout.Location = new System.Drawing.Point(6, 19);
            this.CardsFlowlayout.Name = "CardsFlowlayout";
            this.CardsFlowlayout.Size = new System.Drawing.Size(584, 194);
            this.CardsFlowlayout.TabIndex = 5;
            // 
            // SendACardButton
            // 
            this.SendACardButton.Enabled = false;
            this.SendACardButton.Location = new System.Drawing.Point(6, 219);
            this.SendACardButton.Name = "SendACardButton";
            this.SendACardButton.Size = new System.Drawing.Size(142, 40);
            this.SendACardButton.TabIndex = 6;
            this.SendACardButton.Text = "Send This Card";
            this.SendACardButton.UseVisualStyleBackColor = true;
            this.SendACardButton.Click += new System.EventHandler(this.SendACardButton_Click);
            // 
            // GetNewCardButton
            // 
            this.GetNewCardButton.Enabled = false;
            this.GetNewCardButton.Location = new System.Drawing.Point(448, 219);
            this.GetNewCardButton.Name = "GetNewCardButton";
            this.GetNewCardButton.Size = new System.Drawing.Size(142, 40);
            this.GetNewCardButton.TabIndex = 3;
            this.GetNewCardButton.Text = "Get New Card";
            this.GetNewCardButton.UseVisualStyleBackColor = true;
            this.GetNewCardButton.Click += new System.EventHandler(this.GetNewCardButton_Click);
            // 
            // DoneTurnButton
            // 
            this.DoneTurnButton.Enabled = false;
            this.DoneTurnButton.Location = new System.Drawing.Point(225, 219);
            this.DoneTurnButton.Name = "DoneTurnButton";
            this.DoneTurnButton.Size = new System.Drawing.Size(142, 40);
            this.DoneTurnButton.TabIndex = 7;
            this.DoneTurnButton.Text = "Done Turn";
            this.DoneTurnButton.UseVisualStyleBackColor = true;
            this.DoneTurnButton.Click += new System.EventHandler(this.DoneTurnButton_Click);
            // 
            // TakiPlayerHandUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PlayerNameGroupBox);
            this.Name = "TakiPlayerHandUserControl";
            this.Size = new System.Drawing.Size(602, 274);
            this.PlayerNameGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox PlayerNameGroupBox;
        private System.Windows.Forms.FlowLayoutPanel CardsFlowlayout;
        private System.Windows.Forms.Button SendACardButton;
        private System.Windows.Forms.Button GetNewCardButton;
        private System.Windows.Forms.Button DoneTurnButton;
    }
}
