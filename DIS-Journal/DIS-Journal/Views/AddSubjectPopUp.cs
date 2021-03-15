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
    public partial class AddSubjectPopUp : Form
    {
        Color primary, secondary;
        Image hover;
        public AddSubjectPopUp(Color pr, Color se, Image h)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
            hover = h;
            button2.BackgroundImage = h;
        }

        private void ClassPopUp_Load(object sender, EventArgs e)
        {
            this.BackColor = primary;
        }

        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " Subject name")
            {
                textBox1.Clear();
            }
            textBox1.ForeColor = primary;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = " Subject name";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void PickColor(Panel pbox)
        {
            foreach(Control p in panel1.Controls)
            {
                if(p is Panel box)
                {
                    box.BackColor = Color.FromArgb(255, box.BackColor);
                }
            }
            pbox.BackColor = Color.FromArgb(80, pbox.BackColor);
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = hover;
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.White;
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = null;
            button2.BackColor = Color.White;
            button2.ForeColor = primary;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            button2.BackgroundImage = hover;
            button2.BackColor = Color.Transparent;
            button2.ForeColor = Color.White;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Panel pic = panel2;
            foreach (Control p in this.panel1.Controls)
            {
                if (p is Panel)
                {
                    if ((p as Panel).BackColor.A == 80)
                    {
                        pic = (p as Panel);
                    }
                }
            }
            ScheduleController.AddSubject(textBox1.Text, Color.FromArgb(255, pic.BackColor));
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void panel2_Click(object sender, EventArgs e)
        {
            PickColor(panel2);
        }

        private void panel3_Click(object sender, EventArgs e)
        {
            PickColor(panel3);
        }

        private void panel4_Click(object sender, EventArgs e)
        {
            PickColor(panel4);
        }

        private void panel5_Click(object sender, EventArgs e)
        {
            PickColor(panel5);
        }

        private void panel6_Click(object sender, EventArgs e)
        {
            PickColor(panel6);
        }

        private void panel7_Click(object sender, EventArgs e)
        {
            PickColor(panel7);
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = null;
            button1.BackColor = Color.White;
            button1.ForeColor = primary;
        }
    }
}
