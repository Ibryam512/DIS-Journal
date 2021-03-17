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
    public partial class CustomBox : Form
    {
        public CustomBox(string title, string description)
        {
            InitializeComponent();
            label1.Text = title;
            richTextBox1.Text = description;
        }

        public CustomBox(string description)
        {
            InitializeComponent();
            label1.Text = "Error :/";
            richTextBox1.Text = description;
        }

        private void CustomBox_Load(object sender, EventArgs e)
        {

        }
    }
}
