using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Serial_Plotter.ui
{
    public enum Themes { Light = 0, Dark }

    public static class Theme
    {
        private static Themes selectedTheme = Themes.Dark;
        public static Themes SelectedTheme
        {
            get => selectedTheme;
            set
            {
                switch (selectedTheme = value)
                {
                    case Themes.Light:
                        break;

                    case Themes.Dark:
                        break;

                    default:
                        throw new NotImplementedException("Theme not supported!");
                }
                Button.Update(value);
                //implement rest here...
            }
        }

        

        public static class Button
        {
            internal static void Update(Themes theme)
            {
                switch (theme)
                {
                    case Themes.Light:
                        break;
                    case Themes.Dark:
                        break;

                    default:
                        throw new NotImplementedException("Theme.Button.Update(Themes) => Speceified theme isn't implemented or supported by Theme.Button and it's children.");
                }
            }

            public static class Colors
            {
                public static class Normal
                {
                    public static Color BackColor = Color.FromArgb(36, 41, 46);
                    public static Color ForeColor = Color.DarkGray;
                    public static Color BorderColor = Color.FromArgb(20, 20, 20);
                }

                public static class MouseHover
                {
                    public static Color BackColor = Color.FromArgb(47, 54, 61);
                    public static Color ForeColor = Color.FromArgb(255, 255, 255);
                    public static Color BorderColor = Color.FromArgb(209, 213, 218);
                };

                public static class MouseDown
                {
                    public static Color BackColor = Color.FromArgb(47, 54, 61);
                    public static Color ForeColor = Color.FromArgb(255, 255, 255);
                    public static Color BorderColor = Color.FromArgb(209, 213, 218);
                };
            }
        }
    }
}
