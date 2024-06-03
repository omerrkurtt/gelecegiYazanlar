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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        //sql kütüphanesini dahil etmeyi unutma
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8344545;Initial Catalog=DbUrun;Integrated Security=True;");
        private void btnListele_Click(object sender, EventArgs e)
        {
            
            SqlCommand komut = new SqlCommand("Select * From TblKategori",baglanti);
            //sqlcommand sınıfıyla baglanti veritabanından tabloları çağırdık.
            SqlDataAdapter da = new SqlDataAdapter(komut);
            // komut sınıfından gelen komutları köprüledik
            DataTable dt = new DataTable(); // bunu da köprüden(SqlDataAdapter) gelen değerlerle dolduracağız.
            da.Fill(dt); //Fill:Doldurmak dataadaptergelen gelen veriyi datatable ile doldur
            dataGridView1.DataSource= dt; //datatable dan gelen değerleri datagridview e attık

        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut2 = new SqlCommand("insert into TblKategori (Ad) Values (@p1)", baglanti);
            komut2.Parameters.AddWithValue("@p1", txtKategori.Text);// p1 parametresi txtkategorisinden gelen değeri alacak
            komut2.ExecuteNonQuery(); // sorguyu çalıştır.
            baglanti.Close();
            MessageBox.Show("Kategoriniz başarılı bir şekilde eklendi.");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("Delete From TblKitaplar where ID=@p1", baglanti);
            komut3.Parameters.AddWithValue("@p1", txtID.Text);
            komut3.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori silme işlemi başarıyla tamamlandı.");

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("Update TblKategori set Ad=@p1 where ID=@p2", baglanti);
            komut4.Parameters.AddWithValue("@p1", txtKategori.Text);
            komut4.Parameters.AddWithValue("@p2", txtID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Kategori güncelleme işlemi başarıyla tamamlandı.");

        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            SqlCommand komut5 = new SqlCommand("Select * From TblKategori Where Ad=@p1", baglanti);
            //sqlcommand sınıfıyla baglanti veritabanından tabloları çağırdık.
            komut5.Parameters.AddWithValue("@p1", txtKategori.Text);
            SqlDataAdapter da = new SqlDataAdapter(komut5);
            // komut sınıfından gelen komutları köprüledik
            DataTable dt = new DataTable(); // bunu da köprüden(SqlDataAdapter) gelen değerlerle dolduracağız.
            da.Fill(dt); //Fill:Doldurmak dataadaptergelen gelen veriyi datatable ile doldur
            dataGridView1.DataSource = dt;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}//Data Source=DESKTOP-8344545;Initial Catalog=DbUrun;Integrated Security=True;Trust Server Certificate=True