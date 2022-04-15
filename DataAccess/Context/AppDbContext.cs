using DataAccess.Entity;
using CoreTier;
using DataAccess.Map;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context
{
   public class AppDbContext:DbContext
    {
        public AppDbContext()
        {
            Database.Connection.ConnectionString = "server=LAPTOP-Q4TUCL3R\\SQLEXPRESS;database=BilgeKolej1;Trusted_Connection=True";
        }
        public DbSet<Sınıf> Sınıflar { get; set; }
        public DbSet<Önkayıt> Önkayıtlar { get; set; }
        public DbSet<ÖğretmenSınıf> öğretmenSınıflar { get; set; }
        public DbSet<Öğretmen> Öğretmenler { get; set; }
        public DbSet<Öğrenci> Öğrenciler { get; set; }
        public DbSet<Notlar> Notlars { get; set; }
        public DbSet<Devamsızlık> Devamsızlıklar { get; set; }
        public DbSet<Dersler> Derslers { get; set; }
        public DbSet<Rol> Roller { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new SınıfMap());
            modelBuilder.Configurations.Add(new ÖğretmenMap());
            modelBuilder.Configurations.Add(new ÖğretmenSınıfMap());
            modelBuilder.Configurations.Add(new DerslerMap());
            modelBuilder.Configurations.Add(new DevamsızlıkMap());
            modelBuilder.Configurations.Add(new NotlarMap());
            modelBuilder.Configurations.Add(new ÖğrenciMap());
            modelBuilder.Configurations.Add(new ÖnkayıtMap());
            base.OnModelCreating(modelBuilder);

        }
    }
}
