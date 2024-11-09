using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huseyin_Gurkan_CAKİR
{
    class Urun
    {
        public int kodu;
        public string adi;
        public double fiyat;
        public Urun Sonraki;
        public Urun Onceki;

        public Urun(int k,string a, double f)
        {
            this.kodu = k;
            this.adi = a;
            this.fiyat = f;
            this.Sonraki = null;
            this.Onceki = null;
        }
    }
}
