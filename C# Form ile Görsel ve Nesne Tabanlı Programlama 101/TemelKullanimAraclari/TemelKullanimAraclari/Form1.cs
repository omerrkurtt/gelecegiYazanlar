using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemelKullanimAraclari
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label6.Text = comboBox1.Text;
            label8.Text = textBox1.Text;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("Javascript");
            listBox1.Items.Add("PostgreSQL");
            listBox1.Items.Add("JAVA");
            listBox1.Items.Add(textBox1.Text);

        }
    }
}
