using System;
using System.Collections.Generic;
using System.Text;
using ITequipment.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ITequipment.Data
{
    
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Location> Locations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Software> Softwares { get; set; }
        public DbSet<Hardware> Hardwares { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            Database.EnsureCreated();            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HW_SW>().HasKey(k => new { k.HardwareId, k.SoftwareId });

            modelBuilder.Entity<HW_SW>()
                .HasOne(x => x.Hardware)
                .WithMany(x => x.HW_SWs)
                .HasForeignKey(x => x.HardwareId);

            modelBuilder.Entity<HW_SW>()
               .HasOne(x => x.Software)
               .WithMany(x => x.HW_SWs)
               .HasForeignKey(x => x.SoftwareId);

            modelBuilder.Entity<Location>().ToTable("Location");
            modelBuilder.Entity<Room>().ToTable("Room");
            modelBuilder.Entity<Owner>().ToTable("Owner");
            modelBuilder.Entity<Brand>().ToTable("Brand");
            modelBuilder.Entity<Software>().ToTable("Software");
            modelBuilder.Entity<Hardware>().ToTable("Hardware");

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<ITequipment.Models.HW_SW> HW_SW { get; set; }
    }
}
