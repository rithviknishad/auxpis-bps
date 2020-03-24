namespace AUXPIS_PS_CS
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.BorderBottom = new System.Windows.Forms.Panel();
            this.StatusLabel = new System.Windows.Forms.Label();
            this.TasksStatusButton = new Serial_Plotter.ui.CLUI_Button();
            this.BorderRight = new System.Windows.Forms.Panel();
            this.BorderLeft = new System.Windows.Forms.Panel();
            this.BorderTop = new System.Windows.Forms.Panel();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.TitleBar = new Serial_Plotter.ui.CLUI_TitleBar();
            this.BaseContainer = new System.Windows.Forms.SplitContainer();
            this.LeftHeaderSplitContainer = new System.Windows.Forms.SplitContainer();
            this.ConnectDeviceButton = new Serial_Plotter.ui.CLUI_HeadButton();
            this.DeviceMenuSplitContainer = new System.Windows.Forms.SplitContainer();
            this.NoDeviceLabel = new System.Windows.Forms.Label();
            this.PBoostLabel = new System.Windows.Forms.Label();
            this.IMaxLabel = new System.Windows.Forms.Label();
            this.VMaxLabel = new System.Windows.Forms.Label();
            this.NBoostLabel = new System.Windows.Forms.Label();
            this.EnergyLabel = new System.Windows.Forms.Label();
            this.PowerLabel = new System.Windows.Forms.Label();
            this.CurrentLabel = new System.Windows.Forms.Label();
            this.VoltageLabel = new System.Windows.Forms.Label();
            this.RightHeaderSplitContainer = new System.Windows.Forms.SplitContainer();
            this.BorderBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BaseContainer)).BeginInit();
            this.BaseContainer.Panel1.SuspendLayout();
            this.BaseContainer.Panel2.SuspendLayout();
            this.BaseContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LeftHeaderSplitContainer)).BeginInit();
            this.LeftHeaderSplitContainer.Panel1.SuspendLayout();
            this.LeftHeaderSplitContainer.Panel2.SuspendLayout();
            this.LeftHeaderSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMenuSplitContainer)).BeginInit();
            this.DeviceMenuSplitContainer.Panel1.SuspendLayout();
            this.DeviceMenuSplitContainer.Panel2.SuspendLayout();
            this.DeviceMenuSplitContainer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RightHeaderSplitContainer)).BeginInit();
            this.RightHeaderSplitContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // BorderBottom
            // 
            this.BorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderBottom.Controls.Add(this.StatusLabel);
            this.BorderBottom.Controls.Add(this.TasksStatusButton);
            this.BorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BorderBottom.Location = new System.Drawing.Point(1, 711);
            this.BorderBottom.Name = "BorderBottom";
            this.BorderBottom.Size = new System.Drawing.Size(1204, 23);
            this.BorderBottom.TabIndex = 11;
            // 
            // StatusLabel
            // 
            this.StatusLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.StatusLabel.ForeColor = System.Drawing.Color.White;
            this.StatusLabel.Location = new System.Drawing.Point(25, 0);
            this.StatusLabel.Name = "StatusLabel";
            this.StatusLabel.Size = new System.Drawing.Size(642, 23);
            this.StatusLabel.TabIndex = 8;
            this.StatusLabel.Text = "Ready";
            this.StatusLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // TasksStatusButton
            // 
            this.TasksStatusButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.TasksStatusButton.AutoEllipsis = false;
            this.TasksStatusButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TasksStatusButton.BackColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(149)))), ((int)(((byte)(214)))));
            this.TasksStatusButton.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(149)))), ((int)(((byte)(214)))));
            this.TasksStatusButton.BackColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TasksStatusButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.TasksStatusButton.BorderColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(149)))), ((int)(((byte)(214)))));
            this.TasksStatusButton.BorderColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(149)))), ((int)(((byte)(214)))));
            this.TasksStatusButton.BorderColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.TasksStatusButton.BorderWidth = 0;
            this.TasksStatusButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.TasksStatusButton.Dock = System.Windows.Forms.DockStyle.Left;
            this.TasksStatusButton.ForeColor = System.Drawing.Color.White;
            this.TasksStatusButton.ForeColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TasksStatusButton.ForeColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.TasksStatusButton.ForeColor_None = System.Drawing.Color.White;
            this.TasksStatusButton.Location = new System.Drawing.Point(0, 0);
            this.TasksStatusButton.Name = "TasksStatusButton";
            this.TasksStatusButton.Size = new System.Drawing.Size(23, 23);
            this.TasksStatusButton.TabIndex = 0;
            this.TasksStatusButton.Text = "▰";
            this.TasksStatusButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.TasksStatusButton.UseCustomColors = true;
            // 
            // BorderRight
            // 
            this.BorderRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.BorderRight.Location = new System.Drawing.Point(1205, 1);
            this.BorderRight.Name = "BorderRight";
            this.BorderRight.Size = new System.Drawing.Size(1, 733);
            this.BorderRight.TabIndex = 10;
            // 
            // BorderLeft
            // 
            this.BorderLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.BorderLeft.Location = new System.Drawing.Point(0, 1);
            this.BorderLeft.Name = "BorderLeft";
            this.BorderLeft.Size = new System.Drawing.Size(1, 733);
            this.BorderLeft.TabIndex = 9;
            // 
            // BorderTop
            // 
            this.BorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderTop.Location = new System.Drawing.Point(0, 0);
            this.BorderTop.Name = "BorderTop";
            this.BorderTop.Size = new System.Drawing.Size(1206, 1);
            this.BorderTop.TabIndex = 100;
            // 
            // TitleBar
            // 
            this.TitleBar.ActiveImage = null;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.TitleBar.BorderWidth = 1;
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBar.ForeColor = System.Drawing.Color.DarkGray;
            this.TitleBar.InactiveImage = null;
            this.TitleBar.Location = new System.Drawing.Point(1, 1);
            this.TitleBar.MenuStrip = null;
            this.TitleBar.MinimumSize = new System.Drawing.Size(304, 28);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.ShowCloseButton = true;
            this.TitleBar.ShowMaximizeButton = true;
            this.TitleBar.ShowMinimizeButton = true;
            this.TitleBar.Size = new System.Drawing.Size(1204, 28);
            this.TitleBar.TabIndex = 101;
            this.TitleBar.TitleAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // BaseContainer
            // 
            this.BaseContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.BaseContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BaseContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.BaseContainer.Location = new System.Drawing.Point(1, 29);
            this.BaseContainer.Name = "BaseContainer";
            // 
            // BaseContainer.Panel1
            // 
            this.BaseContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.BaseContainer.Panel1.Controls.Add(this.LeftHeaderSplitContainer);
            // 
            // BaseContainer.Panel2
            // 
            this.BaseContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.BaseContainer.Panel2.Controls.Add(this.RightHeaderSplitContainer);
            this.BaseContainer.Size = new System.Drawing.Size(1204, 682);
            this.BaseContainer.SplitterDistance = 320;
            this.BaseContainer.SplitterWidth = 1;
            this.BaseContainer.TabIndex = 102;
            // 
            // LeftHeaderSplitContainer
            // 
            this.LeftHeaderSplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.LeftHeaderSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LeftHeaderSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.LeftHeaderSplitContainer.IsSplitterFixed = true;
            this.LeftHeaderSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.LeftHeaderSplitContainer.Name = "LeftHeaderSplitContainer";
            this.LeftHeaderSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // LeftHeaderSplitContainer.Panel1
            // 
            this.LeftHeaderSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.LeftHeaderSplitContainer.Panel1.Controls.Add(this.ConnectDeviceButton);
            // 
            // LeftHeaderSplitContainer.Panel2
            // 
            this.LeftHeaderSplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.LeftHeaderSplitContainer.Panel2.Controls.Add(this.DeviceMenuSplitContainer);
            this.LeftHeaderSplitContainer.Size = new System.Drawing.Size(320, 682);
            this.LeftHeaderSplitContainer.SplitterDistance = 48;
            this.LeftHeaderSplitContainer.SplitterWidth = 2;
            this.LeftHeaderSplitContainer.TabIndex = 0;
            // 
            // ConnectDeviceButton
            // 
            this.ConnectDeviceButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.ConnectDeviceButton.BackColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.ConnectDeviceButton.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.ConnectDeviceButton.BackColor_Normal = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.ConnectDeviceButton.BorderWidth = 0;
            this.ConnectDeviceButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ConnectDeviceButton.Font1 = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDeviceButton.Font2 = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ConnectDeviceButton.Image_Down = ((System.Drawing.Image)(resources.GetObject("ConnectDeviceButton.Image_Down")));
            this.ConnectDeviceButton.Image_Hover = ((System.Drawing.Image)(resources.GetObject("ConnectDeviceButton.Image_Hover")));
            this.ConnectDeviceButton.Image_Normal = ((System.Drawing.Image)(resources.GetObject("ConnectDeviceButton.Image_Normal")));
            this.ConnectDeviceButton.ImageLocation = new System.Drawing.Point(15, 15);
            this.ConnectDeviceButton.ImageSize = new System.Drawing.Size(20, 6);
            this.ConnectDeviceButton.Location = new System.Drawing.Point(0, 0);
            this.ConnectDeviceButton.Name = "ConnectDeviceButton";
            this.ConnectDeviceButton.Size = new System.Drawing.Size(320, 48);
            this.ConnectDeviceButton.TabIndex = 0;
            this.ConnectDeviceButton.Text1 = "No Compatible Device Connected";
            this.ConnectDeviceButton.Text1Align = System.Drawing.ContentAlignment.BottomLeft;
            this.ConnectDeviceButton.Text1ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.ConnectDeviceButton.Text1Position = new System.Drawing.Point(51, 0);
            this.ConnectDeviceButton.Text2 = "Click to connect AUXPIS Power Supply";
            this.ConnectDeviceButton.Text2Align = System.Drawing.ContentAlignment.TopLeft;
            this.ConnectDeviceButton.Text2ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(207)))));
            this.ConnectDeviceButton.Text2Position = new System.Drawing.Point(51, 25);
            this.ConnectDeviceButton.Click += new System.EventHandler(this.ConnectDeviceButton_Click);
            // 
            // DeviceMenuSplitContainer
            // 
            this.DeviceMenuSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DeviceMenuSplitContainer.IsSplitterFixed = true;
            this.DeviceMenuSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.DeviceMenuSplitContainer.Name = "DeviceMenuSplitContainer";
            // 
            // DeviceMenuSplitContainer.Panel1
            // 
            this.DeviceMenuSplitContainer.Panel1.AutoScroll = true;
            this.DeviceMenuSplitContainer.Panel1.AutoScrollMargin = new System.Drawing.Size(0, 10);
            this.DeviceMenuSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(47)))), ((int)(((byte)(54)))), ((int)(((byte)(61)))));
            this.DeviceMenuSplitContainer.Panel1.Controls.Add(this.NoDeviceLabel);
            this.DeviceMenuSplitContainer.Panel1Collapsed = true;
            // 
            // DeviceMenuSplitContainer.Panel2
            // 
            this.DeviceMenuSplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.PBoostLabel);
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.IMaxLabel);
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.VMaxLabel);
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.NBoostLabel);
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.EnergyLabel);
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.PowerLabel);
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.CurrentLabel);
            this.DeviceMenuSplitContainer.Panel2.Controls.Add(this.VoltageLabel);
            this.DeviceMenuSplitContainer.Size = new System.Drawing.Size(320, 632);
            this.DeviceMenuSplitContainer.SplitterDistance = 160;
            this.DeviceMenuSplitContainer.SplitterWidth = 1;
            this.DeviceMenuSplitContainer.TabIndex = 0;
            // 
            // NoDeviceLabel
            // 
            this.NoDeviceLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NoDeviceLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(209)))), ((int)(((byte)(213)))), ((int)(((byte)(207)))));
            this.NoDeviceLabel.Location = new System.Drawing.Point(0, 0);
            this.NoDeviceLabel.Name = "NoDeviceLabel";
            this.NoDeviceLabel.Size = new System.Drawing.Size(160, 632);
            this.NoDeviceLabel.TabIndex = 0;
            this.NoDeviceLabel.Text = "No devices available";
            this.NoDeviceLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.NoDeviceLabel.Visible = false;
            // 
            // PBoostLabel
            // 
            this.PBoostLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBoostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.PBoostLabel.Location = new System.Drawing.Point(11, 550);
            this.PBoostLabel.Name = "PBoostLabel";
            this.PBoostLabel.Size = new System.Drawing.Size(290, 30);
            this.PBoostLabel.TabIndex = 9;
            this.PBoostLabel.Text = "P_BOOST:";
            this.PBoostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // IMaxLabel
            // 
            this.IMaxLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.IMaxLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.IMaxLabel.Location = new System.Drawing.Point(208, 85);
            this.IMaxLabel.Name = "IMaxLabel";
            this.IMaxLabel.Size = new System.Drawing.Size(107, 47);
            this.IMaxLabel.TabIndex = 8;
            this.IMaxLabel.Text = "--.-- A";
            this.IMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // VMaxLabel
            // 
            this.VMaxLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VMaxLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.VMaxLabel.Location = new System.Drawing.Point(208, 28);
            this.VMaxLabel.Name = "VMaxLabel";
            this.VMaxLabel.Size = new System.Drawing.Size(107, 47);
            this.VMaxLabel.TabIndex = 7;
            this.VMaxLabel.Text = "--.-- V";
            this.VMaxLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NBoostLabel
            // 
            this.NBoostLabel.Font = new System.Drawing.Font("Consolas", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NBoostLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.NBoostLabel.Location = new System.Drawing.Point(11, 580);
            this.NBoostLabel.Name = "NBoostLabel";
            this.NBoostLabel.Size = new System.Drawing.Size(290, 30);
            this.NBoostLabel.TabIndex = 6;
            this.NBoostLabel.Text = "N_BOOST: ";
            this.NBoostLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // EnergyLabel
            // 
            this.EnergyLabel.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnergyLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.EnergyLabel.Location = new System.Drawing.Point(5, 197);
            this.EnergyLabel.Name = "EnergyLabel";
            this.EnergyLabel.Size = new System.Drawing.Size(312, 37);
            this.EnergyLabel.TabIndex = 3;
            this.EnergyLabel.Text = "---- Wh";
            this.EnergyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PowerLabel
            // 
            this.PowerLabel.Font = new System.Drawing.Font("Consolas", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PowerLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(136)))), ((int)(((byte)(157)))), ((int)(((byte)(142)))));
            this.PowerLabel.Location = new System.Drawing.Point(5, 160);
            this.PowerLabel.Name = "PowerLabel";
            this.PowerLabel.Size = new System.Drawing.Size(312, 37);
            this.PowerLabel.TabIndex = 2;
            this.PowerLabel.Text = "--.--   W";
            this.PowerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CurrentLabel
            // 
            this.CurrentLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CurrentLabel.ForeColor = System.Drawing.Color.White;
            this.CurrentLabel.Location = new System.Drawing.Point(14, 85);
            this.CurrentLabel.Name = "CurrentLabel";
            this.CurrentLabel.Size = new System.Drawing.Size(301, 47);
            this.CurrentLabel.TabIndex = 1;
            this.CurrentLabel.Text = "--.--   A";
            this.CurrentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // VoltageLabel
            // 
            this.VoltageLabel.Font = new System.Drawing.Font("Consolas", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.VoltageLabel.ForeColor = System.Drawing.Color.White;
            this.VoltageLabel.Location = new System.Drawing.Point(16, 28);
            this.VoltageLabel.Name = "VoltageLabel";
            this.VoltageLabel.Size = new System.Drawing.Size(301, 47);
            this.VoltageLabel.TabIndex = 0;
            this.VoltageLabel.Text = "--.--   V";
            this.VoltageLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // RightHeaderSplitContainer
            // 
            this.RightHeaderSplitContainer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.RightHeaderSplitContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.RightHeaderSplitContainer.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.RightHeaderSplitContainer.IsSplitterFixed = true;
            this.RightHeaderSplitContainer.Location = new System.Drawing.Point(0, 0);
            this.RightHeaderSplitContainer.Name = "RightHeaderSplitContainer";
            this.RightHeaderSplitContainer.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // RightHeaderSplitContainer.Panel1
            // 
            this.RightHeaderSplitContainer.Panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            // 
            // RightHeaderSplitContainer.Panel2
            // 
            this.RightHeaderSplitContainer.Panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.RightHeaderSplitContainer.Size = new System.Drawing.Size(883, 682);
            this.RightHeaderSplitContainer.SplitterDistance = 48;
            this.RightHeaderSplitContainer.SplitterWidth = 2;
            this.RightHeaderSplitContainer.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.ClientSize = new System.Drawing.Size(1206, 734);
            this.Controls.Add(this.BaseContainer);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.BorderBottom);
            this.Controls.Add(this.BorderRight);
            this.Controls.Add(this.BorderLeft);
            this.Controls.Add(this.BorderTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUXPIS PS Control Software";
            this.SizeChanged += new System.EventHandler(this.Form1_SizeChanged);
            this.BorderBottom.ResumeLayout(false);
            this.BaseContainer.Panel1.ResumeLayout(false);
            this.BaseContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.BaseContainer)).EndInit();
            this.BaseContainer.ResumeLayout(false);
            this.LeftHeaderSplitContainer.Panel1.ResumeLayout(false);
            this.LeftHeaderSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LeftHeaderSplitContainer)).EndInit();
            this.LeftHeaderSplitContainer.ResumeLayout(false);
            this.DeviceMenuSplitContainer.Panel1.ResumeLayout(false);
            this.DeviceMenuSplitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DeviceMenuSplitContainer)).EndInit();
            this.DeviceMenuSplitContainer.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.RightHeaderSplitContainer)).EndInit();
            this.RightHeaderSplitContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel BorderBottom;
        private System.Windows.Forms.Label StatusLabel;
        private Serial_Plotter.ui.CLUI_Button TasksStatusButton;
        private System.Windows.Forms.Panel BorderRight;
        private System.Windows.Forms.Panel BorderLeft;
        private System.Windows.Forms.Panel BorderTop;
        private System.IO.Ports.SerialPort serialPort1;
        private Serial_Plotter.ui.CLUI_TitleBar TitleBar;
        private System.Windows.Forms.SplitContainer BaseContainer;
        private System.Windows.Forms.SplitContainer LeftHeaderSplitContainer;
        private Serial_Plotter.ui.CLUI_HeadButton ConnectDeviceButton;
        private System.Windows.Forms.SplitContainer DeviceMenuSplitContainer;
        private System.Windows.Forms.Label NoDeviceLabel;
        private System.Windows.Forms.SplitContainer RightHeaderSplitContainer;
        private System.Windows.Forms.Label VoltageLabel;
        private System.Windows.Forms.Label CurrentLabel;
        private System.Windows.Forms.Label EnergyLabel;
        private System.Windows.Forms.Label PowerLabel;
        private System.Windows.Forms.Label NBoostLabel;
        private System.Windows.Forms.Label IMaxLabel;
        private System.Windows.Forms.Label VMaxLabel;
        private System.Windows.Forms.Label PBoostLabel;
    }
}

