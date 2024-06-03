using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UrunTakip
{
    public partial class FrmAdmin : Form
    {
        public FrmAdmin()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8344545;Initial Catalog=DbUrun;Integrated Security=True;");

        private void button1_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand("Select * From TblAdmin where Kullanici=@p1 and Sifre=@p2",baglanti);
            komut.Parameters.AddWithValue("@p1",txtKullanici.Text);
            komut.Parameters.AddWithValue("@p2", txtSifre.Text);
            SqlDataReader dr = komut.ExecuteReader();
            if (dr.Read()) // eğer dr nesnesinin okuduğu değerler doğruysa
            {
                FrmYonlendirme fr = new FrmYonlendirme();
                fr.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Lütfen bilgileri tekrar deneyiniz.");
            }
            baglanti.Close();

        }
    }
}
