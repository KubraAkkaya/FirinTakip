namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Adres
    {
        public int ID { get; set; }

        public int? MusteriID { get; set; }

        [StringLength(10)]
        public string Mahalle { get; set; }

        [StringLength(10)]
        public string Sokak { get; set; }

        [StringLength(10)]
        public string Cadde { get; set; }

        public bool? Aktirflik { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
