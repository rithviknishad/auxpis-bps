namespace AUXPIS_PS_CS
{
    partial class SerialPortConfgureWindow
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
            this.Label_ReadBufferSize = new System.Windows.Forms.Label();
            this.Label_WriteBufferSize = new System.Windows.Forms.Label();
            this.Input_WriteBufferSize = new System.Windows.Forms.NumericUpDown();
            this.Input_ReadBufferSize = new System.Windows.Forms.NumericUpDown();
            this.Label_BufferSize = new System.Windows.Forms.Label();
            this.Label_ReadTimeout = new System.Windows.Forms.Label();
            this.Label_StopBits = new System.Windows.Forms.Label();
            this.Input_StopBits = new System.Windows.Forms.ComboBox();
            this.Input_ReceiveThreshold = new System.Windows.Forms.NumericUpDown();
            this.Label_ReceiveThreshold = new System.Windows.Forms.Label();
            this.Label_WriteTimeout = new System.Windows.Forms.Label();
            this.Input_WriteTimeout = new System.Windows.Forms.NumericUpDown();
            this.Input_ReadTimeout = new System.Windows.Forms.NumericUpDown();
            this.Label_Timeout = new System.Windows.Forms.Label();
            this.Label_RtsEnable = new System.Windows.Forms.Label();
            this.Input_RtsEnable = new System.Windows.Forms.ComboBox();
            this.Label_Parity = new System.Windows.Forms.Label();
            this.Input_Parity = new System.Windows.Forms.ComboBox();
            this.Label_Handshake = new System.Windows.Forms.Label();
            this.Input_Handshake = new System.Windows.Forms.ComboBox();
            this.Label_DtrEnable = new System.Windows.Forms.Label();
            this.Input_DtrEnable = new System.Windows.Forms.ComboBox();
            this.Label_DiscardNull = new System.Windows.Forms.Label();
            this.Input_DiscardNull = new System.Windows.Forms.ComboBox();
            this.Label_DataBits = new System.Windows.Forms.Label();
            this.Input_DataBits = new System.Windows.Forms.NumericUpDown();
            this.TitleBar = new Serial_Plotter.ui.CLUI_TitleBar();
            this.Label_BaudRate = new System.Windows.Forms.Label();
            this.Label_PortName = new System.Windows.Forms.Label();
            this.Input_DeviceName = new System.Windows.Forms.TextBox();
            this.Input_BaudRate = new System.Windows.Forms.ComboBox();
            this.BorderBottom = new System.Windows.Forms.Panel();
            this.BorderTop = new System.Windows.Forms.Panel();
            this.BorderLeft = new System.Windows.Forms.Panel();
            this.BorderRight = new System.Windows.Forms.Panel();
            this.DetachButton = new Serial_Plotter.ui.CLUI_Button();
            this.LinkButton = new Serial_Plotter.ui.CLUI_Button();
            ((System.ComponentModel.ISupportInitialize)(this.Input_WriteBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_ReadBufferSize)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_ReceiveThreshold)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_WriteTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_ReadTimeout)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_DataBits)).BeginInit();
            this.SuspendLayout();
            // 
            // Label_ReadBufferSize
            // 
            this.Label_ReadBufferSize.AutoSize = true;
            this.Label_ReadBufferSize.Location = new System.Drawing.Point(139, 263);
            this.Label_ReadBufferSize.Name = "Label_ReadBufferSize";
            this.Label_ReadBufferSize.Size = new System.Drawing.Size(33, 15);
            this.Label_ReadBufferSize.TabIndex = 79;
            this.Label_ReadBufferSize.Text = "Read";
            // 
            // Label_WriteBufferSize
            // 
            this.Label_WriteBufferSize.AutoSize = true;
            this.Label_WriteBufferSize.Location = new System.Drawing.Point(258, 263);
            this.Label_WriteBufferSize.Name = "Label_WriteBufferSize";
            this.Label_WriteBufferSize.Size = new System.Drawing.Size(35, 15);
            this.Label_WriteBufferSize.TabIndex = 78;
            this.Label_WriteBufferSize.Text = "Write";
            // 
            // Input_WriteBufferSize
            // 
            this.Input_WriteBufferSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_WriteBufferSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_WriteBufferSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Input_WriteBufferSize.Location = new System.Drawing.Point(303, 261);
            this.Input_WriteBufferSize.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Input_WriteBufferSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.Input_WriteBufferSize.Name = "Input_WriteBufferSize";
            this.Input_WriteBufferSize.Size = new System.Drawing.Size(58, 23);
            this.Input_WriteBufferSize.TabIndex = 77;
            this.Input_WriteBufferSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // Input_ReadBufferSize
            // 
            this.Input_ReadBufferSize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_ReadBufferSize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_ReadBufferSize.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Input_ReadBufferSize.Location = new System.Drawing.Point(182, 261);
            this.Input_ReadBufferSize.Maximum = new decimal(new int[] {
            65535,
            0,
            0,
            0});
            this.Input_ReadBufferSize.Minimum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.Input_ReadBufferSize.Name = "Input_ReadBufferSize";
            this.Input_ReadBufferSize.Size = new System.Drawing.Size(58, 23);
            this.Input_ReadBufferSize.TabIndex = 76;
            this.Input_ReadBufferSize.Value = new decimal(new int[] {
            16,
            0,
            0,
            0});
            // 
            // Label_BufferSize
            // 
            this.Label_BufferSize.AutoSize = true;
            this.Label_BufferSize.Location = new System.Drawing.Point(22, 263);
            this.Label_BufferSize.Name = "Label_BufferSize";
            this.Label_BufferSize.Size = new System.Drawing.Size(62, 15);
            this.Label_BufferSize.TabIndex = 75;
            this.Label_BufferSize.Text = "Buffer Size";
            // 
            // Label_ReadTimeout
            // 
            this.Label_ReadTimeout.AutoSize = true;
            this.Label_ReadTimeout.Location = new System.Drawing.Point(139, 224);
            this.Label_ReadTimeout.Name = "Label_ReadTimeout";
            this.Label_ReadTimeout.Size = new System.Drawing.Size(33, 15);
            this.Label_ReadTimeout.TabIndex = 74;
            this.Label_ReadTimeout.Text = "Read";
            // 
            // Label_StopBits
            // 
            this.Label_StopBits.AutoSize = true;
            this.Label_StopBits.Location = new System.Drawing.Point(432, 225);
            this.Label_StopBits.Name = "Label_StopBits";
            this.Label_StopBits.Size = new System.Drawing.Size(53, 15);
            this.Label_StopBits.TabIndex = 73;
            this.Label_StopBits.Text = "Stop Bits";
            // 
            // Input_StopBits
            // 
            this.Input_StopBits.AutoCompleteCustomSource.AddRange(new string[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.Input_StopBits.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Input_StopBits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_StopBits.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Input_StopBits.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input_StopBits.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_StopBits.ForeColor = System.Drawing.Color.White;
            this.Input_StopBits.FormatString = "N0";
            this.Input_StopBits.FormattingEnabled = true;
            this.Input_StopBits.Items.AddRange(new object[] {
            "None",
            "One",
            "Two",
            "OnePointFive"});
            this.Input_StopBits.Location = new System.Drawing.Point(576, 222);
            this.Input_StopBits.Name = "Input_StopBits";
            this.Input_StopBits.Size = new System.Drawing.Size(141, 23);
            this.Input_StopBits.TabIndex = 72;
            // 
            // Input_ReceiveThreshold
            // 
            this.Input_ReceiveThreshold.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_ReceiveThreshold.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_ReceiveThreshold.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Input_ReceiveThreshold.Location = new System.Drawing.Point(576, 261);
            this.Input_ReceiveThreshold.Maximum = new decimal(new int[] {
            8192,
            0,
            0,
            0});
            this.Input_ReceiveThreshold.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.Input_ReceiveThreshold.Name = "Input_ReceiveThreshold";
            this.Input_ReceiveThreshold.Size = new System.Drawing.Size(77, 23);
            this.Input_ReceiveThreshold.TabIndex = 71;
            this.Input_ReceiveThreshold.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // Label_ReceiveThreshold
            // 
            this.Label_ReceiveThreshold.AutoSize = true;
            this.Label_ReceiveThreshold.Location = new System.Drawing.Point(432, 263);
            this.Label_ReceiveThreshold.Name = "Label_ReceiveThreshold";
            this.Label_ReceiveThreshold.Size = new System.Drawing.Size(102, 15);
            this.Label_ReceiveThreshold.TabIndex = 70;
            this.Label_ReceiveThreshold.Text = "Receive Threshold";
            // 
            // Label_WriteTimeout
            // 
            this.Label_WriteTimeout.AutoSize = true;
            this.Label_WriteTimeout.Location = new System.Drawing.Point(258, 224);
            this.Label_WriteTimeout.Name = "Label_WriteTimeout";
            this.Label_WriteTimeout.Size = new System.Drawing.Size(35, 15);
            this.Label_WriteTimeout.TabIndex = 69;
            this.Label_WriteTimeout.Text = "Write";
            // 
            // Input_WriteTimeout
            // 
            this.Input_WriteTimeout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_WriteTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_WriteTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Input_WriteTimeout.Location = new System.Drawing.Point(303, 222);
            this.Input_WriteTimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Input_WriteTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Input_WriteTimeout.Name = "Input_WriteTimeout";
            this.Input_WriteTimeout.Size = new System.Drawing.Size(58, 23);
            this.Input_WriteTimeout.TabIndex = 68;
            this.Input_WriteTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // Input_ReadTimeout
            // 
            this.Input_ReadTimeout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_ReadTimeout.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_ReadTimeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Input_ReadTimeout.Location = new System.Drawing.Point(182, 222);
            this.Input_ReadTimeout.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
            this.Input_ReadTimeout.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            this.Input_ReadTimeout.Name = "Input_ReadTimeout";
            this.Input_ReadTimeout.Size = new System.Drawing.Size(58, 23);
            this.Input_ReadTimeout.TabIndex = 67;
            this.Input_ReadTimeout.Value = new decimal(new int[] {
            1,
            0,
            0,
            -2147483648});
            // 
            // Label_Timeout
            // 
            this.Label_Timeout.AutoSize = true;
            this.Label_Timeout.Location = new System.Drawing.Point(22, 224);
            this.Label_Timeout.Name = "Label_Timeout";
            this.Label_Timeout.Size = new System.Drawing.Size(51, 15);
            this.Label_Timeout.TabIndex = 66;
            this.Label_Timeout.Text = "Timeout";
            // 
            // Label_RtsEnable
            // 
            this.Label_RtsEnable.AutoSize = true;
            this.Label_RtsEnable.Location = new System.Drawing.Point(432, 186);
            this.Label_RtsEnable.Name = "Label_RtsEnable";
            this.Label_RtsEnable.Size = new System.Drawing.Size(93, 15);
            this.Label_RtsEnable.TabIndex = 65;
            this.Label_RtsEnable.Text = "Request To Send";
            // 
            // Input_RtsEnable
            // 
            this.Input_RtsEnable.AutoCompleteCustomSource.AddRange(new string[] {
            "False",
            "True"});
            this.Input_RtsEnable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Input_RtsEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_RtsEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Input_RtsEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input_RtsEnable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_RtsEnable.ForeColor = System.Drawing.Color.White;
            this.Input_RtsEnable.FormatString = "N0";
            this.Input_RtsEnable.FormattingEnabled = true;
            this.Input_RtsEnable.Items.AddRange(new object[] {
            "False",
            "True"});
            this.Input_RtsEnable.Location = new System.Drawing.Point(576, 183);
            this.Input_RtsEnable.Name = "Input_RtsEnable";
            this.Input_RtsEnable.Size = new System.Drawing.Size(141, 23);
            this.Input_RtsEnable.TabIndex = 64;
            // 
            // Label_Parity
            // 
            this.Label_Parity.AutoSize = true;
            this.Label_Parity.Location = new System.Drawing.Point(432, 147);
            this.Label_Parity.Name = "Label_Parity";
            this.Label_Parity.Size = new System.Drawing.Size(37, 15);
            this.Label_Parity.TabIndex = 63;
            this.Label_Parity.Text = "Parity";
            // 
            // Input_Parity
            // 
            this.Input_Parity.AutoCompleteCustomSource.AddRange(new string[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.Input_Parity.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Input_Parity.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_Parity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Input_Parity.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input_Parity.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Parity.ForeColor = System.Drawing.Color.White;
            this.Input_Parity.FormatString = "N0";
            this.Input_Parity.FormattingEnabled = true;
            this.Input_Parity.Items.AddRange(new object[] {
            "None",
            "Odd",
            "Even",
            "Mark",
            "Space"});
            this.Input_Parity.Location = new System.Drawing.Point(576, 144);
            this.Input_Parity.Name = "Input_Parity";
            this.Input_Parity.Size = new System.Drawing.Size(141, 23);
            this.Input_Parity.TabIndex = 62;
            // 
            // Label_Handshake
            // 
            this.Label_Handshake.AutoSize = true;
            this.Label_Handshake.Location = new System.Drawing.Point(22, 186);
            this.Label_Handshake.Name = "Label_Handshake";
            this.Label_Handshake.Size = new System.Drawing.Size(66, 15);
            this.Label_Handshake.TabIndex = 61;
            this.Label_Handshake.Text = "Handshake";
            // 
            // Input_Handshake
            // 
            this.Input_Handshake.AutoCompleteCustomSource.AddRange(new string[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.Input_Handshake.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Input_Handshake.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_Handshake.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Input_Handshake.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input_Handshake.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_Handshake.ForeColor = System.Drawing.Color.White;
            this.Input_Handshake.FormatString = "N0";
            this.Input_Handshake.FormattingEnabled = true;
            this.Input_Handshake.Items.AddRange(new object[] {
            "None",
            "XOnXOff",
            "RequestToSend",
            "RequestToSendXOnXOff"});
            this.Input_Handshake.Location = new System.Drawing.Point(142, 183);
            this.Input_Handshake.Name = "Input_Handshake";
            this.Input_Handshake.Size = new System.Drawing.Size(219, 23);
            this.Input_Handshake.TabIndex = 60;
            // 
            // Label_DtrEnable
            // 
            this.Label_DtrEnable.AutoSize = true;
            this.Label_DtrEnable.Location = new System.Drawing.Point(432, 108);
            this.Label_DtrEnable.Name = "Label_DtrEnable";
            this.Label_DtrEnable.Size = new System.Drawing.Size(114, 15);
            this.Label_DtrEnable.TabIndex = 59;
            this.Label_DtrEnable.Text = "Data Terminal Ready";
            // 
            // Input_DtrEnable
            // 
            this.Input_DtrEnable.AutoCompleteCustomSource.AddRange(new string[] {
            "False",
            "True"});
            this.Input_DtrEnable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Input_DtrEnable.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_DtrEnable.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Input_DtrEnable.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input_DtrEnable.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_DtrEnable.ForeColor = System.Drawing.Color.White;
            this.Input_DtrEnable.FormatString = "N0";
            this.Input_DtrEnable.FormattingEnabled = true;
            this.Input_DtrEnable.Items.AddRange(new object[] {
            "False",
            "True"});
            this.Input_DtrEnable.Location = new System.Drawing.Point(576, 105);
            this.Input_DtrEnable.Name = "Input_DtrEnable";
            this.Input_DtrEnable.Size = new System.Drawing.Size(141, 23);
            this.Input_DtrEnable.TabIndex = 58;
            // 
            // Label_DiscardNull
            // 
            this.Label_DiscardNull.AutoSize = true;
            this.Label_DiscardNull.Location = new System.Drawing.Point(432, 68);
            this.Label_DiscardNull.Name = "Label_DiscardNull";
            this.Label_DiscardNull.Size = new System.Drawing.Size(71, 15);
            this.Label_DiscardNull.TabIndex = 57;
            this.Label_DiscardNull.Text = "Discard Null";
            // 
            // Input_DiscardNull
            // 
            this.Input_DiscardNull.AutoCompleteCustomSource.AddRange(new string[] {
            "False",
            "True"});
            this.Input_DiscardNull.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Input_DiscardNull.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_DiscardNull.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Input_DiscardNull.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input_DiscardNull.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_DiscardNull.ForeColor = System.Drawing.Color.White;
            this.Input_DiscardNull.FormatString = "N0";
            this.Input_DiscardNull.FormattingEnabled = true;
            this.Input_DiscardNull.Items.AddRange(new object[] {
            "False",
            "True"});
            this.Input_DiscardNull.Location = new System.Drawing.Point(576, 65);
            this.Input_DiscardNull.Name = "Input_DiscardNull";
            this.Input_DiscardNull.Size = new System.Drawing.Size(141, 23);
            this.Input_DiscardNull.TabIndex = 56;
            // 
            // Label_DataBits
            // 
            this.Label_DataBits.AutoSize = true;
            this.Label_DataBits.Location = new System.Drawing.Point(22, 146);
            this.Label_DataBits.Name = "Label_DataBits";
            this.Label_DataBits.Size = new System.Drawing.Size(53, 15);
            this.Label_DataBits.TabIndex = 55;
            this.Label_DataBits.Text = "Data Bits";
            // 
            // Input_DataBits
            // 
            this.Input_DataBits.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_DataBits.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_DataBits.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Input_DataBits.Location = new System.Drawing.Point(142, 144);
            this.Input_DataBits.Maximum = new decimal(new int[] {
            256,
            0,
            0,
            0});
            this.Input_DataBits.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.Input_DataBits.Name = "Input_DataBits";
            this.Input_DataBits.Size = new System.Drawing.Size(58, 23);
            this.Input_DataBits.TabIndex = 54;
            this.Input_DataBits.Value = new decimal(new int[] {
            8,
            0,
            0,
            0});
            // 
            // TitleBar
            // 
            this.TitleBar.ActiveImage = null;
            this.TitleBar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.TitleBar.BorderWidth = 0;
            this.TitleBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.TitleBar.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TitleBar.ForeColor = System.Drawing.Color.White;
            this.TitleBar.InactiveImage = null;
            this.TitleBar.Location = new System.Drawing.Point(1, 1);
            this.TitleBar.MenuStrip = null;
            this.TitleBar.MinimumSize = new System.Drawing.Size(304, 28);
            this.TitleBar.Name = "TitleBar";
            this.TitleBar.ShowCloseButton = true;
            this.TitleBar.ShowMaximizeButton = false;
            this.TitleBar.ShowMinimizeButton = false;
            this.TitleBar.Size = new System.Drawing.Size(774, 28);
            this.TitleBar.TabIndex = 53;
            this.TitleBar.TitleAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Label_BaudRate
            // 
            this.Label_BaudRate.AutoSize = true;
            this.Label_BaudRate.Location = new System.Drawing.Point(22, 108);
            this.Label_BaudRate.Name = "Label_BaudRate";
            this.Label_BaudRate.Size = new System.Drawing.Size(60, 15);
            this.Label_BaudRate.TabIndex = 52;
            this.Label_BaudRate.Text = "Baud Rate";
            // 
            // Label_PortName
            // 
            this.Label_PortName.AutoSize = true;
            this.Label_PortName.Location = new System.Drawing.Point(22, 68);
            this.Label_PortName.Name = "Label_PortName";
            this.Label_PortName.Size = new System.Drawing.Size(77, 15);
            this.Label_PortName.TabIndex = 51;
            this.Label_PortName.Text = "Device Name";
            // 
            // Input_DeviceName
            // 
            this.Input_DeviceName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_DeviceName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Input_DeviceName.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_DeviceName.ForeColor = System.Drawing.Color.White;
            this.Input_DeviceName.Location = new System.Drawing.Point(142, 66);
            this.Input_DeviceName.MaxLength = 60;
            this.Input_DeviceName.Name = "Input_DeviceName";
            this.Input_DeviceName.Size = new System.Drawing.Size(219, 23);
            this.Input_DeviceName.TabIndex = 50;
            // 
            // Input_BaudRate
            // 
            this.Input_BaudRate.AutoCompleteCustomSource.AddRange(new string[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000",
            "500000",
            "1000000",
            "2000000"});
            this.Input_BaudRate.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.Input_BaudRate.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(41)))), ((int)(((byte)(46)))));
            this.Input_BaudRate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Input_BaudRate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Input_BaudRate.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Input_BaudRate.ForeColor = System.Drawing.Color.White;
            this.Input_BaudRate.FormatString = "N0";
            this.Input_BaudRate.FormattingEnabled = true;
            this.Input_BaudRate.Items.AddRange(new object[] {
            "300",
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "74880",
            "115200",
            "230400",
            "250000",
            "500000",
            "1000000",
            "2000000"});
            this.Input_BaudRate.Location = new System.Drawing.Point(142, 105);
            this.Input_BaudRate.Name = "Input_BaudRate";
            this.Input_BaudRate.Size = new System.Drawing.Size(219, 23);
            this.Input_BaudRate.TabIndex = 49;
            // 
            // BorderBottom
            // 
            this.BorderBottom.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BorderBottom.Location = new System.Drawing.Point(1, 374);
            this.BorderBottom.Name = "BorderBottom";
            this.BorderBottom.Size = new System.Drawing.Size(774, 1);
            this.BorderBottom.TabIndex = 48;
            // 
            // BorderTop
            // 
            this.BorderTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.BorderTop.Location = new System.Drawing.Point(1, 0);
            this.BorderTop.Name = "BorderTop";
            this.BorderTop.Size = new System.Drawing.Size(774, 1);
            this.BorderTop.TabIndex = 47;
            // 
            // BorderLeft
            // 
            this.BorderLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.BorderLeft.Location = new System.Drawing.Point(0, 0);
            this.BorderLeft.Name = "BorderLeft";
            this.BorderLeft.Size = new System.Drawing.Size(1, 375);
            this.BorderLeft.TabIndex = 46;
            // 
            // BorderRight
            // 
            this.BorderRight.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(122)))), ((int)(((byte)(204)))));
            this.BorderRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.BorderRight.Location = new System.Drawing.Point(775, 0);
            this.BorderRight.Name = "BorderRight";
            this.BorderRight.Size = new System.Drawing.Size(1, 375);
            this.BorderRight.TabIndex = 45;
            // 
            // DetachButton
            // 
            this.DetachButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.DetachButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.DetachButton.AutoEllipsis = false;
            this.DetachButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(99)))), ((int)(((byte)(12)))));
            this.DetachButton.BackColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(61)))));
            this.DetachButton.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(115)))), ((int)(((byte)(37)))));
            this.DetachButton.BackColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(99)))), ((int)(((byte)(12)))));
            this.DetachButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.DetachButton.BorderColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(249)))), ((int)(((byte)(130)))), ((int)(((byte)(61)))));
            this.DetachButton.BorderColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(115)))), ((int)(((byte)(37)))));
            this.DetachButton.BorderColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(247)))), ((int)(((byte)(99)))), ((int)(((byte)(12)))));
            this.DetachButton.BorderWidth = 1;
            this.DetachButton.DialogResult = System.Windows.Forms.DialogResult.None;
            this.DetachButton.ForeColor = System.Drawing.Color.White;
            this.DetachButton.ForeColor_Down = System.Drawing.Color.White;
            this.DetachButton.ForeColor_Hover = System.Drawing.Color.White;
            this.DetachButton.ForeColor_None = System.Drawing.Color.White;
            this.DetachButton.Location = new System.Drawing.Point(644, 333);
            this.DetachButton.Name = "DetachButton";
            this.DetachButton.Size = new System.Drawing.Size(120, 30);
            this.DetachButton.TabIndex = 44;
            this.DetachButton.Text = "DETACH";
            this.DetachButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.DetachButton.UseCustomColors = true;
            // 
            // LinkButton
            // 
            this.LinkButton.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.LinkButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.LinkButton.AutoEllipsis = false;
            this.LinkButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(102)))), ((int)(((byte)(214)))));
            this.LinkButton.BackColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(114)))), ((int)(((byte)(239)))));
            this.LinkButton.BackColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(114)))), ((int)(((byte)(239)))));
            this.LinkButton.BackColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(102)))), ((int)(((byte)(214)))));
            this.LinkButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.LinkButton.BorderColor_Down = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(102)))), ((int)(((byte)(214)))));
            this.LinkButton.BorderColor_Hover = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(114)))), ((int)(((byte)(239)))));
            this.LinkButton.BorderColor_None = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(102)))), ((int)(((byte)(214)))));
            this.LinkButton.BorderWidth = 1;
            this.LinkButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.LinkButton.ForeColor = System.Drawing.Color.White;
            this.LinkButton.ForeColor_Down = System.Drawing.Color.White;
            this.LinkButton.ForeColor_Hover = System.Drawing.Color.White;
            this.LinkButton.ForeColor_None = System.Drawing.Color.White;
            this.LinkButton.Location = new System.Drawing.Point(506, 333);
            this.LinkButton.Name = "LinkButton";
            this.LinkButton.Size = new System.Drawing.Size(120, 30);
            this.LinkButton.TabIndex = 43;
            this.LinkButton.Text = "UPDATE";
            this.LinkButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LinkButton.UseCustomColors = true;
            // 
            // SerialPortConfgureWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(33)))), ((int)(((byte)(37)))));
            this.ClientSize = new System.Drawing.Size(776, 375);
            this.Controls.Add(this.Label_ReadBufferSize);
            this.Controls.Add(this.Label_WriteBufferSize);
            this.Controls.Add(this.Input_WriteBufferSize);
            this.Controls.Add(this.Input_ReadBufferSize);
            this.Controls.Add(this.Label_BufferSize);
            this.Controls.Add(this.Label_ReadTimeout);
            this.Controls.Add(this.Label_StopBits);
            this.Controls.Add(this.Input_StopBits);
            this.Controls.Add(this.Input_ReceiveThreshold);
            this.Controls.Add(this.Label_ReceiveThreshold);
            this.Controls.Add(this.Label_WriteTimeout);
            this.Controls.Add(this.Input_WriteTimeout);
            this.Controls.Add(this.Input_ReadTimeout);
            this.Controls.Add(this.Label_Timeout);
            this.Controls.Add(this.Label_RtsEnable);
            this.Controls.Add(this.Input_RtsEnable);
            this.Controls.Add(this.Label_Parity);
            this.Controls.Add(this.Input_Parity);
            this.Controls.Add(this.Label_Handshake);
            this.Controls.Add(this.Input_Handshake);
            this.Controls.Add(this.Label_DtrEnable);
            this.Controls.Add(this.Input_DtrEnable);
            this.Controls.Add(this.Label_DiscardNull);
            this.Controls.Add(this.Input_DiscardNull);
            this.Controls.Add(this.Label_DataBits);
            this.Controls.Add(this.Input_DataBits);
            this.Controls.Add(this.TitleBar);
            this.Controls.Add(this.Label_BaudRate);
            this.Controls.Add(this.Label_PortName);
            this.Controls.Add(this.Input_DeviceName);
            this.Controls.Add(this.Input_BaudRate);
            this.Controls.Add(this.BorderBottom);
            this.Controls.Add(this.BorderTop);
            this.Controls.Add(this.BorderLeft);
            this.Controls.Add(this.BorderRight);
            this.Controls.Add(this.DetachButton);
            this.Controls.Add(this.LinkButton);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.Color.White;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SerialPortConfgureWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "SerialPortConfgureWindow";
            ((System.ComponentModel.ISupportInitialize)(this.Input_WriteBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_ReadBufferSize)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_ReceiveThreshold)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_WriteTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_ReadTimeout)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Input_DataBits)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label Label_ReadBufferSize;
        private System.Windows.Forms.Label Label_WriteBufferSize;
        private System.Windows.Forms.NumericUpDown Input_WriteBufferSize;
        private System.Windows.Forms.NumericUpDown Input_ReadBufferSize;
        private System.Windows.Forms.Label Label_BufferSize;
        private System.Windows.Forms.Label Label_ReadTimeout;
        private System.Windows.Forms.Label Label_StopBits;
        private System.Windows.Forms.ComboBox Input_StopBits;
        private System.Windows.Forms.NumericUpDown Input_ReceiveThreshold;
        private System.Windows.Forms.Label Label_ReceiveThreshold;
        private System.Windows.Forms.Label Label_WriteTimeout;
        private System.Windows.Forms.NumericUpDown Input_WriteTimeout;
        private System.Windows.Forms.NumericUpDown Input_ReadTimeout;
        private System.Windows.Forms.Label Label_Timeout;
        private System.Windows.Forms.Label Label_RtsEnable;
        private System.Windows.Forms.ComboBox Input_RtsEnable;
        private System.Windows.Forms.Label Label_Parity;
        private System.Windows.Forms.ComboBox Input_Parity;
        private System.Windows.Forms.Label Label_Handshake;
        private System.Windows.Forms.ComboBox Input_Handshake;
        private System.Windows.Forms.Label Label_DtrEnable;
        private System.Windows.Forms.ComboBox Input_DtrEnable;
        private System.Windows.Forms.Label Label_DiscardNull;
        private System.Windows.Forms.ComboBox Input_DiscardNull;
        private System.Windows.Forms.Label Label_DataBits;
        private System.Windows.Forms.NumericUpDown Input_DataBits;
        private Serial_Plotter.ui.CLUI_TitleBar TitleBar;
        private System.Windows.Forms.Label Label_BaudRate;
        private System.Windows.Forms.Label Label_PortName;
        private System.Windows.Forms.TextBox Input_DeviceName;
        private System.Windows.Forms.ComboBox Input_BaudRate;
        private System.Windows.Forms.Panel BorderBottom;
        private System.Windows.Forms.Panel BorderTop;
        private System.Windows.Forms.Panel BorderLeft;
        private System.Windows.Forms.Panel BorderRight;
        private Serial_Plotter.ui.CLUI_Button DetachButton;
        private Serial_Plotter.ui.CLUI_Button LinkButton;
    }
}