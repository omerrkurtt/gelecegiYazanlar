using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunTakip
{
    public partial class FrmYonlendirme : Form
    {
        public FrmYonlendirme()
        {
            InitializeComponent();
        }

        private void FrmYonlendirme_Load(object sender, EventArgs e)
        {

        }

        private void pnlUrun_Click(object sender, EventArgs e)
        {
            Form1 urun = new Form1();
            urun.Show();
        }

        private void pnlKategori_Click(object sender, EventArgs e)
        {
            Form1 kat = new Form1();
            kat.Show();
        }

        private void pnlIstatik_Click(object sender, EventArgs e)
        {
            Frmistatistik frm = new Frmistatistik();
            frm.Show();
        }

        private void pnlGrafikler_Click(object sender, EventArgs e)
        {
            FrmGrafikler fr = new FrmGrafikler();
            fr.Show();
        }

        private void pnlLogin_Click(object sender, EventArgs e)
        {
            FrmAdmin fr = new FrmAdmin();
            fr.Show();
            this.Hide();
        }
    }
}
