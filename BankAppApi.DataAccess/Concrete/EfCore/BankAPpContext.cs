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
            optionsBuilder.UseSqlServer("Server=tcp:mhrsdb.database.windows.net,1433;Initial Catalog=BankApp;Persist Security Info=False;User ID=tahiruzunkaya;Password=12481632aA;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
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
