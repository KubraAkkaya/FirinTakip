namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Siparisler")]
    public partial class Siparisler
    {
        public int ID { get; set; }

        public int? Adet { get; set; }

        [Column(TypeName = "date")]
        public DateTime? Tarih { get; set; }

        [StringLength(10)]
        public string OdemeSekli { get; set; }

        public int UrunID { get; set; }

        public int MusteriID { get; set; }

        public int? ServisAraciID { get; set; }

        public bool? Aktiflik { get; set; }

        public int? FaturaID { get; set; }

        public virtual Fatura Fatura { get; set; }

        public virtual Musteri Musteri { get; set; }

        public virtual ServisAraci ServisAraci { get; set; }

        public virtual Urun Urun { get; set; }
    }
}
