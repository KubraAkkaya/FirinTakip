namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("UrunEtiket")]
    public partial class UrunEtiket
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public UrunEtiket()
        {
            Uruns = new HashSet<Urun>();
        }

        public int ID { get; set; }

        [StringLength(4)]
        public string EtiketAdi { get; set; }

        public bool? Aktiflik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Urun> Uruns { get; set; }
    }
}
