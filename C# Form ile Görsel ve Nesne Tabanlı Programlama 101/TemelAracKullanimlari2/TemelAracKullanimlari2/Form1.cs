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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void yazdırmaKomutlarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            label1.Text = "Yazdırma komutları sekmesine tıklandı.";
        }

        private void sarıToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Yellow; // Form arka planını değiştirir.
        }

        private void maviToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Blue;
        }

        private void turuncuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Pink;
        }

        private void turuncuToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            this.BackColor = Color.Orange;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void googleToolStripMenuItem_Click(object sender, EventArgs e)
        { //formdan webBrowser aracılığıyla google a geçiş yapıldı.
            webBrowser1.Navigate("https://www.google.com");
        }

        private void youtubeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.youtube.com");
        }

        private void xToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.x.com");
        }

        private void facebookToolStripMenuItem_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate("https://www.facebook.com");
        }

        int sayac = 0;
        private void başlatToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            sayac++;
            label2.Text = sayac.ToString();
        }

        private void btnBaslat_Click(object sender, EventArgs e)
        {
            timer2.Start();
        }

        private void btnDurdur_Click(object sender, EventArgs e)
        {
            timer2.Stop();
        }
        int sure = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            this.Text= sure.ToString(); // sure formun başlığına yazdırıldı.
            sure++;
            if(sure>=0 && sure < 30)
            {
                panel1.BackColor = Color.Red;
               // panel3.BackColor = Color.Transparent;
            }
            if(sure >= 30 && sure < 40)
            {
                panel2.BackColor = Color.Yellow;
            }
            if (sure >= 40 && sure <= 70)
            {
                panel3.BackColor = Color.Green;
                panel1.BackColor = Color.Transparent;
                panel2.BackColor = Color.Transparent;

            }
            if (sure == 71)
            {
                sure = 0;
            }
        }
    }
}
