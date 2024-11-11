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
            Listele();
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
                    dataGridView1.Rows.Add(k, a, f);
                    YazDosya();
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && (int)row.Cells[0].Value == k)
                    {
                        dataGridView1.Rows.Remove(row);
                        YazDosya();
                        market.Sil(k);
                        textBox4.Clear();
                        textBox5.Clear();
                        textBox6.Clear();
                        return;
                    }
                }
                MessageBox.Show("Ürün bulunamadı.");
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
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[0].Value != null && (int)row.Cells[0].Value == k)
                    {
                        row.Cells[2].Value = yf;
                        YazDosya();
                        market.Guncelle(k, yf);
                        textBox7.Clear();
                        textBox8.Clear();
                        textBox9.Clear();
                        return;
                    }
                }
                MessageBox.Show("Ürün bulunamadı.");
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
        private void YazDosya()
        {
            string dosyaYolu = "UrunVeri.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(dosyaYolu))
                {
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        if (row.IsNewRow) continue;

                        string satir = $"{row.Cells[0].Value},{row.Cells[1].Value},{row.Cells[2].Value}";
                        sw.WriteLine(satir);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya yazılırken bir hata oluştu: " + ex.Message);
            }
        }

        private void Listele()
        {
            string dosyaYolu = "UrunVeri.txt";

            try
            {
                using (StreamReader sr = new StreamReader(dosyaYolu))
                {
                    dataGridView1.Rows.Clear();
                    string satir;
                    while ((satir = sr.ReadLine()) != null)
                    {
                        string[] parcalar = satir.Split(';');

                        if (parcalar.Length == 3)
                        {
                            int kodu = int.Parse(parcalar[0]);
                            string adi = parcalar[1];
                            double fiyat = double.Parse(parcalar[2]);

                            dataGridView1.Rows.Add(kodu, adi, fiyat);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Dosya okunurken bir hata oluştu: " + ex.Message);
            }
        }
    }
}
