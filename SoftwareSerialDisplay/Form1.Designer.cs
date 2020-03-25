namespace SoftwareSerialDisplay
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
            this.SerialPortComboBox = new System.Windows.Forms.ComboBox();
            this.SelectSerialPortLabel = new System.Windows.Forms.Label();
            this.SerialRefreshButton = new System.Windows.Forms.Button();
            this.SerialConnectButton = new System.Windows.Forms.Button();
            this.BaudRateTextbox = new System.Windows.Forms.TextBox();
            this.MySerialPort = new System.IO.Ports.SerialPort(this.components);
            this.ReadTimer = new System.Windows.Forms.Timer(this.components);
            this.SerialLog = new System.Windows.Forms.RichTextBox();
            this.InputVoltageLabel = new System.Windows.Forms.Label();
            this.SystemUptimeLabel = new System.Windows.Forms.Label();
            this.OPVoltageLabel = new System.Windows.Forms.Label();
            this.MaxOPVoltageLabel = new System.Windows.Forms.Label();
            this.OPCurrentLabel = new System.Windows.Forms.Label();
            this.MaxOPCurrentLabel = new System.Windows.Forms.Label();
            this.OPEnergyLabel = new System.Windows.Forms.Label();
            this.OPPowerLabel = new System.Windows.Forms.Label();
            this.VNBLabel = new System.Windows.Forms.Label();
            this.VPBLabel = new System.Windows.Forms.Label();
            this.SRBLabel = new System.Windows.Forms.Label();
            this.GatePWMLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // SerialPortComboBox
            // 
            this.SerialPortComboBox.FormattingEnabled = true;
            this.SerialPortComboBox.Location = new System.Drawing.Point(112, 12);
            this.SerialPortComboBox.Name = "SerialPortComboBox";
            this.SerialPortComboBox.Size = new System.Drawing.Size(123, 21);
            this.SerialPortComboBox.TabIndex = 0;
            // 
            // SelectSerialPortLabel
            // 
            this.SelectSerialPortLabel.AutoSize = true;
            this.SelectSerialPortLabel.Location = new System.Drawing.Point(15, 15);
            this.SelectSerialPortLabel.Name = "SelectSerialPortLabel";
            this.SelectSerialPortLabel.Size = new System.Drawing.Size(91, 13);
            this.SelectSerialPortLabel.TabIndex = 1;
            this.SelectSerialPortLabel.Text = "Select Serial Port:";
            // 
            // SerialRefreshButton
            // 
            this.SerialRefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SerialRefreshButton.Location = new System.Drawing.Point(302, 10);
            this.SerialRefreshButton.Name = "SerialRefreshButton";
            this.SerialRefreshButton.Size = new System.Drawing.Size(75, 23);
            this.SerialRefreshButton.TabIndex = 2;
            this.SerialRefreshButton.Text = "Refresh";
            this.SerialRefreshButton.UseVisualStyleBackColor = true;
            this.SerialRefreshButton.Click += new System.EventHandler(this.SerialRefreshButton_Click);
            // 
            // SerialConnectButton
            // 
            this.SerialConnectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.SerialConnectButton.Location = new System.Drawing.Point(383, 10);
            this.SerialConnectButton.Name = "SerialConnectButton";
            this.SerialConnectButton.Size = new System.Drawing.Size(75, 23);
            this.SerialConnectButton.TabIndex = 3;
            this.SerialConnectButton.Text = "Connect";
            this.SerialConnectButton.UseVisualStyleBackColor = true;
            this.SerialConnectButton.Click += new System.EventHandler(this.SerialConnectButton_Click);
            // 
            // BaudRateTextbox
            // 
            this.BaudRateTextbox.Location = new System.Drawing.Point(241, 12);
            this.BaudRateTextbox.Name = "BaudRateTextbox";
            this.BaudRateTextbox.Size = new System.Drawing.Size(55, 20);
            this.BaudRateTextbox.TabIndex = 4;
            this.BaudRateTextbox.Text = "115200";
            // 
            // MySerialPort
            // 
            this.MySerialPort.BaudRate = 115200;
            // 
            // ReadTimer
            // 
            this.ReadTimer.Enabled = true;
            this.ReadTimer.Tick += new System.EventHandler(this.ReadTimer_Tick);
            // 
            // SerialLog
            // 
            this.SerialLog.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.SerialLog.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.SerialLog.ForeColor = System.Drawing.Color.Lime;
            this.SerialLog.Location = new System.Drawing.Point(0, 226);
            this.SerialLog.Name = "SerialLog";
            this.SerialLog.Size = new System.Drawing.Size(467, 165);
            this.SerialLog.TabIndex = 5;
            this.SerialLog.Text = "";
            this.SerialLog.TextChanged += new System.EventHandler(this.SerialLog_TextChanged);
            // 
            // InputVoltageLabel
            // 
            this.InputVoltageLabel.AutoSize = true;
            this.InputVoltageLabel.Location = new System.Drawing.Point(15, 54);
            this.InputVoltageLabel.Name = "InputVoltageLabel";
            this.InputVoltageLabel.Size = new System.Drawing.Size(76, 13);
            this.InputVoltageLabel.TabIndex = 6;
            this.InputVoltageLabel.Text = "Input Voltage: ";
            // 
            // SystemUptimeLabel
            // 
            this.SystemUptimeLabel.AutoSize = true;
            this.SystemUptimeLabel.Location = new System.Drawing.Point(216, 54);
            this.SystemUptimeLabel.Name = "SystemUptimeLabel";
            this.SystemUptimeLabel.Size = new System.Drawing.Size(80, 13);
            this.SystemUptimeLabel.TabIndex = 7;
            this.SystemUptimeLabel.Text = "System Uptime:";
            // 
            // OPVoltageLabel
            // 
            this.OPVoltageLabel.AutoSize = true;
            this.OPVoltageLabel.Location = new System.Drawing.Point(216, 80);
            this.OPVoltageLabel.Name = "OPVoltageLabel";
            this.OPVoltageLabel.Size = new System.Drawing.Size(64, 13);
            this.OPVoltageLabel.TabIndex = 9;
            this.OPVoltageLabel.Text = "OP Voltage:";
            // 
            // MaxOPVoltageLabel
            // 
            this.MaxOPVoltageLabel.AutoSize = true;
            this.MaxOPVoltageLabel.Location = new System.Drawing.Point(15, 80);
            this.MaxOPVoltageLabel.Name = "MaxOPVoltageLabel";
            this.MaxOPVoltageLabel.Size = new System.Drawing.Size(87, 13);
            this.MaxOPVoltageLabel.TabIndex = 8;
            this.MaxOPVoltageLabel.Text = "Max OP Voltage:";
            // 
            // OPCurrentLabel
            // 
            this.OPCurrentLabel.AutoSize = true;
            this.OPCurrentLabel.Location = new System.Drawing.Point(216, 108);
            this.OPCurrentLabel.Name = "OPCurrentLabel";
            this.OPCurrentLabel.Size = new System.Drawing.Size(62, 13);
            this.OPCurrentLabel.TabIndex = 11;
            this.OPCurrentLabel.Text = "OP Current:";
            // 
            // MaxOPCurrentLabel
            // 
            this.MaxOPCurrentLabel.AutoSize = true;
            this.MaxOPCurrentLabel.Location = new System.Drawing.Point(15, 108);
            this.MaxOPCurrentLabel.Name = "MaxOPCurrentLabel";
            this.MaxOPCurrentLabel.Size = new System.Drawing.Size(85, 13);
            this.MaxOPCurrentLabel.TabIndex = 10;
            this.MaxOPCurrentLabel.Text = "Max OP Current:";
            // 
            // OPEnergyLabel
            // 
            this.OPEnergyLabel.AutoSize = true;
            this.OPEnergyLabel.Location = new System.Drawing.Point(216, 136);
            this.OPEnergyLabel.Name = "OPEnergyLabel";
            this.OPEnergyLabel.Size = new System.Drawing.Size(61, 13);
            this.OPEnergyLabel.TabIndex = 13;
            this.OPEnergyLabel.Text = "OP Energy:";
            // 
            // OPPowerLabel
            // 
            this.OPPowerLabel.AutoSize = true;
            this.OPPowerLabel.Location = new System.Drawing.Point(15, 136);
            this.OPPowerLabel.Name = "OPPowerLabel";
            this.OPPowerLabel.Size = new System.Drawing.Size(58, 13);
            this.OPPowerLabel.TabIndex = 12;
            this.OPPowerLabel.Text = "OP Power:";
            // 
            // VNBLabel
            // 
            this.VNBLabel.AutoSize = true;
            this.VNBLabel.Location = new System.Drawing.Point(214, 161);
            this.VNBLabel.Name = "VNBLabel";
            this.VNBLabel.Size = new System.Drawing.Size(32, 13);
            this.VNBLabel.TabIndex = 15;
            this.VNBLabel.Text = "VNB:";
            // 
            // VPBLabel
            // 
            this.VPBLabel.AutoSize = true;
            this.VPBLabel.Location = new System.Drawing.Point(15, 161);
            this.VPBLabel.Name = "VPBLabel";
            this.VPBLabel.Size = new System.Drawing.Size(31, 13);
            this.VPBLabel.TabIndex = 14;
            this.VPBLabel.Text = "VPB:";
            // 
            // SRBLabel
            // 
            this.SRBLabel.AutoSize = true;
            this.SRBLabel.Location = new System.Drawing.Point(214, 185);
            this.SRBLabel.Name = "SRBLabel";
            this.SRBLabel.Size = new System.Drawing.Size(32, 13);
            this.SRBLabel.TabIndex = 17;
            this.SRBLabel.Text = "SRB:";
            // 
            // GatePWMLabel
            // 
            this.GatePWMLabel.AutoSize = true;
            this.GatePWMLabel.Location = new System.Drawing.Point(15, 185);
            this.GatePWMLabel.Name = "GatePWMLabel";
            this.GatePWMLabel.Size = new System.Drawing.Size(88, 13);
            this.GatePWMLabel.TabIndex = 16;
            this.GatePWMLabel.Text = "Gate PWM Duty:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ClientSize = new System.Drawing.Size(467, 391);
            this.Controls.Add(this.SRBLabel);
            this.Controls.Add(this.GatePWMLabel);
            this.Controls.Add(this.VNBLabel);
            this.Controls.Add(this.VPBLabel);
            this.Controls.Add(this.OPEnergyLabel);
            this.Controls.Add(this.OPPowerLabel);
            this.Controls.Add(this.OPCurrentLabel);
            this.Controls.Add(this.MaxOPCurrentLabel);
            this.Controls.Add(this.OPVoltageLabel);
            this.Controls.Add(this.MaxOPVoltageLabel);
            this.Controls.Add(this.SystemUptimeLabel);
            this.Controls.Add(this.InputVoltageLabel);
            this.Controls.Add(this.SerialLog);
            this.Controls.Add(this.BaudRateTextbox);
            this.Controls.Add(this.SerialConnectButton);
            this.Controls.Add(this.SerialRefreshButton);
            this.Controls.Add(this.SelectSerialPortLabel);
            this.Controls.Add(this.SerialPortComboBox);
            this.ForeColor = System.Drawing.Color.WhiteSmoke;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AUXPIS Power Supply - Display Over Serial (DOS)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox SerialPortComboBox;
        private System.Windows.Forms.Label SelectSerialPortLabel;
        private System.Windows.Forms.Button SerialRefreshButton;
        private System.Windows.Forms.Button SerialConnectButton;
        private System.Windows.Forms.TextBox BaudRateTextbox;
        private System.IO.Ports.SerialPort MySerialPort;
        private System.Windows.Forms.Timer ReadTimer;
        private System.Windows.Forms.RichTextBox SerialLog;
        private System.Windows.Forms.Label InputVoltageLabel;
        private System.Windows.Forms.Label SystemUptimeLabel;
        private System.Windows.Forms.Label OPVoltageLabel;
        private System.Windows.Forms.Label MaxOPVoltageLabel;
        private System.Windows.Forms.Label OPCurrentLabel;
        private System.Windows.Forms.Label MaxOPCurrentLabel;
        private System.Windows.Forms.Label OPEnergyLabel;
        private System.Windows.Forms.Label OPPowerLabel;
        private System.Windows.Forms.Label VNBLabel;
        private System.Windows.Forms.Label VPBLabel;
        private System.Windows.Forms.Label SRBLabel;
        private System.Windows.Forms.Label GatePWMLabel;
    }
}

