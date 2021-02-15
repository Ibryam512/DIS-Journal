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
    public partial class Login : Form
    {
        UserController user = new UserController();
        public Login()
        {
            InitializeComponent();
        }

        private void textBoxEmail_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxEmail.Text))
            {
                labelEmail.Visible = true;
            }
            else
            {
                labelEmail.Visible = false;
            }
        }

        private void textBoxPassword_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxPassword.Text))
            {
                labelPassword.Visible = true;
            }
            else
            {
                labelPassword.Visible = false;
            }
        }

        private void buttonLogin_Click(object sender, EventArgs e)
        {
            user.Login(textBoxEmail.Text, textBoxPassword.Text);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Register register = new Register();
            register.ShowDialog();
        }
    }
}

