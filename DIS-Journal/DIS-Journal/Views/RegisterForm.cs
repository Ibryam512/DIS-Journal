using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIS_Journal.Controllers;

namespace DIS_Journal.Views
{
    public partial class RegisterForm : Form
    {
        //public variables
        string button_h, button_o, pic;
        Color primary, secondary;

        //constructor and initialisation
        public RegisterForm(string bo, string bh, string pc, Color pr, Color se)
        {
            InitializeComponent();
            button_h = bh;
            button_o = bo;
            pic = pc;
            primary = pr;
            secondary = se;
        }

        //Loading the years and setting the design
        private void RegisterForm_Load(object sender, EventArgs e)
        {
            for (int i = 2021; i >= 1950; i--)
            {
                comboBox3.Items.Add(i);
            }

            panel1.BackColor = primary;
            //label1.ForeColor = secondary;
            //label2.ForeColor = primary;
            //label3.ForeColor = primary;
            button1.ForeColor = secondary;
            button1.BackgroundImage = Image.FromFile(button_o);
            //pictureBox1.Image = Image.FromFile(pic);
        }

        //Loading the days
        private void comboBox1_SelectedValueChanged(object sender, EventArgs e)
        {

        }

        //change font on the dropdown
        private void comboBox3_DropDown(object sender, EventArgs e)
        {
            comboBox3.ForeColor = Color.FromArgb(64, 64, 64);
        }
        private void comboBox1_DropDown(object sender, EventArgs e)
        {
            comboBox1.ForeColor = Color.FromArgb(64, 64, 64);
        }
        private void comboBox2_DropDown(object sender, EventArgs e)
        {
            comboBox2.ForeColor = Color.FromArgb(64, 64, 64);
            comboBox2.Items.Clear();
            int month = int.Parse(comboBox1.SelectedItem.ToString());
            int year = int.Parse(comboBox3.SelectedItem.ToString());
            int days;
            if (month == 1 || month == 3 || month == 5 || month == 7 || month == 8 || month == 10 || month == 12)
            {
                days = 31;
            }
            else if (month == 2 && year % 4 == 0)
            {
                days = 29;
            }
            else if (month == 2 && year % 4 != 0)
            {
                days = 28;
            }
            else
            {
                days = 30;
            }

            for (int i = 1; i <= days; i++)
            {
                comboBox2.Items.Add(i);
            }
        }

        //username textbox
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " Username")
            {
                textBox1.Clear();
            }
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
            if (textBox2.Text == " Password")
            {
                textBox2.Clear();
            }
            textBox2.PasswordChar = '*';
            textBox2.ForeColor = Color.FromArgb(64, 64, 64);
        }

        //showing password
        private void pictureBox4_MouseEnter(object sender, EventArgs e)
        {
            textBox2.PasswordChar = '\0';
            pictureBox4.Image = Image.FromFile("login_form/closeeye.png");
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

        //email textbox
        private void textBox3_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == " Email")
            {
                textBox3.Clear();
            }
            textBox3.ForeColor = Color.FromArgb(64, 64, 64);
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (object.ReferenceEquals(DesignController.Login, null))
            {
                DesignController.Login = new LoginForm(button_o, button_h, pic, primary, secondary);
            }
            DesignController.OpenSideForm(DesignController.Login);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = textBox1.Text;
            string password = textBox2.Text;
            string email = textBox3.Text;
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || comboBox1.SelectedIndex < 0 || comboBox2.SelectedIndex < 0 || comboBox3.SelectedIndex < 0)
            {
                var message = new CustomBox("There are empty spaces!");
                message.ShowDialog();
                return;
            }
            if (password.Length < 8)
            {
                var message = new CustomBox("Your password should be 8 symbols or more long!");
                message.ShowDialog();
                return;
            }
            if (!new EmailAddressAttribute().IsValid(email))
            {
                var message = new CustomBox("Your email is not valid!");
                message.ShowDialog();
                return;
            }
            int year = int.Parse(comboBox3.SelectedItem.ToString());
            int month = int.Parse(comboBox1.SelectedItem.ToString());
            int day = int.Parse(comboBox2.SelectedItem.ToString());
            DateTime birth = new DateTime(year, month, day);
            var userController = new UserController();
            userController.Register(username, email, password, birth, "user");
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

        private void button1_MouseEnter_1(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(button_h);
            button1.ForeColor = Color.White;
        }

        private void comboBox3_TextUpdate(object sender, EventArgs e)
        {

        }

        private void comboBox3_DropDownClosed(object sender, EventArgs e)
        {
            if(comboBox3.Text == "YYYY")
            {
                comboBox3.ForeColor = Color.LightGray;
            }
        }

        private void comboBox1_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MM")
            {
                comboBox1.ForeColor = Color.LightGray;
            }
        }

        private void comboBox2_DropDownClosed(object sender, EventArgs e)
        {
            if (comboBox2.Text == "YYYY")
            {
                comboBox2.ForeColor = Color.LightGray;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox3.Text = "Email";
                textBox3.ForeColor = Color.LightGray;
            }
        }

        //button design
        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(button_h);
            button1.ForeColor = Color.White;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile(button_o);
            button1.ForeColor = secondary;
        }
    }
}
