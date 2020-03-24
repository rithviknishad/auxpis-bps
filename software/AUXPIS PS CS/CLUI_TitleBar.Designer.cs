namespace Serial_Plotter.ui
{
    partial class CLUI_TitleBar
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
            this.BorderBottom = new System.Windows.Forms.Panel();
            this.WindowIcon = new System.Windows.Forms.PictureBox();
            this.WindowTitle = new System.Windows.Forms.Label();
            this.MinimizeButton = new Serial_Plotter.ui.CLUI_Button();
            this.WindowsStateToggleButton = new Serial_Plotter.ui.CLUI_Button();
            this.CloseButton = new Serial_Plotter.ui.CLUI_Button();
            ((System.ComponentModel.ISupportInitialize)(this.WindowIcon)).BeginInit();
            this.SuspendLayout();
            // 
            // BorderBottom
            // 
            this.BorderBottom.BackColor = System.Drawing.Color.Black;
            this.BorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BorderBottom.Location = new System.Drawing.Point(0, 27);
            this.BorderBottom.Name = "BorderBottom";
            this.BorderBottom.Size = new System.Drawing.Size(519, 1);
            this.BorderBottom.TabIndex = 5;
            // 
            // WindowIcon
            // 
            this.WindowIcon.Location = new System.Drawing.Point(5, 5);
            this.WindowIcon.Name = "WindowIcon";
            this.WindowIcon.Size = new System.Drawing.Size(18, 18);
            this.WindowIcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.WindowIcon.TabIndex = 6;
            this.WindowIcon.TabStop = false;
            this.WindowIcon.DoubleClick += new System.EventHandler(this.CloseButton_Click);
            // 
            // WindowTitle
            // 
            this.WindowTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.WindowTitle.AutoEllipsis = true;
            this.WindowTitle.Location = new System.Drawing.Point(29, 0);
            this.WindowTitle.Name = "WindowTitle";
            this.WindowTitle.Size = new System.Drawing.Size(352, 27);
            this.WindowTitle.TabIndex = 10;
            this.WindowTitle.Text = "<window_title>";
            this.WindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.WindowTitle.DoubleClick += new System.EventHandler(this.WindowsStateToggleButton_Click);
            this.WindowTitle.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            // 
            // MinimizeButton
            // 
            this.MinimizeButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.MinimizeButton.AutoEllipsis = false;
            this.MinimizeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.MinimizeButton.BackColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.MinimizeButton.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.MinimizeButton.BackColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.MinimizeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.MinimizeButton.BorderColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.MinimizeButton.BorderColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.MinimizeButton.BorderColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.MinimizeButton.BorderWidth = 0;
            this.MinimizeButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.MinimizeButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.MinimizeButton.ForeColor = System.Drawing.Color.DarkGray;
            this.MinimizeButton.ForeColor_Down = System.Drawing.Color.White;
            this.MinimizeButton.ForeColor_Hover = System.Drawing.Color.White;
            this.MinimizeButton.ForeColor_None = System.Drawing.Color.DarkGray;
            this.MinimizeButton.Location = new System.Drawing.Point(387, 0);
            this.MinimizeButton.Name = "MinimizeButton";
            this.MinimizeButton.Size = new System.Drawing.Size(44, 27);
            this.MinimizeButton.TabIndex = 13;
            this.MinimizeButton.Text = "▼";
            this.MinimizeButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.MinimizeButton.UseCustomColors = true;
            this.MinimizeButton.Click += new System.EventHandler(this.MinimizeButton_Click);
            // 
            // WindowsStateToggleButton
            // 
            this.WindowsStateToggleButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.WindowsStateToggleButton.AutoEllipsis = false;
            this.WindowsStateToggleButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.WindowsStateToggleButton.BackColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.WindowsStateToggleButton.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.WindowsStateToggleButton.BackColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.WindowsStateToggleButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.WindowsStateToggleButton.BorderColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.WindowsStateToggleButton.BorderColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(136)))), ((int)(((byte)(136)))));
            this.WindowsStateToggleButton.BorderColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.WindowsStateToggleButton.BorderWidth = 0;
            this.WindowsStateToggleButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.WindowsStateToggleButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.WindowsStateToggleButton.ForeColor = System.Drawing.Color.DarkGray;
            this.WindowsStateToggleButton.ForeColor_Down = System.Drawing.Color.White;
            this.WindowsStateToggleButton.ForeColor_Hover = System.Drawing.Color.White;
            this.WindowsStateToggleButton.ForeColor_None = System.Drawing.Color.DarkGray;
            this.WindowsStateToggleButton.Location = new System.Drawing.Point(431, 0);
            this.WindowsStateToggleButton.Name = "WindowsStateToggleButton";
            this.WindowsStateToggleButton.Size = new System.Drawing.Size(44, 27);
            this.WindowsStateToggleButton.TabIndex = 12;
            this.WindowsStateToggleButton.Text = "■";
            this.WindowsStateToggleButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.WindowsStateToggleButton.UseCustomColors = true;
            this.WindowsStateToggleButton.Click += new System.EventHandler(this.WindowsStateToggleButton_Click);
            // 
            // CloseButton
            // 
            this.CloseButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.CloseButton.AutoEllipsis = false;
            this.CloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.CloseButton.BackColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(15)))), ((int)(((byte)(29)))));
            this.CloseButton.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.CloseButton.BackColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.CloseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.CloseButton.BorderColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(15)))), ((int)(((byte)(29)))));
            this.CloseButton.BorderColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(17)))), ((int)(((byte)(35)))));
            this.CloseButton.BorderColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.CloseButton.BorderWidth = 0;
            this.CloseButton.DialogResult = System.Windows.Forms.DialogResult.Abort;
            this.CloseButton.Dock = System.Windows.Forms.DockStyle.Right;
            this.CloseButton.ForeColor = System.Drawing.Color.DarkGray;
            this.CloseButton.ForeColor_Down = System.Drawing.Color.DarkGray;
            this.CloseButton.ForeColor_Hover = System.Drawing.Color.White;
            this.CloseButton.ForeColor_None = System.Drawing.Color.White;
            this.CloseButton.Location = new System.Drawing.Point(475, 0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(44, 27);
            this.CloseButton.TabIndex = 11;
            this.CloseButton.Text = "✖";
            this.CloseButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.CloseButton.UseCustomColors = true;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // CLUI_TitleBar
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Controls.Add(this.MinimizeButton);
            this.Controls.Add(this.WindowsStateToggleButton);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.WindowTitle);
            this.Controls.Add(this.WindowIcon);
            this.Controls.Add(this.BorderBottom);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MinimumSize = new System.Drawing.Size(304, 28);
            this.Name = "CLUI_TitleBar";
            this.Size = new System.Drawing.Size(519, 28);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TitleBar_Paint);
            this.DoubleClick += new System.EventHandler(this.WindowsStateToggleButton_Click);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.TitleBar_MouseMove);
            ((System.ComponentModel.ISupportInitialize)(this.WindowIcon)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Panel BorderBottom;
        public System.Windows.Forms.PictureBox WindowIcon;
        public System.Windows.Forms.Label WindowTitle;
        private CLUI_Button CloseButton;
        private CLUI_Button WindowsStateToggleButton;
        private CLUI_Button MinimizeButton;
    }
}
