namespace Serial_Plotter.ui
{
    partial class CLUI_HeadButton
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
            this.ImageBox = new System.Windows.Forms.PictureBox();
            this.Text1Label = new System.Windows.Forms.Label();
            this.Text2Label = new System.Windows.Forms.Label();
            this.BorderBottom = new System.Windows.Forms.Panel();
            this.BorderTop = new System.Windows.Forms.Panel();
            this.BorderLeft = new System.Windows.Forms.Panel();
            this.BorderRight = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // ImageBox
            // 
            this.ImageBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.ImageBox.Location = new System.Drawing.Point(15, 15);
            this.ImageBox.Name = "ImageBox";
            this.ImageBox.Size = new System.Drawing.Size(20, 18);
            this.ImageBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.ImageBox.TabIndex = 0;
            this.ImageBox.TabStop = false;
            this.ImageBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseDown);
            this.ImageBox.MouseEnter += new System.EventHandler(this.CLUI_HeadButton_MouseEnter);
            this.ImageBox.MouseLeave += new System.EventHandler(this.CLUI_HeadButton_MouseLeave);
            this.ImageBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseUp);
            // 
            // Text1Label
            // 
            this.Text1Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Text1Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.Text1Label.Location = new System.Drawing.Point(51, 1);
            this.Text1Label.Name = "Text1Label";
            this.Text1Label.Size = new System.Drawing.Size(146, 23);
            this.Text1Label.TabIndex = 1;
            this.Text1Label.Text = "Text1";
            this.Text1Label.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.Text1Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseDown);
            this.Text1Label.MouseEnter += new System.EventHandler(this.CLUI_HeadButton_MouseEnter);
            this.Text1Label.MouseLeave += new System.EventHandler(this.CLUI_HeadButton_MouseLeave);
            this.Text1Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseUp);
            // 
            // Text2Label
            // 
            this.Text2Label.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.Text2Label.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Text2Label.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(207)))));
            this.Text2Label.Location = new System.Drawing.Point(51, 26);
            this.Text2Label.Name = "Text2Label";
            this.Text2Label.Size = new System.Drawing.Size(146, 23);
            this.Text2Label.TabIndex = 2;
            this.Text2Label.Text = "Text2";
            this.Text2Label.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseDown);
            this.Text2Label.MouseEnter += new System.EventHandler(this.CLUI_HeadButton_MouseEnter);
            this.Text2Label.MouseLeave += new System.EventHandler(this.CLUI_HeadButton_MouseLeave);
            this.Text2Label.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseUp);
            // 
            // BorderBottom
            // 
            this.BorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BorderBottom.Location = new System.Drawing.Point(1, 49);
            this.BorderBottom.Name = "BorderBottom";
            this.BorderBottom.Size = new System.Drawing.Size(198, 1);
            this.BorderBottom.TabIndex = 8;
            // 
            // BorderTop
            // 
            this.BorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderTop.Location = new System.Drawing.Point(1, 0);
            this.BorderTop.Name = "BorderTop";
            this.BorderTop.Size = new System.Drawing.Size(198, 1);
            this.BorderTop.TabIndex = 7;
            // 
            // BorderLeft
            // 
            this.BorderLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.BorderLeft.Location = new System.Drawing.Point(0, 0);
            this.BorderLeft.Name = "BorderLeft";
            this.BorderLeft.Size = new System.Drawing.Size(1, 50);
            this.BorderLeft.TabIndex = 6;
            // 
            // BorderRight
            // 
            this.BorderRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.BorderRight.Location = new System.Drawing.Point(199, 0);
            this.BorderRight.Name = "BorderRight";
            this.BorderRight.Size = new System.Drawing.Size(1, 50);
            this.BorderRight.TabIndex = 5;
            // 
            // CLUI_HeadButton
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.Controls.Add(this.BorderBottom);
            this.Controls.Add(this.BorderTop);
            this.Controls.Add(this.BorderLeft);
            this.Controls.Add(this.BorderRight);
            this.Controls.Add(this.Text2Label);
            this.Controls.Add(this.Text1Label);
            this.Controls.Add(this.ImageBox);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "CLUI_HeadButton";
            this.Size = new System.Drawing.Size(200, 50);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseDown);
            this.MouseEnter += new System.EventHandler(this.CLUI_HeadButton_MouseEnter);
            this.MouseLeave += new System.EventHandler(this.CLUI_HeadButton_MouseLeave);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.CLUI_HeadButton_MouseUp);
            ((System.ComponentModel.ISupportInitialize)(this.ImageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ImageBox;
        private System.Windows.Forms.Label Text1Label;
        private System.Windows.Forms.Label Text2Label;
        private System.Windows.Forms.Panel BorderBottom;
        private System.Windows.Forms.Panel BorderTop;
        private System.Windows.Forms.Panel BorderLeft;
        private System.Windows.Forms.Panel BorderRight;
    }
}
