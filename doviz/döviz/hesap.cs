using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace döviz
{
    public partial class hesap : Form
    {
        public hesap()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void hesap_Load(object sender, EventArgs e)
        {
            groupBox1.Text = Form1.gonderilecekveri;
            label3.Text = "1 " + Form1.gonderilecekveri + " = " + Form1.gonderilecekveri2 + " TL ";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text=="")
            {
                label3.Text = "1 " + Form1.gonderilecekveri + " = " + Form1.gonderilecekveri2 + " TL ";
            }
            else {
                decimal x = Convert.ToDecimal(Form1.gonderilecekveri2) * Convert.ToDecimal(textBox1.Text);
                label3.Text = textBox1.Text + Form1.gonderilecekveri + " = " + x + " TL "; ;
            }
            
        }
    }
}
