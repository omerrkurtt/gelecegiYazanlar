using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DosyaIslemleri
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnKonumSec_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            label1.Text= folderBrowserDialog1.SelectedPath;
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            label1.Text=openFileDialog1.FileName; //FolderBrowserDialog ile karıştırma!!(selecetedPath-FileName)
        }

        private void btnSaveFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        string belgeYolu, belgeAdi;

        private void btnOlustur_Click(object sender, EventArgs e)
        {
            belgeAdi=txtAd.Text;
            StreamWriter sw = File.CreateText(belgeYolu + "\\" + belgeAdi + ".txt"); //Metin belgesi oluştruldu.
            MessageBox.Show("Belgeniz Başarıyla Oluşturuldu", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            //message box daki ilk tırnak gösterilecek metni, ikinci tırnak kutu üstündeki başlığı,
            //...üçüncüsü gösterilecek butonu, dördüncüsü ise bilgi verileceği için bilge ait bir ikonu gösterir.

        }
        //okunan değerleri listbox a aktaracağız
        private void btnOku_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            // Eğer kullanıcı bir dosya seçip "OK" düğmesine basarsa, if bloğu çalışır.
            {
                StreamReader oku = new StreamReader(openFileDialog1.FileName); //kullanıcının seçtiği dosyanın yolunu içerir.
                                                                               //Bu yol, StreamReader ile okunan dosyanın yolunu belirler..

                string satir = oku.ReadLine();
                while (satir != null) //döngüsü, dosyanın sonuna gelene kadar çalışır.
                {
                    listBox1.Items.Add(satir);// satır değişkeninde gelen değeri listbox a ekle.
                    satir = oku.ReadLine(); // ReadLine metodu null döndüğünde dosya sonuna gelinmiş demektir.

                }
            }
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            //yazdirma işleminde saveFileDialog nesnesine ihityaç vardır.
            saveFileDialog1.Filter = "Metin Dosyası |*.txt"; // Dosya kaydetme iletişim kutusunun filtresini ayarlar.
                                                             // Bu, kullanıcının sadece metin dosyalarını
                                                             // (*.txt uzantılı dosyalar) kaydedebileceğini belirtir.

            saveFileDialog1.ShowDialog(); // Kullanıcıya dosya kaydetme iletişim kutusunu gösterir
                                          // ve bir dosya seçmesini bekler. Kullanıcı bir dosya seçip
                                          // "Tamam" düğmesine tıklarsa, işlem devam eder.

            StreamWriter kaydet = new StreamWriter(saveFileDialog1.FileName); //StreamWriter sınıfını kullanarak, seçilen dosyayı yazma modunda açar.
                                                                              //Dosya adı, saveFileDialog1.FileName ile alınır.

            kaydet.WriteLine(richTextBox1.Text); //richtextBox dan gelen veriyi satır satır oku.
            kaydet.Close(); // Dosya yazma işlemi tamamlandıktan sonra dosyayı kapatır.
            MessageBox.Show("Metin Belgesine Kayır Yapıldı", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Warning);

        }

        private void btnKonum_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) //dialog ekranında tamam tuşuna basıldığında yapılacak döngü.
            {
                belgeYolu = folderBrowserDialog1.SelectedPath;
                txtYol.Text = belgeYolu;
            }
            
        }
        
    }
}
