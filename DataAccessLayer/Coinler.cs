using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class Coinler
    {
        public int ID { get; set; }
        public string Isim { get; set; }
        public string CoinNick { get; set; }
        public int Max_Arz { get; set; }
        public string Resim { get; set; }
        public decimal Fiyat { get; set; }
        public bool Aktif { get; set; }
    }
}
