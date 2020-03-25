using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SoftwareSerialDisplay
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void SerialRefreshButton_Click(object sender, EventArgs e)
        {
            SerialPortComboBox.Items.Clear();
            
            foreach (string portname in SerialPort.GetPortNames())
                SerialPortComboBox.Items.Add(portname);
        }

        private void SerialConnectButton_Click(object sender, EventArgs e)
        {
            try
            {
                MySerialPort.Close();
                MySerialPort.PortName = SerialPortComboBox.Text;
                MySerialPort.BaudRate = Convert.ToInt32(BaudRateTextbox.Text);
                MySerialPort.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void ProcessEntry(string[] parameters)
        {
            try
            {
                InputVoltageLabel.Text = "Input Voltage: " + parameters[0].Replace("\n", "") + " V";
                SystemUptimeLabel.Text = "System Uptime: " + parameters[1] + " ms";
                MaxOPVoltageLabel.Text = "Max OP Voltage: " + parameters[2] + " V";
                OPVoltageLabel.Text = "OP Voltage: " + parameters[3] + " V";
                MaxOPCurrentLabel.Text = "Max OP Current: " + parameters[4] + " A";
                OPCurrentLabel.Text = "OP Current: " + parameters[5] + " A";
                OPPowerLabel.Text = "OP Power: " + parameters[6] + " W";
                OPEnergyLabel.Text = "OP Energy: " + parameters[7] + " Wh";
                VPBLabel.Text = "VPB: " + parameters[8] + " V";
                VNBLabel.Text = "VNB: " + parameters[9] + " V";
                GatePWMLabel.Text = "Gate PWM Duty:" + parameters[10];
                SRBLabel.Text = "SRB: " + parameters[11];
            }
            catch { }
        }

        private string buffer_space = "";

        private void ReadTimer_Tick(object sender, EventArgs e)
        {
            if (!MySerialPort.IsOpen)
                return;

            while(MySerialPort.BytesToRead > 0)
            {
                int readbyte = MySerialPort.ReadByte();

                //SerialLog.AppendText(Convert.ToString(readbyte, 2).PadLeft(8, '0'));

                if ((char)readbyte == ';')
                {
                    ProcessEntry(buffer_space.Split(','));
                    SerialLog.AppendText(buffer_space);
                    buffer_space = "";
                }
                else
                    buffer_space += (char)readbyte;

            }
        }

        private void SerialLog_TextChanged(object sender, EventArgs e)
        {
            SerialLog.SelectionStart = SerialLog.Text.Length;
            SerialLog.ScrollToCaret();
        }
    }
}
