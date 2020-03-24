using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace Serial_Plotter.ui
{
    public partial class CLUI_TitleBar : UserControl
    {
        public int BorderWidth { get => BorderBottom.Size.Height; set => BorderBottom.Size = new Size(BorderBottom.Size.Width, value); }

        public bool ShowMinimizeButton { get => MinimizeButton.Visible; set => MinimizeButton.Visible = value; }
        public bool ShowMaximizeButton { get => WindowsStateToggleButton.Visible; set => WindowsStateToggleButton.Visible = value; }
        public bool ShowCloseButton { get => CloseButton.Visible; set => CloseButton.Visible = value; }

        public Image ActiveImage { get; set; }
        public Image InactiveImage { get; set; }

        public ContentAlignment TitleAlign { get => WindowTitle.TextAlign; set => WindowTitle.TextAlign = value; }

        public MenuStrip MenuStrip { get; set; }

        public CLUI_TitleBar()
        {
            InitializeComponent();

            BackColor = Theme.Button.Colors.Normal.BackColor;
            ForeColor = Theme.Button.Colors.Normal.ForeColor;
            BorderBottom.BackColor = Theme.Button.Colors.Normal.BorderColor;

            WindowIcon.Image = ActiveImage;

            this.Dock = DockStyle.Top;
            Facilities.WireControls(this, ClickInvoke);
        }

        public void ParentForm_Activated(object sender, EventArgs e)
        {
            WindowIcon.Image = ActiveImage;
            WindowTitle.ForeColor = Theme.Button.Colors.MouseHover.ForeColor;
        }

        public void ParentForm_Deactivate(object sender, EventArgs e)
        {
            WindowIcon.Image = InactiveImage;
            WindowTitle.ForeColor = Theme.Button.Colors.Normal.ForeColor;
        }

        #region Events

        public void ClickInvoke(object sender, EventArgs e) => this.InvokeOnClick(this, EventArgs.Empty);

        private void TitleBar_Paint(object sender, PaintEventArgs e) => WindowTitle.Text = " " + ParentForm.Text + " ";

        private void CloseButton_Click(object sender, EventArgs e) => ParentForm.Close();

        private void WindowsStateToggleButton_Click(object sender, EventArgs e) => ParentForm.WindowState = ParentForm.WindowState == FormWindowState.Maximized ? FormWindowState.Normal : FormWindowState.Maximized;

        private void MinimizeButton_Click(object sender, EventArgs e) => ParentForm.WindowState = FormWindowState.Minimized;

        private void TitleBar_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Facilities.ReleaseCapture();
                Facilities.SendMessage(Parent.Handle, Facilities.WM_NCLBUTTONDOWN, Facilities.HT_CAPTION, 0);
            }
        }

        #endregion
    }
}
