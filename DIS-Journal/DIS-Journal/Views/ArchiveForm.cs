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
    public partial class ArchiveForm : Form
    {
        Color primary, secondary;
        public ArchiveForm(Color pr, Color se)
        {
            InitializeComponent();
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {
            label1.ForeColor = primary;
            textBox1.ForeColor = Color.LightGray;
            richTextBox1.ForeColor = Color.LightGray;           

            switch (primary.R)
            {
                case 58:
                    this.BackColor = Color.FromArgb(169, 223, 175);
                    break;
                case 105:
                    this.BackColor = Color.FromArgb(179, 209, 236);
                    break;
                default:
                    this.BackColor = Color.FromArgb(186, 136, 238);
                    break;
            }
        }
        private void textBox1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == " Title")
            {
                textBox1.Clear();
            }
            textBox1.ForeColor = primary;
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = " Title";
                textBox1.ForeColor = Color.LightGray;
            }
        }

        private void richTextBox1_Click(object sender, EventArgs e)
        {
            if (richTextBox1.Text == " Dear Diary...")
            {
                richTextBox1.Clear();
            }
            richTextBox1.ForeColor = primary;
        }

        private void richTextBox1_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(richTextBox1.Text))
            {
                richTextBox1.Text = " Dear Diary...";
                richTextBox1.ForeColor = Color.LightGray;
            }
        }
    }
}
