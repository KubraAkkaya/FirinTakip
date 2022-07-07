using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace EntityLayer.Concrete
{
    public class FirinTakipModel : DbContext
    {
        public FirinTakipModel()
            : base("name=FirinTakipModel")
        {
        }

        public  DbSet<Fatura> Faturas { get; set; }
        public  DbSet<Musteri> Musteris { get; set; }
        public  DbSet<ServisAraci> ServisAracis { get; set; }
        public  DbSet<Sipari> Siparis { get; set; }
        public  DbSet<Talep> Taleps { get; set; }
        public  DbSet<TeslimFisi> TeslimFisis { get; set; }
        public  DbSet<Urun> Uruns { get; set; }
        public  DbSet<UrunEtiket> UrunEtikets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Musteri>()
                .Property(e => e.TelefonNo)
                .IsUnicode(false);

            modelBuilder.Entity<Musteri>()
                .Property(e => e.Adres)
                .IsFixedLength();

            modelBuilder.Entity<Musteri>()
                .HasMany(e => e.Siparis)
                .WithRequired(e => e.Musteri)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ServisAraci>()
                .Property(e => e.Ad)
                .IsFixedLength();

            modelBuilder.Entity<ServisAraci>()
                .Property(e => e.Adres)
                .IsFixedLength();

            modelBuilder.Entity<Sipari>()
                .Property(e => e.OdemeSekli)
                .IsFixedLength();

            modelBuilder.Entity<Sipari>()
                .HasMany(e => e.TeslimFisis)
                .WithOptional(e => e.Sipari)
                .HasForeignKey(e => e.SiparisID);

            modelBuilder.Entity<Talep>()
                .Property(e => e.Aciklama)
                .IsUnicode(false);

            modelBuilder.Entity<Urun>()
                .Property(e => e.Fiyat)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Urun>()
                .HasMany(e => e.Siparis)
                .WithRequired(e => e.Urun)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UrunEtiket>()
                .Property(e => e.EtiketAdi)
                .IsFixedLength();

            modelBuilder.Entity<UrunEtiket>()
                .HasMany(e => e.Uruns)
                .WithRequired(e => e.UrunEtiket)
                .WillCascadeOnDelete(false);
        }
    }
}
