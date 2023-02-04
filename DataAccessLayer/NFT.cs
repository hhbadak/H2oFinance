using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NFT
    {
        public int ID { get; set; }
        public string isim { get; set; }
        public int uyeID { get; set; }
        public decimal fiyat { get; set; }
        public string resim { get; set; }
        public byte Aktif { get; set; }
    }
}
