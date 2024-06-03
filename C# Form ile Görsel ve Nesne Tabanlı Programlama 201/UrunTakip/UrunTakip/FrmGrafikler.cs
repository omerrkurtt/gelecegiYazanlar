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

    public partial class FrmGrafikler : Form
    {
        public FrmGrafikler()
        {
            InitializeComponent();
        }
        //sqlclient kütüphanesini dahil etmeyi unutma
        SqlConnection baglanti = new SqlConnection("Data Source=DESKTOP-8344545;Initial Catalog=DbUrun;Integrated Security=True;");
        private void FrmGrafikler_Load(object sender, EventArgs e)
        {
            baglanti.Open();
            SqlCommand komut = new SqlCommand(" Select Ad,COUNT(*) From TblUrunler inner join TblKategori\r\non TblUrunler.Kategori = TblKategori.ID\r\ngroup by Ad ",baglanti);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chart1.Series["Kategori"].Points.AddXY(dr[0], dr[1]);
            }
            baglanti.Close();
        }
    }
}
