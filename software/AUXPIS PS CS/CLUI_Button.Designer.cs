namespace Serial_Plotter.ui
{
    partial class CLUI_Button
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
            this.BorderRight = new System.Windows.Forms.Panel();
            this.BorderLeft = new System.Windows.Forms.Panel();
            this.BorderTop = new System.Windows.Forms.Panel();
            this.BorderBottom = new System.Windows.Forms.Panel();
            this.TextLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // BorderRight
            // 
            this.BorderRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.BorderRight.Location = new System.Drawing.Point(74, 0);
            this.BorderRight.Name = "BorderRight";
            this.BorderRight.Size = new System.Drawing.Size(1, 23);
            this.BorderRight.TabIndex = 1;
            // 
            // BorderLeft
            // 
            this.BorderLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.BorderLeft.Location = new System.Drawing.Point(0, 0);
            this.BorderLeft.Name = "BorderLeft";
            this.BorderLeft.Size = new System.Drawing.Size(1, 23);
            this.BorderLeft.TabIndex = 2;
            // 
            // BorderTop
            // 
            this.BorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderTop.Location = new System.Drawing.Point(1, 0);
            this.BorderTop.Name = "BorderTop";
            this.BorderTop.Size = new System.Drawing.Size(73, 1);
            this.BorderTop.TabIndex = 3;
            // 
            // BorderBottom
            // 
            this.BorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BorderBottom.Location = new System.Drawing.Point(1, 22);
            this.BorderBottom.Name = "BorderBottom";
            this.BorderBottom.Size = new System.Drawing.Size(73, 1);
            this.BorderBottom.TabIndex = 4;
            // 
            // TextLabel
            // 
            this.TextLabel.BackColor = System.Drawing.Color.Transparent;
            this.TextLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TextLabel.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TextLabel.Location = new System.Drawing.Point(1, 1);
            this.TextLabel.Name = "TextLabel";
            this.TextLabel.Size = new System.Drawing.Size(73, 21);
            this.TextLabel.TabIndex = 5;
            this.TextLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TextLabel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.TextLabel_MouseDown);
            this.TextLabel.MouseEnter += new System.EventHandler(this.TextLabel_MouseEnter);
            this.TextLabel.MouseLeave += new System.EventHandler(this.TextLabel_MouseLeave);
            this.TextLabel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.TextLabel_MouseUp);
            // 
            // CLUI_Button
            // 
            this.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.TextLabel);
            this.Controls.Add(this.BorderBottom);
            this.Controls.Add(this.BorderTop);
            this.Controls.Add(this.BorderLeft);
            this.Controls.Add(this.BorderRight);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.DimGray;
            this.Name = "CLUI_Button";
            this.Size = new System.Drawing.Size(75, 23);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BorderRight;
        private System.Windows.Forms.Panel BorderLeft;
        private System.Windows.Forms.Panel BorderTop;
        private System.Windows.Forms.Panel BorderBottom;
        public System.Windows.Forms.Label TextLabel;
    }
}
