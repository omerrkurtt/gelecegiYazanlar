using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace UrunTakip
{
    public partial class Frmistatistik : Form
    {
        public Frmistatistik()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8344545;Initial Catalog=DbUrun;Integrated Security=True;");

        private void Frmistatistik_Load(object sender, EventArgs e)
        {
            //Toplam Kategori Sayısı

            baglanti.Open();
            SqlCommand komut1 = new SqlCommand("Select COUNT(*) From TblKategori", baglanti);
            SqlDataReader dr = komut1.ExecuteReader(); // dr nesnesi komut1 den gelen değeri okuyup çalıştıracak.
            while (dr.Read()) //dr komutu okuma işlemi yaptığı sürece // birden başla kayıt da gelebilir.
            {
                lblToplamKategori.Text = dr[0].ToString(); // neden 0. index? Çünkü bir tane veri girilecek o da 0. indexdir.
            }
            baglanti.Close();

            //Toplam Urun Sayısı

            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("Select COUNT(*) From TblUrunler", baglanti);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LblToplamUrun.Text = dr2[0].ToString();
            }
            baglanti.Close();

            baglanti.Close();

            //Toplam Beyaz Eşya Sayısı

            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Select COUNT(*) FROM TblUrunler where Kategori=(select ID From TblKategori where Ad ='Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                lblBeyazEsya.Text = dr3[0].ToString();
            }
            baglanti.Close();

            //Toplam Küçük Ev Aletleri

            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Select COUNT(*) FROM TblUrunler where Kategori=(select ID From TblKategori where Ad ='Küçük Ev Aletleri')", baglanti);
            SqlDataReader dr4 = komut4.ExecuteReader();
            while (dr4.Read())
            {
                lblKucukEvAletleri.Text = dr4[0].ToString();
            }
            baglanti.Close();

            //Toplam Yüksek Stoklu Beyaz Eşya Sayısı

            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Select * From TblUrunler where Stok=(Select MAX(Stok) From TblUrunler)\r\n ", baglanti);
            SqlDataReader dr5 = komut5.ExecuteReader();
            while (dr5.Read())
            {
                lblYuksekStok.Text = dr5[0].ToString();
            }
            baglanti.Close();

            //Toplam Düşük Stoklu Beyaz Eşya Sayısı

            baglanti.Open();
            SqlCommand komut6 = new SqlCommand("Select * From TblUrunler where Stok=(Select MAX(Stok) From TblUrunler)\r\n ", baglanti);
            SqlDataReader dr6 = komut6.ExecuteReader();
            while (dr6.Read())
            {
                lblDusukStok.Text = dr6["UrunAd"].ToString();
            }
            baglanti.Close();

            //lAPTOP Toplam Kar Oranı:
            baglanti.Open();
            SqlCommand komut7 = new SqlCommand("Select Stok*(SatisFiyat - AlisFiyat) From TblUrunler where UrunAd='Laptop' ", baglanti);
            //Ürün adı laptop olanların toplam karına bakıldı.
            SqlDataReader dr7 = komut7.ExecuteReader();
            while (dr7.Read())
            {
                lblToplamLaptopKarOrani.Text = dr7[0].ToString()+ " ₺";
            }
            baglanti.Close();

            //Beyaz Eşya Toplam Kar Oranı:
            baglanti.Open();
            SqlCommand komut8 = new SqlCommand("Select Sum(stok*(SatisFiyat-AlisFiyat)) as 'Toplam Stokla Çarpılan Sonuç'\r\nfrom TblUrunler  where Kategori = (select ID From TblKategori where Ad='Beyaz Eşya')", baglanti);
            SqlDataReader dr8 = komut8.ExecuteReader();
            while (dr8.Read())
            {
                lblBeyazEsyaToplamKar.Text = dr8[0].ToString() + " ₺";
            }
            baglanti.Close();
        }
    }
}
