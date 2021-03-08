using Microsoft.EntityFrameworkCore;
using Supermarket.Domain.Goods;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Supermarket.Domain
{
    public  class dbAppication:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=SuperMarket;Trusted_Connection=True;");
            base.OnConfiguring(optionsBuilder);
        }

        /*protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GoodCategory>().HasKey(_ => _.Id);

            modelBuilder.Entity<GoodCategory>().Property(_ => _.Id)
                .ValueGeneratedNever();
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
        public DbSet<GoodCategory> GoodCategories { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<GoodEntry> GoodEntries { get; set; }
        public DbSet<SalesFactor> SalesFactors { get; set; }
    }
}
