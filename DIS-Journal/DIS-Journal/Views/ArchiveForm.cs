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
    public partial class ArchiveForm : Form
    {
        Color primary, secondary;
        public ArchiveForm(Color pr, Color se)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
        }

        private void ArchiveForm_Load(object sender, EventArgs e)
        {
            label1.ForeColor = primary;
            textBox1.ForeColor = primary;
            richTextBox1.ForeColor = primary;
            comboBox1.ForeColor = primary;

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
            var journalController = new JournalController();
            var journals = journalController.GetJournals();
            foreach (var journal in journals)
            {
                comboBox1.Items.Add(journal.Title);
            }
          
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var title = comboBox1.SelectedItem.ToString();
            var journalController = new JournalController();
            var journal = journalController.GetJournal(title);
            textBox1.Text = $"{journal.Date.Day}.{journal.Date.Month}.{journal.Date.Year}";
            richTextBox1.Text = journal.Description;
        }

    }
}
