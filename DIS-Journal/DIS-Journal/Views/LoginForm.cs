using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DIS_Journal.Views
{
    public partial class LoginForm : Form
    {
        //public variables
        string button_h, button_o, pic;
        Color primary, secondary;

        //constructor
        public LoginForm(string bo, string bh, string pc, Color pr, Color se)
        {
            InitializeComponent();
            button_h = bh;
            button_o = bo;
            pic = pc;
            primary = pr;
            secondary = se;
        }

        //setting the design
        private void LoginForm_Load(object sender, EventArgs e)
        {
            panel1.BackColor = primary;
            //label1.ForeColor = secondary;
            //label2.ForeColor = primary;
            //label3.ForeColor = primary;
            button1.ForeColor = secondary;
            button1.BackgroundImage = Image.FromFile(button_o);
            //pictureBox1.Image = Image.FromFile(pic);
        }

        //username textbox
        private void textBox1_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox1.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = " Username";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        //password textbox
        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.PasswordChar = '\0';

                textBox2.Text = " Password";
                textBox2.ForeColor = Color.LightGray;
            }
        }

        private void textBox2_Click(object sender, EventArgs e)
        {
            textBox2.Clear();
            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.FromArgb(64, 64, 64);
        }

        //showing password
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
            pictureBox4.Image = Image.FromFile("login_form/closeeye.png");
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(DesignController.Register, null))
            {
                DesignController.Register = new RegisterForm(button_o, button_h, pic, primary, secondary);
            }
            DesignController.OpenSideForm(DesignController.Register);
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void label5_MouseEnter(object sender, EventArgs e)
        {
            label5.ForeColor = secondary;
        }

        private void label5_MouseLeave(object sender, EventArgs e)
        {
            label5.ForeColor = Color.White;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void pictureBox4_MouseLeave(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '*';
            pictureBox4.Image = Image.FromFile("login_form/eye.png");
            if (textBox2.Text == " Password")
            {
                textBox2.PasswordChar = '\0';
            }
        }

        //button design
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(button_h);
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave_1(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(button_o);
            button1.ForeColor = secondary;
        }
    }
}
