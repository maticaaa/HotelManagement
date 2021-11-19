using ApplicationCore.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data
{
    public class HotelManagementDbContext: DbContext
    {
        public HotelManagementDbContext(DbContextOptions<HotelManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>(ConfigureCustomer);
            modelBuilder.Entity<Room>(ConfigureRoom);
            modelBuilder.Entity<RoomType>(ConfigureRoomType);
            modelBuilder.Entity<Service>(ConfigureService);
        }

        private void ConfigureService(EntityTypeBuilder<Service> builder)
        {
            builder.ToTable("Services");
            builder.Property(s => s.SDesc).HasMaxLength(50);
            builder.Property(s => s.Amount).HasColumnType("decimal(5, 2)");
            builder.HasOne(s => s.Room).WithMany(r => r.Services).HasForeignKey(s => s.RoomNo);
            //
            //builder.HasOne(s => s.TestRoom).WithMany(r => r.TestServices).HasForeignKey(s => s.TestRoomNo);
        }

        private void ConfigureRoomType(EntityTypeBuilder<RoomType> builder)
        {
            builder.ToTable("Roomtypes");
            builder.Property(rt => rt.RTDesc).HasMaxLength(20);
            builder.Property(rt => rt.Rent).HasColumnType("decimal(5, 2)");
        }

        private void ConfigureRoom(EntityTypeBuilder<Room> builder)
        {
            builder.ToTable("Rooms");
            //builder.Property(r => r.Status).HasDefaultValue(true);
            builder.Ignore(r => r.Status);
            builder.HasOne(r => r.RoomType).WithMany(rt => rt.Rooms).HasForeignKey(r => r.RTCode);
        }

        private void ConfigureCustomer(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            builder.Property(c => c.CName).HasMaxLength(20);
            builder.Property(c => c.Address).HasMaxLength(100);
            builder.Property(c => c.Phone).HasMaxLength(20);
            builder.Property(c => c.Email).HasMaxLength(40);
            //builder.Property(c => c.Advance).HasColumnType("decimal(5, 2)");
            builder.HasOne(c => c.Room).WithMany(r => r.Customers).HasForeignKey(c => c.RoomNo);

            // Advance is from the sum of all services + room rates
            builder.Ignore(c => c.Advance);
        }
    }
}
