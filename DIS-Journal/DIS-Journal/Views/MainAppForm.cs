﻿using System;
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
    public partial class MainAppForm : Form
    {
        Color primary, secondary;
        Image hover;
        public MainAppForm(Color pr, Color se)
        {
            InitializeComponent();
            primary = pr;
            secondary = se;
        }

        private void MainAppForm_Load(object sender, EventArgs e)
        {
            switch (primary.R)
            {
                case 58:
                    hover = Image.FromFile("main_form/ihover.png");
                    break;
                case 105:
                    hover = Image.FromFile("main_form/vhover.png");
                    break;
                default:
                    hover = Image.FromFile("main_form/nhover.png");
                    break;
            }
            panel1.BackColor = primary;
            button1.BackColor = primary;
            button2.BackColor = primary;
        }

        private void button1_MouseEnter(object sender, EventArgs e)
        {
            button1.BackgroundImage = hover;
        }

        private void button1_MouseLeave(object sender, EventArgs e)
        {
            if(button1.ForeColor != Color.White)
            {
                button1.BackgroundImage = null;
                button1.BackColor = primary;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            button1.ForeColor = Color.White;
            button1.BackgroundImage = hover;
            if(button2.ForeColor == Color.White)
            {
                button2.BackgroundImage = null;
                button2.BackColor = primary;
                button2.ForeColor = Color.WhiteSmoke;
            }
            if(button3.ForeColor == Color.White)
            {
                button3.BackgroundImage = null;
                button3.BackColor = primary;
                button3.ForeColor = Color.WhiteSmoke;
            }
            if (object.ReferenceEquals(DesignController.Journal, null))
            {
                DesignController.Journal = new JournalForm(primary, secondary, hover);
            }
            DesignController.OpenFormInApp(DesignController.Journal);
        }

        private void button2_MouseEnter(object sender, EventArgs e)
        {
            button2.BackgroundImage = hover;
        }

        private void button2_MouseLeave(object sender, EventArgs e)
        {
            if (button2.ForeColor != Color.White)
            {
                button2.BackgroundImage = null;
                button2.BackColor = primary;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            button2.ForeColor = Color.White;
            button2.BackgroundImage = hover;
            if (button1.ForeColor == Color.White)
            {
                button1.BackgroundImage = null;
                button1.BackColor = primary;
                button1.ForeColor = Color.WhiteSmoke;
            }
            if (button3.ForeColor == Color.White)
            {
                button3.BackgroundImage = null;
                button3.BackColor = primary;
                button3.ForeColor = Color.WhiteSmoke;
            }
            if (object.ReferenceEquals(DesignController.Schedule, null))
            {
                DesignController.Schedule = new ScheduleForm(primary, secondary, hover);
            }
            DesignController.OpenFormInApp(DesignController.Schedule);
        }

        private void button3_MouseEnter(object sender, EventArgs e)
        {
            button3.BackgroundImage = hover;
        }

        private void button3_MouseLeave(object sender, EventArgs e)
        {
            if (button3.ForeColor != Color.White)
            {
                button3.BackgroundImage = null;
                button3.BackColor = primary;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.ForeColor = Color.White;
            button3.BackgroundImage = hover;
            if (button1.ForeColor == Color.White)
            {
                button1.BackgroundImage = null;
                button1.BackColor = primary;
                button1.ForeColor = Color.WhiteSmoke;
            }
            if (button2.ForeColor == Color.White)
            {
                button2.BackgroundImage = null;
                button2.BackColor = primary;
                button2.ForeColor = Color.WhiteSmoke;
            }
            if (object.ReferenceEquals(DesignController.Archive, null))
            {
                DesignController.Archive = new ArchiveForm(primary, secondary);
            }
            DesignController.OpenFormInApp(DesignController.Archive);
        }
    }
}
