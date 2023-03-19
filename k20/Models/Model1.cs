using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace k20.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model_DienThoai_k20")
        {
        }

        public virtual DbSet<ADMIN> ADMINs { get; set; }
        public virtual DbSet<CHITIETDONHANG> CHITIETDONHANGs { get; set; }
        public virtual DbSet<dienthoai> dienthoais { get; set; }
        public virtual DbSet<DONDATHANG> DONDATHANGs { get; set; }
        public virtual DbSet<KHACHHANG> KHACHHANGs { get; set; }
        public virtual DbSet<nhasanxuat> nhasanxuats { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<dienthoai>()
                .Property(e => e.GIABAN)
                .HasPrecision(18, 0);

            modelBuilder.Entity<dienthoai>()
                .Property(e => e.ANHBIA)
                .IsUnicode(false);

            modelBuilder.Entity<dienthoai>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.dienthoai)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<DONDATHANG>()
                .HasMany(e => e.CHITIETDONHANGs)
                .WithRequired(e => e.DONDATHANG)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.TAIKHOAN)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.MATKHAU)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.EMAIL)
                .IsUnicode(false);

            modelBuilder.Entity<KHACHHANG>()
                .Property(e => e.DIENTHOAI)
                .IsUnicode(false);
        }
    }
}
