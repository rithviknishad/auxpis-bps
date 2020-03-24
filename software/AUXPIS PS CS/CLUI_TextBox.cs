using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Plotter.ui
{
    public partial class CLUI_TextBox : UserControl
    {
        public bool Multiline { get; set; } = false;

        public bool HasError { get; set; } = false;

        public Color ForeColor_DefaultText { get; set; }
        public Color ForeColor_Active { get; set; }
        public Color ForeColor_Active_Error { get; set; }
        public Color ForeColor_Inactive { get; set; }
        public Color ForeColor_Inactive_Error { get; set; }

        public Color BackColor_Active { get; set; }
        public Color BackColor_Active_Error { get; set; }
        public Color BackColor_Hover { get; set; }
        public Color BackColor_Inactive { get; set; }
        public Color BackColor_Inactive_Error { get; set; }

        public Color BorderColor_Active { get; set; }
        public Color BorderColor_Active_Error { get; set; }
        public Color BorderColor_Hover { get; set; }
        public Color BorderColor_Inactive { get; set; }
        public Color BorderColor_Inactive_Error { get; set; }


        public string DefaultText { get; set; }

        [Category("Appearance"), Browsable(true), EditorBrowsable(EditorBrowsableState.Always), Bindable(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public new string Text { get => TextBox.Text; set => TextBox.Text = value; }

        public CLUI_TextBox()
        {
            InitializeComponent();
        }
    }
}
