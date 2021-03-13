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

        private void PickColor(PictureBox pbox)
        {
            foreach(Control p in this.Controls)
            {
                if(p is PictureBox)
                {
                    (p as PictureBox).BorderStyle = BorderStyle.None;
                }
            }
            pbox.BorderStyle = BorderStyle.Fixed3D;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            PickColor(pictureBox2);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            PickColor(pictureBox1);
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            PickColor(pictureBox3);

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            PickColor(pictureBox4);
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            PickColor(pictureBox5);
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            PickColor(pictureBox6);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
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
            PictureBox pic = pictureBox1;
            foreach (Control p in this.Controls)
            {
                if (p is PictureBox)
                {
                    if ((p as PictureBox).BorderStyle == BorderStyle.None)
                    {
                        pic = (p as PictureBox);
                    }
                }
            }
            ScheduleController.AddSubject(textBox1.Text, pic.BackColor);
            this.Close();
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = null;
            button1.BackColor = Color.White;
            button1.ForeColor = primary;
        }
    }
}
