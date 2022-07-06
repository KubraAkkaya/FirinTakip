namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Sipari
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Sipari()
        {
            TeslimFisis = new HashSet<TeslimFisi>();
        }

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

        public virtual Musteri Musteri { get; set; }

        public virtual ServisAraci ServisAraci { get; set; }

        public virtual Urun Urun { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TeslimFisi> TeslimFisis { get; set; }
    }
}
