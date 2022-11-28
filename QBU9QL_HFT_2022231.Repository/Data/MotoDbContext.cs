using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using QBU9QL_HFT_2022231.Models;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QBU9QL_HFT_2022231.Repository.Data
{
    public class MotoDbContext : DbContext
    {

        public DbSet<Motorcycle> Motorcycless { get; set; }
        public DbSet<Riders> Riders { get; set; }
        public DbSet<Brands> Brands { get; set; }

        public MotoDbContext()
        {
            this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseInMemoryDatabase("MotoGP").UseLazyLoadingProxies();

            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Riders>(rider => rider
                    .HasOne(rider => rider.Motorcycle)
                    .WithMany(moto => moto.Riders)
                    .HasForeignKey(rider => rider.MotoId)
                    .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Motorcycle>(moto => moto
                .HasOne(moto => moto.Brands)
                .WithMany(brand => brand.Motorcycles)
                .HasForeignKey(moto => moto.BrandId)
                .OnDelete(DeleteBehavior.Cascade));

            modelBuilder.Entity<Riders>().HasData(new Riders[]
            {
                new Riders(1, "Andrea Dovizioso", 1986, 'M', 1),
                new Riders(2, "Johann Zarco", 1990, 'M', 4),
                new Riders(3,"Stefan Bradl", 1991, 'M', 3),
                new Riders(4, "Danilo Petrucci", 1990, 'M', 4),
                new Riders(5, "Luca Marini", 1997, 'M', 1),
                new Riders(6, "Maverik Vinales", 1995, 'M', 6),
                new Riders(7, "Fabio Quartararo", 1999, 'M', 7),
                new Riders(8, "Franco Morbidelli", 1994, 'M', 3),
                new Riders(9, "Enea Bastianini",1997, 'M', 8),
                new Riders(10, "Raul Fernandez", 2000, 'M', 7),
                new Riders(11, "Takaaki Nakagami", 1992, 'M', 9),
                new Riders(12, "Max Verstappen", 1999, 'M', 10),
                new Riders(13, "Lewis Hamilton", 1992, 'M', 11),
                new Riders(14, "Niki Lauda", 1965, 'M', 12)
            });

            modelBuilder.Entity<Motorcycle>().HasData(new Motorcycle[]
            {
                new Motorcycle(1, "ZX10R", 1000, 210, 1),
                new Motorcycle(2, "GS1250", 1250, 120, 4),
                new Motorcycle(3, "R1", 1000, 195, 2),
                new Motorcycle(4, "Tenere", 750, 110, 2),
                new Motorcycle(5, "GSXR", 700, 130, 5),
                new Motorcycle(6, "Africa Twin", 1100, 105, 3),
                new Motorcycle(7, "CB500", 500, 58, 3),
                new Motorcycle(8, "Intruder", 1800, 90, 5),
                new Motorcycle(9, "G301S", 301, 25, 4),
                new Motorcycle(10, "S50", 50, 6, 9),
                new Motorcycle(11, "ETZ", 850, 20, 10),
                new Motorcycle(12, "Pegaso", 900, 36, 11),
            });

            modelBuilder.Entity<Brands>().HasData(new Brands[]
            {
                new Brands(1,"Kawasaki", 1935, 1950000),
                new Brands(2, "Yamaha", 1911, 22000000),
                new Brands(3, "Honda", 1962, 350000000),
                new Brands(4, "BMW", 1955, 45000000),
                new Brands(5, "Suzuki", 1924, 3600000),
                new Brands(6, "KTM", 1982, 78000),
                new Brands(7, "Ducati", 1895, 78000000),
                new Brands(8, "Harley Davidson", 1856, 45000000),
                new Brands(9, "Simson", 1856, 30000000),
                new Brands(10, "MZ", 1785, 90000),
                new Brands(11, "Aprilia", 1955, 3000)
            });

            
        }
    }
}
