using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemelAracKullanimlari2
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            checkBox2.Checked= true; // buttona tıkladığımızda checkbox ın işaretli olarak getirmesini istedik.
            radioButton2.Checked= true;
        }
    }
}
