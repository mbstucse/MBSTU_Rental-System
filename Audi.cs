﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp3
{
    public partial class Audi : Form
    {
        public Audi()
        {
            InitializeComponent();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            BookMain bm = new BookMain();
            this.Hide();
            bm.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
                CMain cm = new CMain();
            this.Hide();
            cm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            U cm = new U();
            this.Hide();
            cm.Show();
        }
    }
}
