using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace k20.Models
{
    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=Model2")
        {
        }

        public virtual DbSet<DienThoai> DienThoais { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DienThoai>()
                .Property(e => e.Gia)
                .HasPrecision(19, 4);

            modelBuilder.Entity<DienThoai>()
                .Property(e => e.Hinh)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .HasMany(e => e.DienThoais)
                .WithOptional(e => e.KhachHang)
                .HasForeignKey(e => e.MaKH);
        }
    }
}
