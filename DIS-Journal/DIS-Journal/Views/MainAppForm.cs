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
    public partial class MainAppForm : Form
    {
        public MainAppForm()
        {
            InitializeComponent();
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = Image.FromFile("main_form/vhover.png");
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if(button1.ForeColor != Color.White)
            {
                button1.BackgroundImage = null;
                button1.BackColor = Color.FromArgb(105, 165, 218);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackgroundImage = Image.FromFile("main_form/vsel.png");
            if(button2.ForeColor == Color.White)
            {
                button2.BackgroundImage = null;
                button2.BackColor = Color.FromArgb(105, 165, 218);
                button2.ForeColor = Color.WhiteSmoke;
            }
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = Image.FromFile("main_form/vhover.png");
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.ForeColor != Color.White)
            {
                button2.BackgroundImage = null;
                button2.BackColor = Color.FromArgb(105, 165, 218);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
            button2.BackgroundImage = Image.FromFile("main_form/vsel.png");
            if (button1.ForeColor == Color.White)
            {
                button1.BackgroundImage = null;
                button1.BackColor = Color.FromArgb(105, 165, 218);
                button1.ForeColor = Color.WhiteSmoke;
            }
        }
    }
}
