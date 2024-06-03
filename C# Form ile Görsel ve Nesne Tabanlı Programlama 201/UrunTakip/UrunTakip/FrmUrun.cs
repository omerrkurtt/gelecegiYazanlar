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
    public partial class FrmUrun : Form
    {
        public FrmUrun()
        {
            InitializeComponent();
        }
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8344545;Initial Catalog=DbUrun;Integrated Security=True;");

        private void LblKategoriAdi_Click(object sender, EventArgs e)
        {

        } 
        private void btnUrunListele_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand(" Select UrunID,UrunAd,Stok,AlisFiyat,SatisFiyat,Ad,Kategori From TblUrunler\r\nInner join TblKategori -- üst satırı tblkategori tablosuyla birleştirdik.\r\nOn TblUrunler.Kategori = TblKategori.ID", baglanti);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns["Kategori"].Visible = false; // kategori isimli sütun kullanıya görünmesini istemedik.
            
        }
        private void FrmUrun_Load(object sender, EventArgs e)
        {
            SqlCommand komut2 = new SqlCommand("Select * from TblKategori", baglanti);
            SqlDataAdapter da2 = new SqlDataAdapter(komut2);
            DataTable dt = new DataTable();
            da2.Fill(dt);
            dataGridView1.DataSource = dt;
            comboBox1.DisplayMember = "Ad"; // kullanıcıya görünecek kısım
            comboBox1.ValueMember = "ID"; // arka planda çalışan kısım
            comboBox1.DataSource = dt;
        }

        private void btnUrunKaydet_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut3 = new SqlCommand("insert into TblUrunler (UrunAd,Stok,AlisFiyat,SatisFiyat,Kategori) values (@p1,@p2,@p3,@p4,@p5)",baglanti);
            komut3.Parameters.AddWithValue("@p1", txtAD.Text);
            komut3.Parameters.AddWithValue("@p2", numericUpDown1.Value);
            komut3.Parameters.AddWithValue("@p3", txtAlisFiyat.Text);
            komut3.Parameters.AddWithValue("@p4", txtSatisFiyat.Text);
            komut3.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut3.ExecuteNonQuery(); //değişiklikleri veritabanına yansıtmak için.
            baglanti.Close();
            MessageBox.Show("Ürün kaydı başarıyla gerçekleşti.");

        }

        private void btnUrunSil_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut4 = new SqlCommand("delete from TblUrunler where urunID=@p1", baglanti);
            komut4.Parameters.AddWithValue("@p1",txtID.Text);
            komut4.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Silme İşlem başarıyla gerçekleşti.");

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // e : seçili olan
            txtID.Text = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            txtAD.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
            numericUpDown1.Value = int.Parse(dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString());
            txtAlisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
            txtSatisFiyat.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(); 
            comboBox1.SelectedValue = dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString();
        }

        private void btnUrunGuncelle_Click(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut5 = new SqlCommand("Update tblUrunler set urunAd=@p1,Stok=@p2,AlisFiyat=@p3,SatisFiyat=@p4,Kategori=@p5 where urunID=@p6", baglanti);
            //Bu kısımda sadece urunID değeri @p6 parametresine eşit olan
            //kaydın güncellenmesini sağlar. Bu ifade sayesinde yalnızca
            //belirli bir ürün güncellenir, diğerleri etkilenmez.
            komut5.Parameters.AddWithValue("@p1", txtAD.Text);
            komut5.Parameters.AddWithValue("@p2", numericUpDown1.Value);
            komut5.Parameters.AddWithValue("@p3", decimal.Parse(txtAlisFiyat.Text));
            komut5.Parameters.AddWithValue("@p4", decimal.Parse(txtSatisFiyat.Text));
            komut5.Parameters.AddWithValue("@p5", comboBox1.SelectedValue);
            komut5.Parameters.AddWithValue("@p6", txtID.Text);
            komut5.ExecuteNonQuery();
            baglanti.Close();
            MessageBox.Show("Güncelleme işlemi başarıyla gerçekleşti", "Güncelleme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }
    }
}
