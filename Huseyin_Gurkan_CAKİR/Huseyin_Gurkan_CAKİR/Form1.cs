using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Huseyin_Gurkan_CAKİR
{
    public partial class MARKETAPP : Form
    {
        marketdoulby market = new marketdoulby();
        public MARKETAPP()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var urunler = File.ReadLines(@"C:\Users\GURKAN\source\repos\MarketApp\Huseyin_Gurkan_CAKİR\Huseyin_Gurkan_CAKİR\Urun Data.txt");

        }

        private void ekle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int k) && !string.IsNullOrWhiteSpace(textBox2.Text) && double.TryParse(textBox3.Text.Trim(), out double f))
            {
                string a = textBox2.Text.Trim();
                market.Ekle(k, a, f);
                textBox1.Clear();
                textBox2.Clear();
                textBox3.Clear();
                MessageBox.Show("Ürün Başarıyla Kaydedildi");
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir Veri Giriniz");
            }
            ListeleUrunler();
        }

        private void sil_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int k))
            {
                market.Sil(k);
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                MessageBox.Show("Ürün Silindi");
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün kodu girin.");
            }
            ListeleUrunler();
        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox7.Text, out int k)  && double.TryParse(textBox9.Text.Trim(), out double yf))
            {
                market.Guncelle(k, yf);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
                MessageBox.Show("Ürün Fiyatı Güncellendi");
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir Veri Giriniz");
            }
            ListeleUrunler();
        }
        private void ListeleUrunler()
        {
            dataGridView1.Rows.Clear();

            List<Urun> urunler = market.Listele();

            foreach (Urun urun in urunler)
            {
                dataGridView1.Rows.Add(urun.kodu, urun.adi, urun.fiyat);
            }
        }

        private void listele_Click(object sender, EventArgs e)
        {
            ListeleUrunler();
        }

        private void bul_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int k))
            {
                Urun urun = market.UrunBul(k);
                if (urun != null)
                {
                    textBox4.Text = urun.kodu.ToString();
                    textBox5.Text = urun.adi;
                    textBox6.Text = urun.fiyat.ToString();
                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı");
                }

            }
        }

        private void bul1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox7.Text, out int k))
            {
                Urun urun = market.UrunBul(k);
                if (urun != null)
                {
                    textBox7.Text = urun.kodu.ToString();
                    textBox8.Text = urun.adi;
                    textBox9.Text = urun.fiyat.ToString();
                }
                else
                {
                    MessageBox.Show("Ürün Bulunamadı");
                }

            }
        }

        private void DosyaOlustur()
        {


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "Text Dosyası (*.txt)|*.txt";
            sf.FileName = "Urun Data";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {

                    int kodu = Convert.ToInt32(dataGridView1.Rows[i].Cells["UrunKodu"].Value);
                    string adi = dataGridView1.Rows[i].Cells["UrunAdi"].Value.ToString();
                    double fiyat = Convert.ToDouble(dataGridView1.Rows[i].Cells["Urunkg"].Value);

                    string içerik = kodu.ToString() + ";" + "\t\t" + adi + ";" + "\t\t" + fiyat.ToString("N2");
                    File.AppendAllText(sf.FileName, içerik + Environment.NewLine);
                }
            }
            Cursor.Current = Cursors.Default;
            /*TextWriter writer = new StreamWriter(@"C:\Users\GURKAN\source\repos\MarketApp\Huseyin_Gurkan_CAKİR\Huseyin_Gurkan_CAKİR\UrunData.txt");

            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                for (int j = 0; j < dataGridView1.Columns.Count; j++)
                {
                    writer.Write("\t" + dataGridView1.Rows[i].Cells[j].Value.ToString());
                }
                writer.WriteLine("");
            }
            writer.Close();*/
        }
        /*private void DosyaOlustur1()
{
   Cursor.Current = Cursors.WaitCursor;
   SaveFileDialog sf = new SaveFileDialog();
   sf.Filter = "Text Dosyası (*.txt)|*.txt";
   sf.FileName = "Urun Data";
   if (sf.ShowDialog() == DialogResult.OK)
   {
       FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
       fs.Close();
       for (int i = 0; i < dataGridView1.Rows.Count; i++)
       {

           int kodu = Convert.ToInt32(dataGridView1.Rows[i].Cells["UrunKodu"].Value);
           string adi = dataGridView1.Rows[i].Cells["UrunAdi"].Value.ToString();
           double fiyat = Convert.ToDouble(dataGridView1.Rows[i].Cells["Urunkg"].Value);

           string içerik = kodu.ToString() + ";" + "\t\t" + adi + ";" + "\t\t" + fiyat.ToString("N2");
           File.AppendAllText(sf.FileName, içerik + Environment.NewLine);
       }
   }
   Cursor.Current = Cursors.Default;
}*/
    }
}
