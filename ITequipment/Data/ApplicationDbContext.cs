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

        public DbSet<Location> Location { get; set; }
        public DbSet<Room> Room { get; set; }
        public DbSet<Owner> Owner { get; set; }
        public DbSet<Brand> Brand { get; set; }
        public DbSet<Software> Software { get; set; }
        public DbSet<Hardware> Hardware { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
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

            base.OnModelCreating(modelBuilder);
        }
    }
}
