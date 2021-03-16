using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DIS_Journal.Models;
using DIS_Journal.Controllers;

namespace DIS_Journal.Views
{
    public partial class AddClassPopUp : Form
    {
        Color primary, secondary;
        Image hover;

        public AddClassPopUp(Color pr, Color se, Image h)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
            hover = h;
            button2.BackgroundImage = h;
        }

        private void AddClassPopUp_Load(object sender, EventArgs e)
        {
            this.BackColor = primary;
            foreach (Subject s in ScheduleController.context.Subjects)
            {
                comboBox1.Items.Add(s.Title);
            }
            comboBox2.Items.Add("Monday");
            comboBox2.Items.Add("Tuesday");
            comboBox2.Items.Add("Wednesday");
            comboBox2.Items.Add("Thursday");
            comboBox2.Items.Add("Friday");
            for (int i = 1; i < 8; i++)
            {
                comboBox3.Items.Add(i.ToString());
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //putting relevant names for Her Majesty :)
            int day = comboBox2.SelectedIndex;
            int period = int.Parse(comboBox3.SelectedItem.ToString()) - 1;
            ScheduleController.AddClass(comboBox1.SelectedItem.ToString(), day, period);
            Subject subject = ScheduleController.context.Subjects.Single(x => x.Title == comboBox1.SelectedItem.ToString());
            Label label_subject = new Label();
            Label close_panel = new Label();

            ScheduleForm.classes[period, day].Controls.Add(label_subject);
            ScheduleForm.classes[period, day].Controls.Add(close_panel);

            close_panel.Text = "x";
            close_panel.ForeColor = Color.White;
            close_panel.BackColor = Color.Transparent;
            close_panel.Font = new Font("Bahnschrift", 12);
            close_panel.Location = new Point(73, 0);
            close_panel.Click += delegate (object s, EventArgs ea) { Clear_Panel(s, ea, period, day); };

            label_subject.Location = new Point(3, 25);
            label_subject.Text = comboBox1.SelectedItem.ToString();

            ScheduleForm.classes[period, day].BackColor = Color.FromArgb(100, subject.R, subject.G, subject.B);
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Clear_Panel(object sender, EventArgs e, int period, int day)
        {
            Panel panel = ScheduleForm.classes[period, day];
            panel.Controls.Clear();
            panel.BackColor = Color.White;
            ScheduleController.RemoveClass(day, period);
            
        }
    }
}
