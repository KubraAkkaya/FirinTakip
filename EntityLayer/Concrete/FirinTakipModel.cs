using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityLayer.Concrete
{
    public partial class FirinTakipModel : DbContext
    {
        public FirinTakipModel()
            : base("name=FirinTakipModel")
        {
        }

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Fatura> Faturas { get; set; }
        public virtual DbSet<Musteri> Musteris { get; set; }
        public virtual DbSet<ServisAraci> ServisAracis { get; set; }
        public virtual DbSet<Siparisler> Siparislers { get; set; }
        public virtual DbSet<Talep> Taleps { get; set; }
        public virtual DbSet<TeslimFisi> TeslimFisis { get; set; }
        public virtual DbSet<Urun> Uruns { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>()
                .Property(e => e.AdminRole)
                .IsFixedLength();

            modelBuilder.Entity<Musteri>()
                .Property(e => e.TelefonNo)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Siparislers)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServisAraci>()
                .Property(e => e.Ad)
                .IsFixedLength();

            modelBuilder.Entity<ServisAraci>()
                .Property(e => e.Bolge)
                .IsFixedLength();

            modelBuilder.Entity<Siparisler>()
                .Property(e => e.OdemeSekli)
                .IsFixedLength();

            modelBuilder.Entity<Siparisler>()
                .HasMany(e => e.TeslimFisis)
                .WithOptional(e => e.Siparisler)
                .HasForeignKey(e => e.SiparisID);

            modelBuilder.Entity<Talep>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Urun>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Siparislers)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);
        }
    }
}
