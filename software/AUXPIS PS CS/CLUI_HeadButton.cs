using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Plotter.ui
{
    [DefaultEvent("Click")]
    public partial class CLUI_HeadButton : UserControl
    {
        public CLUI_HeadButton()
        {
            InitializeComponent();
            Facilities.WireControls(this, ClickInvoke);
            ImageBox.Image = Image_Normal;
        }

        public void ClickInvoke(object sender, EventArgs e) => this.InvokeOnClick(this, EventArgs.Empty);

        [Category("Appearance"), Description("BackColor of the control when its in normal state")]
        public Color BackColor_Normal { get; set; } = Color.FromArgb(29, 33, 37);

        private Image imagenormal;

        [Category("Content"), Description("Image to be displayed on the button when its in normal state")]
        public Image Image_Normal { get => imagenormal; set { imagenormal = ImageBox.Image = value; } }


        [Category("Appearance"), Description("BackColor of the control when its in hovered state")]
        public Color BackColor_Hover { get; set; } = Color.FromArgb(47, 54, 61);

        [Category("Content"), Description("Image to be displayed on the button when its in hovered state")]
        public Image Image_Hover { get; set; }


        [Category("Appearance"), Description("BackColor of the control when its in mouse down state")]
        public Color BackColor_Down { get; set; } = Color.FromArgb(47, 54, 61);

        [Category("Content"), Description("Image to be displayed on the button when its in mouse down state")]
        public Image Image_Down { get; set; }


        [Category("Appearance"), Description("Text label1's text to be displayed")]
        public string Text1 { get => Text1Label.Text; set => Text1Label.Text = value; }
        [Category("Appearance"), Description("Text label2's text to be displayed")]
        public string Text2 { get => Text2Label.Text; set => Text2Label.Text = value; }

        [Category("Appearance"), Description("Text label1's fore color")]
        public Color Text1ForeColor { get => Text1Label.ForeColor; set => Text1Label.ForeColor = value; }
        [Category("Appearance"), Description("Text label2's fore color")]
        public Color Text2ForeColor { get => Text2Label.ForeColor; set => Text2Label.ForeColor = value; }

        [Category("Appearance"), Description("Text label1's position")]
        public Point Text1Position { get => Text1Label.Location; set => Text1Label.Location = value; }
        [Category("Appearance"), Description("Text label2's position")]
        public Point Text2Position { get => Text2Label.Location; set => Text2Label.Location = value; }

        [Category("Appearance"), Description("Text label1's Text Alignment")]
        public ContentAlignment Text1Align { get => Text1Label.TextAlign; set => Text1Label.TextAlign = value; }
        [Category("Appearance"), Description("Text label2's Text Alignment")]
        public ContentAlignment Text2Align { get => Text2Label.TextAlign; set => Text2Label.TextAlign = value; }

        [Category("Appearance"), Description("Text label1's Font")]
        public Font Font1 { get => Text1Label.Font; set => Text1Label.Font = value; }
        [Category("Appearance"), Description("Text label2's Font")]
        public Font Font2 { get => Text2Label.Font; set => Text2Label.Font = value; }

        public Point ImageLocation { get => ImageBox.Location; set => ImageBox.Location = value; }

        public Size ImageSize { get => ImageBox.Size; set => ImageBox.Size = value; }


        [Category("Appearance")]
        public int BorderWidth
        {
            get => BorderBottom.Size.Height;
            set
            {
                BorderBottom.Size = BorderTop.Size = new Size(BorderBottom.Size.Width, value);
                BorderLeft.Size = BorderRight.Size = new Size(value, BorderLeft.Height);
            }
        }

        #region Events
        private void CLUI_HeadButton_MouseDown(object sender, MouseEventArgs e)
        {
            BackColor = BackColor_Down;
            ImageBox.Image = Image_Down;
        }

        private void CLUI_HeadButton_MouseEnter(object sender, EventArgs e)
        {
            BackColor = BackColor_Hover;
            ImageBox.Image = Image_Hover;
        }

        private void CLUI_HeadButton_MouseLeave(object sender, EventArgs e)
        {
            BackColor = BackColor_Normal;
            ImageBox.Image = Image_Normal;
        }

        private void CLUI_HeadButton_MouseUp(object sender, MouseEventArgs e)
        {
            BackColor = BackColor_Hover;
            ImageBox.Image = Image_Hover;
        }
        #endregion

        #region Suppressed Properties
        [Browsable(false)]
        public override Font Font { get; set; }

        [Browsable(false)]
        public override Color BackColor { get => base.BackColor; set => base.BackColor = value; }
        #endregion
    }
}
