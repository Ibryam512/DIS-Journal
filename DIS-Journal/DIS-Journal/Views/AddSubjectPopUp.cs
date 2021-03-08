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
    public partial class AddSubjectPopUp : Form
    {
        public AddSubjectPopUp()
        {
            InitializeComponent();
        }

        private void ClassPopUp_Load(object sender, EventArgs e)
        {

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
    }
}
