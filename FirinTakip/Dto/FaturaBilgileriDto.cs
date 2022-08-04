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
        public int MusteriId { get; set; }
        public string UrunAdi { get; set; }
        public int UrunId { get; set; }
        public bool? OdemeDurumu { get; set; }
        public int ID { get; set; }
        public bool? Aktiflik { get; set; }
        public int? SiparisAdeti{ get; set; }
        public decimal? UrunFiyat { get; set; }
        public decimal? ToplamTutar { get; set; }


    }
}