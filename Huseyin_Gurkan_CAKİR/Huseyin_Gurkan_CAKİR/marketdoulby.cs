using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huseyin_Gurkan_CAKİR
{
    class marketdoulby
    {
        public Urun Head;
        public Urun Tail;

        public marketdoulby()
        {
            Head = null;
            Tail = null;
        }

        public void Ekle(int k, string a, double f)
        {
            Urun temp = Head;
            while (temp != null)
            {
                if (temp.kodu == k)
                {
                    System.Windows.Forms.MessageBox.Show("Bu ürün kodu zaten mevcut. Lütfen farklı bir kod girin.");
                    return; 
                }
                temp = temp.Sonraki; 
            }
            Urun urun = new Urun(k,a,f);
            if (Head == null)
            {
                Head = Tail = urun;
            }
            else
            {
                urun.Sonraki = Head;
                Head.Onceki = urun;
                Head = urun;
            }
        }
        public void Sil(int k)
        {

            if (Head == null)
            {
                System.Windows.Forms.MessageBox.Show("Ürün Listesi Boş");
                return;
            }
            Urun temp = Head;
            if (temp.kodu == k)
            {
                Head = Head.Sonraki;
                if (Head != null)
                {
                    Head.Onceki = null;
                }
                else
                {
                    Tail = null;
                }
                return;
            }
            while (temp != null && temp.kodu != k)
            {
                temp = temp.Sonraki;
            }
            if (temp != null)
            {
                if (temp.Onceki != null)
                {
                    temp.Onceki.Sonraki = temp.Sonraki;
                }
                if (temp.Sonraki != null)
                {
                    temp.Sonraki.Onceki = temp.Onceki;
                }

                else
                {
                    Tail = temp.Onceki;
                }
                System.Windows.Forms.MessageBox.Show("Ürün Silindi");
            }
            else
            {
                System.Windows.Forms.MessageBox.Show("Ürün Bulunamadı");
            }
        }
        public void Guncelle(int k, double yf)
        {
            Urun temp = Head;
            while (temp != null)
            {
                if (temp.kodu == k)
                {
                    temp.fiyat = yf;
                    return;
                }
                temp = temp.Sonraki;
            }
            System.Windows.Forms.MessageBox.Show("Ürün Bulunamadı");
        }
        public Urun UrunBul(int k)
        {
            Urun temp = Head;
            while (temp != null)
            {
                if (temp.kodu == k)
                {
                    return temp;
                }
                temp = temp.Sonraki;
            }
            return null;
        }
        public List<Urun> Listele()
        {
            List<Urun> urunler = new List<Urun>();
            Urun temp = Head;

            while (temp != null)
            {
                urunler.Add(temp);
                temp = temp.Sonraki;
            }

            if (urunler.Count == 0)
            {
                System.Windows.Forms.MessageBox.Show("Ürün Listesi Boş");
            }
            return urunler;
        }
    }
}
