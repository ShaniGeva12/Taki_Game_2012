namespace Taki.Client
{
    partial class CardUserControl
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
            this.radioButton = new System.Windows.Forms.RadioButton();
            this.cardPictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // radioButton
            // 
            this.radioButton.AutoSize = true;
            this.radioButton.Location = new System.Drawing.Point(3, 3);
            this.radioButton.Name = "radioButton";
            this.radioButton.Size = new System.Drawing.Size(14, 13);
            this.radioButton.TabIndex = 1;
            this.radioButton.TabStop = true;
            this.radioButton.UseVisualStyleBackColor = true;
            this.radioButton.CheckedChanged += new System.EventHandler(this.radioButton_CheckedChanged);
            // 
            // cardPictureBox
            // 
            this.cardPictureBox.Location = new System.Drawing.Point(16, 0);
            this.cardPictureBox.Name = "cardPictureBox";
            this.cardPictureBox.Size = new System.Drawing.Size(61, 79);
            this.cardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.cardPictureBox.TabIndex = 0;
            this.cardPictureBox.TabStop = false;
            this.cardPictureBox.Click += new System.EventHandler(this.pictureBox1_Click);
            this.cardPictureBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.cardPictureBox_MouseDown);
            // 
            // CardUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.radioButton);
            this.Controls.Add(this.cardPictureBox);
            this.Name = "CardUserControl";
            this.Size = new System.Drawing.Size(79, 82);
            ((System.ComponentModel.ISupportInitialize)(this.cardPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.RadioButton radioButton;
        public System.Windows.Forms.PictureBox cardPictureBox;
    }
}
