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

        public ScheduleForm(Color pr, Color se, Image h)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
            hover = h;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddSubjectPopUp pop = new AddSubjectPopUp(primary, secondary, hover);
            pop.Show();
        }
    }
}
