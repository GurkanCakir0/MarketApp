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
                System.Windows.Forms.MessageBox.Show("Ürün Listeye Başarıyla Kayıt Edildi");
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
                System.Windows.Forms.MessageBox.Show("Ürün Silindi");
            }
        }
        public void Guncelle(int k, double f)
        {
            if ()
            {

            }
        }
        public string Listele()
        {
            if (Head== null)
            {
                return "Ürün Listesi Boş";
            }

            Urun temp = Head;
            string result = "";
            while (temp != null)
            {
                result += temp.Sonraki + "";
                temp = temp.Sonraki;
            }
            return result.Trim();
        }
    }
}
