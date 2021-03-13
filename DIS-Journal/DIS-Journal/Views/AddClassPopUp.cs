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

        private void AddClassPopUp_Load(object sender, EventArgs e)
        {
            this.BackColor = primary;
            foreach (Subject s in ScheduleController.subjects)
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
            int day = comboBox2.SelectedIndex;
            int period = int.Parse(comboBox3.SelectedItem.ToString()) - 1;
            ScheduleController.AddClass(comboBox1.SelectedItem.ToString(), day, period);
            Subject s = ScheduleController.subjects.Find(x => x.Title == comboBox1.SelectedItem.ToString());
            Label l = new Label();
            l.Location = new Point(3, 25);
            l.Text = comboBox1.SelectedItem.ToString();
            ScheduleForm.classes[period, day].Controls.Add(l);
            ScheduleForm.classes[period, day].BackColor = Color.Red;
        }

        public AddClassPopUp(Color pr, Color se, Image h)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
            hover = h;
        }
    
    }
}
