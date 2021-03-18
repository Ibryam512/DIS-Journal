using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Globalization;
using DIS_Journal.Controllers;

namespace DIS_Journal.Views
{
    public partial class JournalForm : Form
    {
        Color primary, secondary;
        Image hover;
        public JournalForm(Color pr, Color se, Image h)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
            hover = h;
        }

        private void JournalForm_Load(object sender, EventArgs e)
        {
            label1.ForeColor = primary;
            textBox1.ForeColor = Color.LightGray;
            richTextBox1.ForeColor = Color.LightGray;
            label1.Text = $"{DateTime.Today.DayOfWeek}, {CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(DateTime.Today.Month)} {DateTime.Today.Day}, {DateTime.Today.Year}";

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
            button1.BackgroundImage = hover;
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

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = null;
            button1.BackColor = Color.White;
            button1.ForeColor = primary;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            button1.BackgroundImage = hover;
            button1.BackColor = Color.Transparent;
            button1.ForeColor = Color.White;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string title = textBox1.Text;
            string description = richTextBox1.Text;
            if (description.Length > 10000)
            {
                var message = new CustomBox("The description is too long!");
                message.ShowDialog();
                return;
            }
            DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);
            var journalController = new JournalController();
            journalController.UploadJournal(title, description, date);
            textBox1.Clear();
            richTextBox1.Clear();
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