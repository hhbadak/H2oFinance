using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Talepler
    {
        public int ID { get; set; }
        public int Uye_ID { get; set; }
        public string Uye_Adi { get; set; }
        public int Yonetici_ID { get; set; }
        public string Yonetici_Adi { get; set; }
        public decimal Miktar { get; set; }
        public DateTime Talep_Tarihi { get; set; }
        public DateTime Onay_Tarihi { get; set; }
        public byte Durum { get; set; }
    }
}
