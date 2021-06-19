using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DemoCRUD.Models.EF
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("name=ApplicationDbContext")
        {
        }

        public virtual DbSet<nguoidung> nguoidungs { get; set; }
        public virtual DbSet<sanpham> sanphams { get; set; }
        public virtual DbSet<theloai> theloais { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<nguoidung>()
                .Property(e => e.dienthoai)
                .IsFixedLength();

            modelBuilder.Entity<theloai>()
                .HasMany(e => e.sanphams)
                .WithRequired(e => e.theloai)
                .WillCascadeOnDelete(false);
        }
    }
}
