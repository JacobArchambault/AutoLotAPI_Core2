using AutoLotDAL_Core2.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace AutoLotDAL_Core2.EF
{
    public class AutoLotContext : DbContext
    {
        // Properties
        public DbSet<CreditRisk> CreditRisks { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Inventory> Cars { get; set; }
        public DbSet<Order> Orders { get; set; }
        // Constructors
        public AutoLotContext(DbContextOptions options) : base(options)
        {
        }
        // Methods
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString = @"server=(localdb)\mssqllocaldb;database=AutoLotCore2;integrated security=true;MultipleActiveResultSets=true;App=EntityFramework;";
                optionsBuilder.UseSqlServer(connectionString, options => options.EnableRetryOnFailure());
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // create the multi column index
            modelBuilder.Entity<CreditRisk>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName }).IsUnique();
            });
            // set the cascade options on the relationship
            modelBuilder.Entity<Order>()
                .HasOne(e => e.Car)
                .WithMany(e => e.Orders)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
        public string GetTableName(Type type)
        {
            return Model.FindEntityType(type).GetTableName();
        }
    }
}
