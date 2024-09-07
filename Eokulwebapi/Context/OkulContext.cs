using Eokulwebapi.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Eokulwebapi.Context
{
    public class OkulContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-J1MPADH\\SABRI;database=okullll;integrated security=true");
        }
        public DbSet<ÖnKayıtÖğrenci> ÖnKayıtÖğrencis { get; set; }
        public DbSet<Öğrenci> Öğrencis { get; set; }
        public DbSet<Sınıf> Sınıfs { get; set; }
    }
   
}
