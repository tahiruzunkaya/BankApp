using BankAppApi.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BankAppApi.DataAccess.Concrete.EfCore
{
    public class BankAppContext:DbContext
    {
        public BankAppContext(DbContextOptions<BankAppContext> options) : base(options)
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-SE862OL;Database=BankApp;Trusted_Connection=True;MultipleActiveResultSets=true");
        }

        public DbSet<Musteri> tblMusteri { get; set; }
        public DbSet<Hesap> tblHesap { get; set; }
        public DbSet<Havale> tblHavale { get; set; }
        public DbSet<Virman> tblVirman { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
