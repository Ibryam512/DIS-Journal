using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace DIS_Journal.Views
{
    static class DesignController
    {
        public static MainForm Main;
        public static IntroForm Intro = new IntroForm();
        public static LoginForm Login;
        public static RegisterForm Register;
        public static MainAppForm App = new MainAppForm(Color.FromArgb(105, 165, 218), Color.FromArgb(71, 113, 184));
        public static JournalForm Journal;
        public static ScheduleForm Schedule;

        public static Form OpenMainForm()
        {
            Main = new MainForm();
            OpenForm(App);
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

        public static void OpenFormInApp(Form f)
        {
            App.panel2.Controls.Clear();
            f.TopLevel = false;
            f.AutoScroll = true;
            App.panel2.Controls.Add(f);
            f.Show();
        }
    }
}
