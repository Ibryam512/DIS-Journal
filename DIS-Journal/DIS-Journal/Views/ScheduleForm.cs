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
    public partial class ScheduleForm : Form
    {
        Color primary, secondary;
        Image hover;
        public static Panel[,] classes = new Panel[7, 5];

        public ScheduleForm(Color pr, Color se, Image h)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
            hover = h;
            FillArray();
        }

        private void ScheduleForm_Load(object sender, EventArgs e)
        {
            this.BackColor = secondary;
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

        private void button2_Click(object sender, EventArgs e)
        {
            AddClassPopUp pop = new AddClassPopUp(primary, secondary, hover);
            pop.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSubjectPopUp pop = new AddSubjectPopUp(primary, secondary, hover);
            pop.Show();
        }
        private void FillArray()
        {
            classes[0, 0] = Monday_1;
            classes[1, 0] = Monday_2;
            classes[2, 0] = Monday_3;
            classes[3, 0] = Monday_4;
            classes[4, 0] = Monday_5;
            classes[5, 0] = Monday_6;
            classes[6, 0] = Monday_7;
            classes[0, 1] = Tuesday_1;
            classes[1, 1] = Tuesday_2;
            classes[2, 1] = Tuesday_3;
            classes[3, 1] = Tuesday_4;
            classes[4, 1] = Tuesday_5;
            classes[5, 1] = Tuesday_6;
            classes[6, 1] = Tuesday_7;
            classes[0, 2] = Wednesday_1;
            classes[1, 2] = Wednesday_2;
            classes[2, 2] = Wednesday_3;
            classes[3, 2] = Wednesday_4;
            classes[4, 2] = Wednesday_5;
            classes[5, 2] = Wednesday_6;
            classes[6, 2] = Wednesday_7;
            classes[0, 3] = Thursday_1;
            classes[1, 3] = Thursday_2;
            classes[2, 3] = Thursday_3;
            classes[3, 3] = Thursday_4;
            classes[4, 3] = Thursday_5;
            classes[5, 3] = Thursday_6;
            classes[6, 3] = Thursday_7;
            classes[0, 4] = Friday_1;
            classes[1, 4] = Friday_2;
            classes[2, 4] = Friday_3;
            classes[3, 4] = Friday_4;
            classes[4, 4] = Friday_5;
            classes[5, 4] = Friday_6;
            classes[6, 4] = Friday_7;
        }
    }
}
