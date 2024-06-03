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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            int s1, s2, s3, ort;
            string durum;
            s1 = Convert.ToInt16(txtSinav1.Text);
            s2 = Convert.ToInt16(txtSinav2.Text);
            s3 = Convert.ToInt16(txtSinav3.Text);
            ort = (s1 + s2 + s3) / 3;

            txtOrtalama.Text = ort.ToString();
            if(ort >= 50)
            {
                durum = "Geçti";
            }else
            {
                durum = "Kaldı";
            }
            txtDurum.Text = durum;

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtOrtalama.Text != "" && txtDurum.Text != "")
            {
                string adSoyad, ders, numara;
                adSoyad = txtAdSoyad.Text;
                ders = comboBox1.Text;
                numara = maskedTextBox1.Text;
                listBox1.Items.Add("AdSoyad: " + adSoyad + " Ders: " + ders + " Numara: " + numara + " Durum: " + txtDurum.Text + " Ort: " + txtOrtalama.Text);
                //eğer kaydetme işlemi başarılıysa aşağıda sayacaı bir attırıp label10 text ine atıyoruz.
                sayac++;
                label10.Text = "Kaydedilen Öğrenci Sayısı:" + sayac;

            }
            else
            {
                MessageBox.Show("Lütfen Durum ve ortalama hesabını yapınız", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listBox1.Items.Add("----------------------------------------");
        }

        int sayac = 0;
        private void btnSayac_Click(object sender, EventArgs e)
        {
            sayac++;
            label10.Text = sayac.ToString(); //sayaca değişkeni integer bir değişkendir ve
                                             //label a yazdırmak için bu değişkeni stringe çeviriyoruz.
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            txtAdSoyad.Text = "";
            txtDurum.Text = "";
            txtOrtalama.Text = "";
            txtSinav1.Text = "";
            txtSinav2.Text = "";
            txtSinav3.Text = "";
            comboBox1.SelectedIndex = -1;
            maskedTextBox1.Text = "";
            listBox1.Text = "";

        }

        private void btnMesajKutusu_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Ekisk bilgi girdiniz. Lütfen tekrar deneyiniz.","Kutu Başlığı",MessageBoxButtons.YesNo,MessageBoxIcon.Exclamation);

        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
          
        }

        private void btnForDongusu_Click(object sender, EventArgs e)
        {
            for(int i = 0; i<= 10; i++)
            {
                listBox2.Items.Add(i + " - Merhaba");
            }
        }

        private void btnForDongusu2_Click(object sender, EventArgs e)
        {
            for (int i = 1; i <= 20; i++)
                if(i % 3 == 0)
            {
                listBox2.Items.Add(i);
            }
        }

        private void btnlistBoxTemizle_Click(object sender, EventArgs e)
        {
           listBox2.Items.Clear();
        }

        private void btnWhileDongusu_Click(object sender, EventArgs e)
        {
            int x = 1;
            while (x <= 10)
            {
                listBox2.Items.Add(x + "- While Döngüsü");
                x++;
            }
        }

        private void btnDizi1_Click(object sender, EventArgs e)
        {
            string[] sehirler = { "Kocaeli", "İstanbul", "Adana", "Erzurum", "İzmir", "Ordu" };
            txtAdSoyad.Text = sehirler[4];
        }

        private void btnDizi2_Click(object sender, EventArgs e)
        {
            int[] sayilar = { 12, 23, 34, 45, 45, 33, 24, 56, 100 };
            //for (int i = 0; i < sayilar.Length; i++)
            //{
            //    listBox2.Items.Add(sayilar[i]);
            //}
            foreach (int o in sayilar)
            {
                if (o % 4 == 0)
                {
                    listBox2.Items.Add(o);
                }
            }
        }
    }
}
