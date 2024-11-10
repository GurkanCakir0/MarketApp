using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
                market.Sil();
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
    }
}
