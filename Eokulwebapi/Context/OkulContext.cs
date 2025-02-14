using Eokulwebapi.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Eokulwebapi.Context
{
    public class OkulContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-J1MPADH\\SABRI;database=okullll;integrated security=true");
        }
        public DbSet<ÖnKayıtÖğrenci> ÖnKayıtÖğrencis { get; set; }
        public DbSet<Öğrenci> Öğrencis { get; set; }
        public DbSet<Sınıf> Sınıfs { get; set; }
        public DbSet<Ders> Ders { get; set; }
        public DbSet<DersProgramı> dersProgramıs { get; set; }
        public DbSet<Öğretmen> Öğretmens { get; set; }
        public DbSet<Not> Nots { get; set; }
        public DbSet<Devamsızlık> Devamsızlıks { get; set; }
        public DbSet<İlişkisiKesilen> İlişkisiKesilens { get; set; }
    }
   
}
