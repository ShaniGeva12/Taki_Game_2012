namespace Taki.Client.UserControls
{
    partial class DropErrorDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DropErrorDialog));
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.fromCardPictureBox = new System.Windows.Forms.PictureBox();
            this.toCardPictureBox = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromCardPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCardPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.label1.Location = new System.Drawing.Point(59, 8);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "drop this card now ...";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(332, 121);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(50, 32);
            this.button1.TabIndex = 1;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Taki.Client.Properties.Resources.red_arrow_curved_downright;
            this.pictureBox1.Location = new System.Drawing.Point(135, 56);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(67, 75);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // fromCardPictureBox
            // 
            this.fromCardPictureBox.Location = new System.Drawing.Point(12, 33);
            this.fromCardPictureBox.Name = "fromCardPictureBox";
            this.fromCardPictureBox.Size = new System.Drawing.Size(117, 120);
            this.fromCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.fromCardPictureBox.TabIndex = 3;
            this.fromCardPictureBox.TabStop = false;
            // 
            // toCardPictureBox
            // 
            this.toCardPictureBox.Location = new System.Drawing.Point(208, 33);
            this.toCardPictureBox.Name = "toCardPictureBox";
            this.toCardPictureBox.Size = new System.Drawing.Size(117, 120);
            this.toCardPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.toCardPictureBox.TabIndex = 4;
            this.toCardPictureBox.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(17, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 5;
            this.label2.Text = "Can\'t ";
            // 
            // DropErrorDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.PaleGreen;
            this.ClientSize = new System.Drawing.Size(387, 156);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.toCardPictureBox);
            this.Controls.Add(this.fromCardPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Monotype Corsiva", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximumSize = new System.Drawing.Size(435, 180);
            this.Name = "DropErrorDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Drop rejected";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fromCardPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.toCardPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox fromCardPictureBox;
        private System.Windows.Forms.PictureBox toCardPictureBox;
        private System.Windows.Forms.Label label2;
    }
}