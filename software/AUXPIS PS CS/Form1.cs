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
    public partial class Form1 : Form
    {
        #region coffeelake standard boiler implementation
        public Color BorderColor { get => BorderBottom.BackColor; set => BorderBottom.BackColor = BorderTop.BackColor = BorderRight.BackColor = BorderLeft.BackColor = value; }

        protected override CreateParams CreateParams
        {
            get
            {
                const int CS_DROPSHADOW = 0x20000;
                CreateParams cp = base.CreateParams;
                cp.ClassStyle |= CS_DROPSHADOW;
                return cp;
            }
        }
        #endregion

        public string WorkspaceName { get => ConnectDeviceButton.Text2; set => ConnectDeviceButton.Text2 = value; }

        public List<string> AvailableDevices = new List<string>();

        public void RefreshDevices()
        {
            AvailableDevices.Clear();
            AvailableDevices.AddRange(SerialPort.GetPortNames());
            NoDeviceLabel.Visible = AvailableDevices.Count == 0;

            foreach (Control device in DeviceMenuSplitContainer.Panel1.Controls)
            {
                if (device.GetType() == typeof(CLUI_HeadButton))
                    DeviceMenuSplitContainer.Panel1.Controls.Remove(device);
            }

            //foreach(SerialPort port in LinkedDevices)
            //{

            //}

            //foreach(string portname in AvailableDevices)
            //{
            //    void search_device()
            //    {
            //        foreach (SerialPort port in LinkedDevices)
            //        {
            //            if (port.PortName == portname)
            //                return;
            //        }

            //        CLUI_HeadButton button = new CLUI_HeadButton
            //        {
            //            Dock = DockStyle.Top,
            //            Text1 = "Ready to connect",
            //            Text2 = portname,
            //            BorderWidth = 0,
            //            BackColor = Color.FromArgb(47, 54, 61),
            //            BackColor_Normal = Color.FromArgb(47, 54, 61),
            //            BackColor_Hover = Color.FromArgb(36, 41, 46),
            //            BackColor_Down = Color.FromArgb(68, 77, 86),
            //            Image_Normal = Serial_Plotter.Properties.Resources.serialport_normal,
            //            Image_Hover = Serial_Plotter.Properties.Resources.serialport_light,
            //            Image_Down = Serial_Plotter.Properties.Resources.serialport_light
            //        };

            //        button.Click += DeviceButton_Clicked;

            //        DeviceMenuSplitContainer.Panel1.Controls.Add(button);

            //    }
            //    search_device();
            //}
        }


        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_SizeChanged(object sender, EventArgs e) => BorderTop.Visible = BorderLeft.Visible = BorderRight.Visible = (this.WindowState != FormWindowState.Maximized);

        private void ConnectDeviceButton_Click(object sender, EventArgs e)
        {
            DeviceMenuSplitContainer.Panel2Collapsed = !(DeviceMenuSplitContainer.Panel1Collapsed = !DeviceMenuSplitContainer.Panel1Collapsed);
            RefreshDevices();
        }
    }
}
