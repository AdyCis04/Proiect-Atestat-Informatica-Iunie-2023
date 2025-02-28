using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MATRIX_CALCULATOR
{
    public partial class Form4 : Form
    {
        int i = 0;
        Form1 f = new Form1();

        public Form4()
        {
            InitializeComponent();
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            i++;
            if (i == 5)
            {
                f.Show();
                this.Hide();
                f.FormClosing += new System.Windows.Forms.FormClosingEventHandler(AfterClosingMC);
            }

        }

        private void AfterClosingMC(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
