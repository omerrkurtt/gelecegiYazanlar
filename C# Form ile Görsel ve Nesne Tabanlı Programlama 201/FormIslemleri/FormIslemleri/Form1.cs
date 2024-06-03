using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FormIslemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        void kodOlustur()
        {
            Random rastgele = new Random();
            int sayi = rastgele.Next(10000, 100000);
            txtKod2.Text = sayi.ToString(); //Oluşturulan rastgele sayı, bir metin kutusuna (txtKod2)
                                            //yerleştirilmeden önce metin formatına dönüştürülür. Bunun nedeni,
                                            //metin kutusu üzerindeki Text özelliğinin sadece metin kabul etmesidir. 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            kodOlustur();
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            if(txtKullaniciAdi.Text =="admin" && txtSifre.Text=="1234" && txtKod1.Text == txtKod2.Text)
            {
                Form2 frm2 = new Form2();
                frm2.kullanici = txtKullaniciAdi.Text;
                frm2.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Hatalı Şifre Girişi: Kullanıcı adı, şifre veya kod yanlış girildi!!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        int sayac = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++; //timer başladığında sayaç 1 artsın
            if(sayac % 2 == 0)
            {
                label3.BackColor = Color.YellowGreen;
            }
            else
            {
                label3.BackColor = Color.Orange;

            }if(sayac == 10)
            {
                sayac = 10; //sayac 10 a geldiğinde sıfırla
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Form3 frm3 = new Form3();
            frm3.Show();
        }
    }
}
