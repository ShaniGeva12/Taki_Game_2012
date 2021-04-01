namespace Taki.Client.UserControls
{
    partial class GetNameDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetNameDialog));
            this.playerNameTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.logoPicture = new System.Windows.Forms.PictureBox();
            this.creditPicture = new System.Windows.Forms.PictureBox();
            this.labelC = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditPicture)).BeginInit();
            this.SuspendLayout();
            // 
            // playerNameTextBox
            // 
            this.playerNameTextBox.Location = new System.Drawing.Point(129, 9);
            this.playerNameTextBox.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.playerNameTextBox.Name = "playerNameTextBox";
            this.playerNameTextBox.Size = new System.Drawing.Size(338, 39);
            this.playerNameTextBox.TabIndex = 0;
            this.playerNameTextBox.MouseLeave += new System.EventHandler(this.playerNameTextBox_MouseLeave);
            this.playerNameTextBox.MouseHover += new System.EventHandler(this.playerNameTextBox_MouseHover);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(384, 55);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(77, 36);
            this.okButton.TabIndex = 1;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // logoPicture
            // 
            this.logoPicture.Image = global::Taki.Client.Properties.Resources.Taki;
            this.logoPicture.Location = new System.Drawing.Point(-4, 9);
            this.logoPicture.Name = "logoPicture";
            this.logoPicture.Size = new System.Drawing.Size(131, 52);
            this.logoPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.logoPicture.TabIndex = 2;
            this.logoPicture.TabStop = false;
            this.logoPicture.Click += new System.EventHandler(this.logoPicture_Click);
            // 
            // creditPicture
            // 
            this.creditPicture.BackColor = System.Drawing.Color.Transparent;
            this.creditPicture.Image = ((System.Drawing.Image)(resources.GetObject("creditPicture.Image")));
            this.creditPicture.Location = new System.Drawing.Point(147, 60);
            this.creditPicture.Name = "creditPicture";
            this.creditPicture.Size = new System.Drawing.Size(204, 42);
            this.creditPicture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.creditPicture.TabIndex = 4;
            this.creditPicture.TabStop = false;
            // 
            // labelC
            // 
            this.labelC.AutoSize = true;
            this.labelC.BackColor = System.Drawing.Color.Transparent;
            this.labelC.Font = new System.Drawing.Font("Modern No. 20", 12.75F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.labelC.Location = new System.Drawing.Point(12, 62);
            this.labelC.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.labelC.MinimumSize = new System.Drawing.Size(0, 40);
            this.labelC.Name = "labelC";
            this.labelC.Size = new System.Drawing.Size(14, 40);
            this.labelC.TabIndex = 5;
            this.labelC.Text = " ";
            // 
            // GetNameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(470, 111);
            this.Controls.Add(this.labelC);
            this.Controls.Add(this.creditPicture);
            this.Controls.Add(this.logoPicture);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.playerNameTextBox);
            this.Font = new System.Drawing.Font("Modern No. 20", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "GetNameDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enter Player Name";
            ((System.ComponentModel.ISupportInitialize)(this.logoPicture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.creditPicture)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox playerNameTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.PictureBox logoPicture;
        private System.Windows.Forms.PictureBox creditPicture;
        private System.Windows.Forms.Label labelC;
    }
}