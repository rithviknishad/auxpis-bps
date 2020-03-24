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

namespace AUXPIS_PS_CS
{
    public partial class SerialPortConfgureWindow : Form
    {
        public SerialPort serialport { get; set; }

        public SerialPortConfgureWindow()
        {
            InitializeComponent();
        }

        public void Initialize()
        {
            this.Text = serialport.PortName;

            //Input_DeviceName.Text = serialport.DeviceName;
            Input_BaudRate.Text = serialport.BaudRate.ToString();
            Input_DataBits.Value = serialport.DataBits;
            Input_Handshake.Text = serialport.Handshake.ToString();
            Input_ReadTimeout.Value = serialport.ReadTimeout;
            Input_WriteTimeout.Value = serialport.WriteTimeout;
            Input_ReadBufferSize.Value = serialport.ReadBufferSize;
            Input_WriteBufferSize.Value = serialport.WriteBufferSize;
            Input_DiscardNull.SelectedIndex = serialport.DiscardNull ? 1 : 0;
            Input_DtrEnable.SelectedIndex = serialport.DtrEnable ? 1 : 0;
            Input_Parity.Text = serialport.Parity.ToString();
            Input_RtsEnable.SelectedIndex = serialport.RtsEnable ? 1 : 0;
            Input_StopBits.Text = serialport.StopBits.ToString();
            Input_ReceiveThreshold.Value = serialport.ReceivedBytesThreshold;
        }
    }
}
