namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Talep")]
    public partial class Talep
    {
        public int ID { get; set; }

        public int? FaturaAdet { get; set; }

        [StringLength(50)]
        public string Aciklama { get; set; }

        public int? MusteriID { get; set; }

        public bool? Aktiflik { get; set; }

        public virtual Musteri Musteri { get; set; }
    }
}
