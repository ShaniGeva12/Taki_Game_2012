namespace Taki.Client
{
    partial class ColorPickerDialog
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ColorPickerDialog));
            this.redTouchPanel = new System.Windows.Forms.Panel();
            this.greenTouchPanel = new System.Windows.Forms.Panel();
            this.blueTouchPanel = new System.Windows.Forms.Panel();
            this.yellowTouchPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // redTouchPanel
            // 
            this.redTouchPanel.BackColor = System.Drawing.Color.Transparent;
            this.redTouchPanel.Location = new System.Drawing.Point(86, 48);
            this.redTouchPanel.Name = "redTouchPanel";
            this.redTouchPanel.Size = new System.Drawing.Size(129, 104);
            this.redTouchPanel.TabIndex = 0;
            this.redTouchPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.redTouchPanel_MouseClick);
            // 
            // greenTouchPanel
            // 
            this.greenTouchPanel.BackColor = System.Drawing.Color.Transparent;
            this.greenTouchPanel.Location = new System.Drawing.Point(75, 261);
            this.greenTouchPanel.Name = "greenTouchPanel";
            this.greenTouchPanel.Size = new System.Drawing.Size(129, 127);
            this.greenTouchPanel.TabIndex = 1;
            this.greenTouchPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.greenTouchPanel_MouseClick);
            // 
            // blueTouchPanel
            // 
            this.blueTouchPanel.BackColor = System.Drawing.Color.Transparent;
            this.blueTouchPanel.Location = new System.Drawing.Point(23, 151);
            this.blueTouchPanel.Name = "blueTouchPanel";
            this.blueTouchPanel.Size = new System.Drawing.Size(118, 112);
            this.blueTouchPanel.TabIndex = 2;
            this.blueTouchPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.blueTouchPanel_MouseClick);
            // 
            // yellowTouchPanel
            // 
            this.yellowTouchPanel.BackColor = System.Drawing.Color.Transparent;
            this.yellowTouchPanel.Location = new System.Drawing.Point(154, 151);
            this.yellowTouchPanel.Name = "yellowTouchPanel";
            this.yellowTouchPanel.Size = new System.Drawing.Size(118, 112);
            this.yellowTouchPanel.TabIndex = 3;
            this.yellowTouchPanel.MouseClick += new System.Windows.Forms.MouseEventHandler(this.yellowTouchPanel_MouseClick);
            // 
            // ColorPickerDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(286, 433);
            this.Controls.Add(this.yellowTouchPanel);
            this.Controls.Add(this.blueTouchPanel);
            this.Controls.Add(this.greenTouchPanel);
            this.Controls.Add(this.redTouchPanel);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ColorPickerDialog";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Color Picker";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel redTouchPanel;
        private System.Windows.Forms.Panel greenTouchPanel;
        private System.Windows.Forms.Panel blueTouchPanel;
        private System.Windows.Forms.Panel yellowTouchPanel;


    }
}

