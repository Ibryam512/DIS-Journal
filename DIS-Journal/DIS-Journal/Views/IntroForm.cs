using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Resources;

namespace DIS_Journal.Views
{
    public partial class IntroForm : Form
    {
        public IntroForm()
        {
            InitializeComponent();
        }

        string button_h, button_o, pic;
        Color primary, secondary;

        private void IntroForm_Load(object sender, EventArgs e)
        {
            Random r = new Random();
            int random = r.Next(1, 4);
            switch (random)
            {
                case 1:
                    button_h = "intro_form/hoveri.png";
                    button_o = "intro_form/outi.png";
                    pic = "intro_form/i.png";
                    primary = Color.FromArgb(58, 165, 90);
                    secondary = Color.FromArgb(29, 83, 45);
                    break;
                case 2:
                    button_h = "intro_form/hoverv.png";
                    button_o = "intro_form/outv.png";
                    pic = "intro_form/v.png";
                    primary = Color.FromArgb(105, 165, 218);
                    secondary = Color.FromArgb(71, 113, 184);
                    break;
                default:
                    button_h = "intro_form/hovern.png";
                    button_o = "intro_form/outn.png";
                    pic = "intro_form/n.png";
                    primary = Color.FromArgb(186, 104, 200);
                    secondary = Color.FromArgb(131, 73, 140);
                    break;
            }
            panel1.BackColor = primary;
            label1.ForeColor = secondary;
            label2.ForeColor = primary;
            label3.ForeColor = primary;
            button1.ForeColor = secondary;
            button2.ForeColor = secondary;
            button1.BackgroundImage = Image.FromFile(button_o);
            button2.BackgroundImage = Image.FromFile(button_o);
            pictureBox1.Image = Image.FromFile(pic);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(button_h);
            button1.ForeColor = Color.White;
        }

        public void button1_Click_1(object sender, EventArgs e)
        {
            DesignController.Login = new LoginForm(button_o, button_h, pic, primary, secondary);
            DesignController.OpenSideForm(DesignController.Login);
            //this.Close();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            DesignController.Register = new RegisterForm(button_o, button_h, pic, primary, secondary);
            DesignController.OpenSideForm(DesignController.Register);
            //this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(button_o);
            button1.ForeColor = secondary;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = Image.FromFile(button_h);
            button2.ForeColor = Color.White;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = Image.FromFile(button_o);
            button2.ForeColor = secondary;

        }
    }
}
