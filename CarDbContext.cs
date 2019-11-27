using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;


namespace CarDatabase
{
    public class CarDbContext : DbContext
    {
        public DbSet<CarMake> CarMakes { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<Ownership> Ownerships { get; set; }
        public DbSet<Person> People { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // Note that this time we play with SQLite. You can find a browser
            // at https://sqlitebrowser.org/dl/.
            var dbFileName = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "mydb.db");
            optionsBuilder.UseSqlite($"Data Source={dbFileName};");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<CarMake>()
                .HasMany(cm => cm.CarModels)
                .WithOne(c => c.CarMake);

            modelBuilder.Entity<Person>()
                .HasMany(p => p.Ownerships)
                .WithOne(o => o.Person);

            modelBuilder.Entity<CarModel>()
               .HasMany(c => c.Ownerships)
               .WithOne(o => o.CarModel);

            modelBuilder.Entity<Ownership>()
                .HasOne(o => o.CarModel)
                .WithMany(c => c.Ownerships);

            // Note how we create unique indexes
            modelBuilder.Entity<Ownership>()
                .HasIndex(o => o.VehicleIdentificationNumber)
                .IsUnique();
                
        }

    }
}
