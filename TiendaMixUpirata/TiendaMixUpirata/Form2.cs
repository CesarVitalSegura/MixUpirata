﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TiendaMixUpirata
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();

            form3.Show(Form3.ActiveForm);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();

            form4.Show(Form4.ActiveForm);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();

            form8.Show(Form8.ActiveForm);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();

            form8.Show(Form8.ActiveForm);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form8 form8 = new Form8();

            form8.Show(Form8.ActiveForm);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
