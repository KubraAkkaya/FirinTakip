using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FirinTakip.Dto
{
    public class FaturaBilgileriDto
    {
        public DateTime? FaturaTarihi { get; set; }
        public string MusteriAdi { get; set; }
        public string UrunAdi { get; set; }
        public bool? OdemeDurumu { get; set; }
        public int ID { get; set; }
    }
}