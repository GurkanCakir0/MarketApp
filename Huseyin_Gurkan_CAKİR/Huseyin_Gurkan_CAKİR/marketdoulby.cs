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
        public void Sil()
        {
            if (Head == null)
            {
                System.Windows.Forms.MessageBox.Show("Ürün Listesi Boş");
            }
            else if (Head.Sonraki == null)
            {
                Head = Tail = null;
                System.Windows.Forms.MessageBox.Show("Son Üründe Silindi");
            }
            else
            {
                Head = Head.Sonraki;
                Head.Onceki = null;
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
            if (Head== null)
            {
                System.Windows.Forms.MessageBox.Show("Ürün Listesi Boş"); 
            }
            List<Urun> urunler = new List<Urun>();
            Urun temp = Head;

            while (temp != null)
            {
                urunler.Add(temp);
                temp = temp.Sonraki;
            }
            return urunler;
        }
    }
}
