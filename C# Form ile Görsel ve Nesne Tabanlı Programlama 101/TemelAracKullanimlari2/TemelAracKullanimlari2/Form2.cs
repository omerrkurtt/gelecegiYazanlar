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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // bolge serisindeki x ve y kordinatlarına değerler girildi
            chart1.Series["Bolge"].Points.AddXY("Akdeniz",10);
            chart1.Series["Bolge"].Points.AddXY("Doğu Anadolu", 15);
            chart1.Series["Bolge"].Points.AddXY("Karadeniz", 20);
            chart1.Series["Bolge"].Points.AddXY("İç Anadolu", 25);
            chart1.Series["Bolge"].Points.AddXY("GüneyDoğu Anadolu", 30);
            chart1.Series["Bolge"].Points.AddXY("Ege", 35);
            chart1.Series["Bolge"].Points.AddXY("Marmara", 90);


        }

        private void btnArttır_Click(object sender, EventArgs e)
        {
            progressBar1.Value += 10;
        }

        private void btnAzalt_Click(object sender, EventArgs e)
        {
            progressBar1.Value -= 10;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            prgIslem1.Value  += 1;
            if (prgIslem1.Value == 100)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            prgIslem2.Value += 10;
            if (prgIslem2.Value == 100)
            {
                timer2.Stop();
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            PrgIslem3.Value += 20;
            if (PrgIslem3.Value == 100)
            {
                timer3.Stop();
                MessageBox.Show("İşlemler başarıyla tamamlandı.");
            }
                     
        }
    }
}
