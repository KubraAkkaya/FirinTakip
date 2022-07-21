namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Urun")]
    public partial class Urun
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Urun()
        {
            Siparis = new HashSet<Siparis>();
        }

        public int ID { get; set; }

        public string UrunAdi { get; set; }

        [Column("Almanca Adı")]
        public string Almanca_Adı { get; set; }

        [Column(TypeName = "money")]
        public decimal? Fiyat { get; set; }

        public bool? TatliMi { get; set; }

        public bool? Aktiflik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Siparis> Siparis { get; set; }
    }
}
