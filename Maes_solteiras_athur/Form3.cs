﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Maes_solteiras_athur
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            {
                Form1 form1 = new Form1();
                form1.Show();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            {
                Form2 form2 = new Form2();
                form2.Show();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            login login = new login();
            login.Show();
        }
    }
}
