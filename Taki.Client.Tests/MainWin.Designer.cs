namespace Taki.Client.Tests
{
    partial class MainWin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWin));
            this.LoadButton = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createNewPlayerButton = new System.Windows.Forms.Button();
            this.SplitCardsButton = new System.Windows.Forms.Button();
            this.RemainingCardsLabel = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.playersFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.CurrentCardPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.CurrentTopCardLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // LoadButton
            // 
            this.LoadButton.Location = new System.Drawing.Point(9, 43);
            this.LoadButton.Name = "LoadButton";
            this.LoadButton.Size = new System.Drawing.Size(70, 29);
            this.LoadButton.TabIndex = 0;
            this.LoadButton.Text = "Load";
            this.LoadButton.UseVisualStyleBackColor = true;
            this.LoadButton.Click += new System.EventHandler(this.LoadButton_Click);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "package_games_card.png");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.createNewPlayerButton);
            this.groupBox1.Controls.Add(this.SplitCardsButton);
            this.groupBox1.Controls.Add(this.RemainingCardsLabel);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.LoadButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(241, 83);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Jackpot";
            // 
            // createNewPlayerButton
            // 
            this.createNewPlayerButton.Location = new System.Drawing.Point(85, 42);
            this.createNewPlayerButton.Name = "createNewPlayerButton";
            this.createNewPlayerButton.Size = new System.Drawing.Size(70, 29);
            this.createNewPlayerButton.TabIndex = 5;
            this.createNewPlayerButton.Text = "New Player";
            this.createNewPlayerButton.UseVisualStyleBackColor = true;
            this.createNewPlayerButton.Click += new System.EventHandler(this.createNewPlayerButton_Click);
            // 
            // SplitCardsButton
            // 
            this.SplitCardsButton.Location = new System.Drawing.Point(161, 42);
            this.SplitCardsButton.Name = "SplitCardsButton";
            this.SplitCardsButton.Size = new System.Drawing.Size(70, 29);
            this.SplitCardsButton.TabIndex = 4;
            this.SplitCardsButton.Text = "Split Cards";
            this.SplitCardsButton.UseVisualStyleBackColor = true;
            this.SplitCardsButton.Click += new System.EventHandler(this.SplitCardsButton_Click);
            // 
            // RemainingCardsLabel
            // 
            this.RemainingCardsLabel.AutoSize = true;
            this.RemainingCardsLabel.Location = new System.Drawing.Point(104, 27);
            this.RemainingCardsLabel.Name = "RemainingCardsLabel";
            this.RemainingCardsLabel.Size = new System.Drawing.Size(13, 13);
            this.RemainingCardsLabel.TabIndex = 3;
            this.RemainingCardsLabel.Text = "0";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Remaining cards :";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.playersFlowLayoutPanel);
            this.groupBox2.Location = new System.Drawing.Point(12, 135);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(651, 291);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Players";
            // 
            // playersFlowLayoutPanel
            // 
            this.playersFlowLayoutPanel.AutoScroll = true;
            this.playersFlowLayoutPanel.Location = new System.Drawing.Point(9, 19);
            this.playersFlowLayoutPanel.Name = "playersFlowLayoutPanel";
            this.playersFlowLayoutPanel.Size = new System.Drawing.Size(632, 266);
            this.playersFlowLayoutPanel.TabIndex = 0;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.CurrentCardPanel);
            this.groupBox5.Controls.Add(this.CurrentTopCardLabel);
            this.groupBox5.Controls.Add(this.label2);
            this.groupBox5.Location = new System.Drawing.Point(259, 12);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(404, 117);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Game Zone";
            // 
            // CurrentCardPanel
            // 
            this.CurrentCardPanel.Location = new System.Drawing.Point(240, 11);
            this.CurrentCardPanel.Name = "CurrentCardPanel";
            this.CurrentCardPanel.Size = new System.Drawing.Size(154, 100);
            this.CurrentCardPanel.TabIndex = 3;
            // 
            // CurrentTopCardLabel
            // 
            this.CurrentTopCardLabel.AutoSize = true;
            this.CurrentTopCardLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.CurrentTopCardLabel.ForeColor = System.Drawing.Color.Red;
            this.CurrentTopCardLabel.Location = new System.Drawing.Point(118, 53);
            this.CurrentTopCardLabel.Name = "CurrentTopCardLabel";
            this.CurrentTopCardLabel.Size = new System.Drawing.Size(116, 20);
            this.CurrentTopCardLabel.TabIndex = 1;
            this.CurrentTopCardLabel.Text = "No Cards Yet";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(18, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Current Top Card :";
            // 
            // MainWin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(673, 433);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainWin";
            this.Text = "Main";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button LoadButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label RemainingCardsLabel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button SplitCardsButton;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label CurrentTopCardLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ImageList imageList1;
        private System.Windows.Forms.FlowLayoutPanel CurrentCardPanel;
        private System.Windows.Forms.Button createNewPlayerButton;
        private System.Windows.Forms.FlowLayoutPanel playersFlowLayoutPanel;
    }
}

