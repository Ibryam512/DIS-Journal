using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS_Journal.Views
{
    static class DesignController
    {
        public static MainForm Main;
        public static IntroForm Intro = new IntroForm();
        public static LoginForm Login;
        public static RegisterForm Register;

        public static Form OpenMainForm()
        {
            Main = new MainForm();
            OpenForm(Intro);
            return Main;
        }

        public static void OpenForm(Form f)
        {
            Main.panel1.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            Main.panel1.Controls.Add(f);
            f.Show();
        }

        public static void OpenSideForm(Form f)
        {
            Intro.panel1.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            Intro.panel1.Controls.Add(f);
            f.Show();
        }
    }
}
