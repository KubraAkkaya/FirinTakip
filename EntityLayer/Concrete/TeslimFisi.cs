namespace EntityLayer.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("TeslimFisi")]
    public partial class TeslimFisi
    {
        public int ID { get; set; }

        public int? SiparisID { get; set; }

        public int? FaturaID { get; set; }

        public bool? Aktiflik { get; set; }

        public virtual Fatura Fatura { get; set; }

        public virtual Sipari Sipari { get; set; }
    }
}
