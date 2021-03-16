using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIS_Journal.Controllers;

namespace DIS_Journal.Views
{
    public partial class ProfileForm : Form
    {
        Color primary, secondary;
        Image hover;

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            switch (primary.R)
            {
                case 58:
                    this.BackColor = Color.FromArgb(169, 223, 175);
                    pictureBox1.Image = Image.FromFile("main_form/gprofile.png");
                    break;
                case 105:
                    this.BackColor = Color.FromArgb(179, 209, 236);
                    pictureBox1.Image = Image.FromFile("main_form/bprofile.png");
                    break;
                default:
                    this.BackColor = Color.FromArgb(186, 136, 238);
                    pictureBox1.Image = Image.FromFile("main_form/pprofile.png");
                    break;
            }
            button1.BackColor = secondary;
            pictureBox2.BackColor = textBox2.BackColor;
            DateTime birth = Logged.Birth.Date;
            textBox1.Text = Logged.Email;
            textBox2.Text = Logged.Username;
            textBox3.Text = $"{birth.Day}.{birth.Month}.{birth.Year}"; ;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            textBox2.ReadOnly = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var userController = new UserController();
            userController.Delete(Logged.Id);
            DesignController.OpenForm(DesignController.Intro);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox2.Text;
            var userController = new UserController();
            userController.Update(Logged.Id, username);
            textBox2.ReadOnly = true;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            var userController = new UserController();
            userController.Logout();
            DesignController.OpenForm(DesignController.Intro);
        }

        public ProfileForm(Color pr, Color se, Image h)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
            hover = h;
        }
    }
}
