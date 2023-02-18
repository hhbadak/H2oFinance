using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Uyeler
    {
        public int ID { get; set; }
        public string isim { get; set; }
        public string soyisim { get; set; }
        public string mail { get; set; }
        public string sifre { get; set; }
        public string telefon { get; set; }
        public string tcNo { get; set; }
        public string tokenAdres { get; set; }
        public decimal bakiye { get; set; }
    }
}
