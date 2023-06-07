using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DatLich.Models
{
    public partial class DataBase : DbContext
    {
        public DataBase()
            : base("name=DataBase")
        {
        }

        public virtual DbSet<accountAD> accountADs { get; set; }
        public virtual DbSet<booking> bookings { get; set; }
        public virtual DbSet<categoryService> categoryServices { get; set; }
        public virtual DbSet<detailBooking> detailBookings { get; set; }
        public virtual DbSet<news> news { get; set; }
        public virtual DbSet<position> positions { get; set; }
        public virtual DbSet<sale> sales { get; set; }
        public virtual DbSet<service> services { get; set; }
        public virtual DbSet<staff> staffs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<accountAD>()
                .HasMany(e => e.news)
                .WithOptional(e => e.accountAD)
                .HasForeignKey(e => e.createById);

            modelBuilder.Entity<booking>()
                .HasMany(e => e.detailBookings)
                .WithOptional(e => e.booking)
                .HasForeignKey(e => e.idBooking);

            modelBuilder.Entity<categoryService>()
                .HasMany(e => e.services)
                .WithOptional(e => e.categoryService)
                .HasForeignKey(e => e.idCategory);

            modelBuilder.Entity<position>()
                .HasMany(e => e.staffs)
                .WithOptional(e => e.position)
                .HasForeignKey(e => e.idPosition);

            modelBuilder.Entity<sale>()
                .HasMany(e => e.services)
                .WithOptional(e => e.sale)
                .HasForeignKey(e => e.idSale);

            modelBuilder.Entity<service>()
                .HasMany(e => e.detailBookings)
                .WithOptional(e => e.service)
                .HasForeignKey(e => e.idService);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.accountADs)
                .WithOptional(e => e.staff)
                .HasForeignKey(e => e.idStaff);

            modelBuilder.Entity<staff>()
                .HasMany(e => e.bookings)
                .WithOptional(e => e.staff)
                .HasForeignKey(e => e.idStaff);
        }
    }
}
