namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ServisAraci")]
    public partial class ServisAraci
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ServisAraci()
        {
            Siparis = new HashSet<Sipari>();
        }

        public int ID { get; set; }

        [StringLength(10)]
        public string Ad { get; set; }

        [StringLength(10)]
        public string Bolge { get; set; }

        public bool? Aktiflik { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Sipari> Siparis { get; set; }
    }
}
