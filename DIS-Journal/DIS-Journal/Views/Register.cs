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
    public partial class Register : Form
    {
        UserController user = new UserController();
        public Register()
        {
            InitializeComponent();
        }

        private void textBoxFirstName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxFirstName.Text))
            {
                labelFirstName.Visible = true;
            }
            else
            {
                labelFirstName.Visible = false;
            }
        }

        private void textBoxLastName_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxLastName.Text))
            {
                labelLastName.Visible = true;
            }
            else
            {
                labelLastName.Visible = false;
            }
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

        private void textBoxBirth_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxBirth.Text))
            {
                labelBirth.Visible = true;
            }
            else
            {
                labelBirth.Visible = false;
            }
        }

        private void textBoxRole_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBoxRole.Text))
            {
                labelRole.Visible = true;
            }
            else
            {
                labelRole.Visible = false;
            }
        }

        private void buttonRegister_Click(object sender, EventArgs e)
        {
            user.Register(textBoxFirstName.Text, textBoxLastName.Text, textBoxEmail.Text, textBoxPassword.Text, DateTime.Parse(textBoxBirth.Text), textBoxRole.Text);
        }
    }
}
