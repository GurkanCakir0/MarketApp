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
            string dosyaYolu = "UrunVeri.txt";

            try
            {
                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    string satir;
                    while ((satir = sr.ReadLine()) != null)
                    {
                        string[] parcalar = satir.Split(',');

                        if (parcalar.Length != 3)
                            continue;

                        int kodu = int.Parse(parcalar[0]);
                        string adi = parcalar[1];
                        double fiyat = double.Parse(parcalar[2]);

                        dataGridView1.Rows.Add(kodu, adi, fiyat);
                    }
                }

                MessageBox.Show("Veriler başarıyla yüklendi.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okunurken bir hata oluştu: " + ex.Message);
            }


            Cursor.Current = Cursors.WaitCursor;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "(*.txt)|*.txt";
            sf.FileName = "UrunDatam";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    int kodu = Convert.ToInt32(dataGridView1.Rows[i].Cells["UrunKodu"].Value);

                    string adi = dataGridView1.Rows[i].Cells["UrunAdi"].Value.ToString();
                    double fiyat = Convert.ToDouble(dataGridView1.Rows[i].Cells["Urunkg"].Value);

                    string içerik = kodu.ToString() + ";" + "\t\t" + adi + ";" + "\t\t" + fiyat.ToString("N2");
                    File.AppendAllText(sf.FileName, içerik + Environment.NewLine);
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void ekle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox1.Text, out int k) && !string.IsNullOrWhiteSpace(textBox2.Text) && double.TryParse(textBox3.Text.Trim(), out double f))
            {
                bool sonuc = false;
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["UrunKodu"].Value != null && (int)row.Cells["UrunKodu"].Value == k)
                    {
                        sonuc = true;
                        break;
                    }
                }
                if (sonuc)
                {
                    MessageBox.Show("Bu ürün kodu zaten mevcut. Lütfen farklı bir kod girin.");
                }
                else
                {
                    string a = textBox2.Text.Trim();
                    market.Ekle(k, a, f);
                    textBox1.Clear();
                    textBox2.Clear();
                    textBox3.Clear();
                    MessageBox.Show("Ürün Başarıyla Kaydedildi");
                }
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir Veri Giriniz");
            }

        }

        private void sil_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox4.Text, out int k))
            {
                market.Sil(k);
                textBox4.Clear();
                textBox5.Clear();
                textBox6.Clear();
                
            }
            else
            {
                MessageBox.Show("Lütfen geçerli bir ürün kodu girin.");
            }

        }

        private void guncelle_Click(object sender, EventArgs e)
        {
            if (int.TryParse(textBox7.Text, out int k)  && double.TryParse(textBox9.Text.Trim(), out double yf))
            {
                market.Guncelle(k, yf);
                textBox7.Clear();
                textBox8.Clear();
                textBox9.Clear();
            }
            else
            {
                MessageBox.Show("Lütfen Geçerli Bir Veri Giriniz");
            }

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
}
        
         
         



        Cursor.Current = Cursors.WaitCursor;
            SaveFileDialog sf = new SaveFileDialog();
            sf.Filter = "(*.txt)|*.txt";
            sf.FileName = "UrunDatam";
            if (sf.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(sf.FileName, FileMode.OpenOrCreate, FileAccess.Write);
                fs.Close();

                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {

                    int kodu = Convert.ToInt32(dataGridView1.Rows[i].Cells["UrunKodu"].Value);

                    string adi = dataGridView1.Rows[i].Cells["UrunAdi"].Value.ToString();
                    double fiyat = Convert.ToDouble(dataGridView1.Rows[i].Cells["Urunkg"].Value);

                    string içerik = kodu.ToString() + ";" + "\t\t" + adi + ";" + "\t\t" + fiyat.ToString("N2");
                    File.AppendAllText(sf.FileName, içerik + Environment.NewLine);
                }
            }
            Cursor.Current = Cursors.Default;
         
         
         
         
         
         
         
         */
    }
}
