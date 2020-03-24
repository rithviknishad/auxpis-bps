using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.ComponentModel.Design;

namespace Serial_Plotter.ui
{
    [DefaultProperty("Text"), DefaultEvent("Click")]
    public partial class CLUI_Button : UserControl
    {

        #region Custom Color Schema

        [Category("Appearance")]
        public bool UseCustomColors { get; set; } = false;

        [Category("Custom Colors Schema")]
        public Color BackColor_None { get; set; } = Theme.Button.Colors.Normal.BackColor;

        [Category("Custom Colors Schema")]
        public Color ForeColor_None { get; set; } = Theme.Button.Colors.Normal.ForeColor;

        [Category("Custom Colors Schema")]
        public Color BorderColor_None { get; set; } = Theme.Button.Colors.Normal.BorderColor;

        [Category("Custom Colors Schema")]
        public Color BackColor_Hover { get; set; } = Theme.Button.Colors.MouseHover.BackColor;

        [Category("Custom Colors Schema")]
        public Color ForeColor_Hover { get; set; } = Theme.Button.Colors.MouseHover.ForeColor;

        [Category("Custom Colors Schema")]
        public Color BorderColor_Hover { get; set; } = Theme.Button.Colors.MouseHover.BorderColor;

        [Category("Custom Colors Schema")]
        public Color BackColor_Down { get; set; } = Theme.Button.Colors.MouseDown.BackColor;

        [Category("Custom Colors Schema")]
        public Color ForeColor_Down { get; set; } = Theme.Button.Colors.MouseDown.ForeColor;

        [Category("Custom Colors Schema")]
        public Color BorderColor_Down { get; set; } = Theme.Button.Colors.MouseDown.BorderColor;

        #endregion

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

        [Category("Appearance"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public override string Text { get => TextLabel.Text; set => TextLabel.Text = value; }

        [Category("Appearance")]
        public override Font Font { get => TextLabel.Font; set => TextLabel.Font = value; }

        [Category("Appearance")]
        public ContentAlignment TextAlign { get => TextLabel.TextAlign; set => TextLabel.TextAlign = value; }

        [Category("Behavior")]
        public DialogResult DialogResult { get; set; }

        [Category("Behavior")]
        public bool AutoEllipsis { get => TextLabel.AutoEllipsis; set => TextLabel.AutoEllipsis = value; }


        public CLUI_Button()
        {
            InitializeComponent();
            Facilities.WireControls(this, ClickInvoke);
            UpdateControlForMouseState(MouseStates.None);
            Refresh();
        }

        public void ClickInvoke(object sender, EventArgs e) => this.InvokeOnClick(this, EventArgs.Empty);

        public enum MouseStates { None, Hovered, Down }

        private void UpdateControlForMouseState(MouseStates mousestate)
        {
            switch (mousestate)
            {
                case MouseStates.None:

                    BackColor = UseCustomColors ? BackColor_None : Theme.Button.Colors.Normal.BackColor;
                    ForeColor = UseCustomColors ? ForeColor_None : Theme.Button.Colors.Normal.ForeColor;
                    BorderBottom.BackColor = BorderLeft.BackColor = BorderRight.BackColor = BorderTop.BackColor = UseCustomColors ? BorderColor_None : Theme.Button.Colors.Normal.BorderColor;

                    if (DialogResult != DialogResult.None && BorderWidth != 0)
                        BorderWidth = 1;

                    break;

                case MouseStates.Hovered:

                    BackColor = UseCustomColors ? BackColor_Hover : Theme.Button.Colors.MouseHover.BackColor;
                    ForeColor = UseCustomColors ? ForeColor_Hover : Theme.Button.Colors.MouseHover.ForeColor;
                    BorderBottom.BackColor = BorderLeft.BackColor = BorderRight.BackColor = BorderTop.BackColor = UseCustomColors ? BorderColor_Hover : Theme.Button.Colors.MouseHover.BorderColor;

                    if (DialogResult != DialogResult.None && BorderWidth != 0)
                        BorderWidth = 1;

                    break;

                case MouseStates.Down:

                    BackColor = UseCustomColors ? BackColor_Down : Theme.Button.Colors.MouseDown.BackColor;
                    ForeColor = UseCustomColors ? ForeColor_Down : Theme.Button.Colors.MouseDown.ForeColor;
                    BorderBottom.BackColor = BorderLeft.BackColor = BorderRight.BackColor = BorderTop.BackColor = UseCustomColors ? BorderColor_Down : Theme.Button.Colors.MouseDown.BorderColor;

                    if (DialogResult != DialogResult.None && BorderWidth != 0)
                        BorderWidth = 2;

                    break;

                default:
                    throw new NotImplementedException("Mouse state not implemented");
            }
        }

        #region Events
        private void TextLabel_MouseLeave(object sender, EventArgs e) => UpdateControlForMouseState(MouseStates.None);

        private void TextLabel_MouseEnter(object sender, EventArgs e) => UpdateControlForMouseState(MouseStates.Hovered);

        private void TextLabel_MouseDown(object sender, MouseEventArgs e) => UpdateControlForMouseState(MouseStates.Down);

        private void TextLabel_MouseUp(object sender, MouseEventArgs e) => UpdateControlForMouseState(MouseStates.Hovered);
        #endregion

        #region Inherited Properties Hiding
        [Browsable(false)]
        new public BorderStyle BorderStyle { get; set; } = BorderStyle.None;
        #endregion
    }
}
