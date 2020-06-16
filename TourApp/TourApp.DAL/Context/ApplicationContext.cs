using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TourApp.DAL.Models;

namespace TourApp.DAL.Context
{
    public class ApplicationContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Route> Routes { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Data Source=.\SQLEXPRESS;Initial Catalog=TourAppDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }

            modelBuilder.Entity<Country>().HasData(
                new Country[]
                {
                    new Country { Id = 1, Name = "Англія", VisaPrice = 3000 },
                    new Country { Id = 2, Name = "Норвегія", VisaPrice = 3500 },
                    new Country { Id = 3, Name = "США", VisaPrice = 50000 },
                    new Country { Id = 4, Name = "Німеччина", VisaPrice = 0 },
                    new Country { Id = 5, Name = "Польща", VisaPrice = 0 },
                    new Country { Id = 6, Name = "Україна", VisaPrice = 0 },
                });

            modelBuilder.Entity<City>().HasData(
                new City[]
                {
                    new City { Id = 1, Name = "Лондон", CountryId = 1 },
                    new City { Id = 2, Name = "Бірмінгем", CountryId = 1 },
                    new City { Id = 3, Name = "Лідс", CountryId = 1 },
                    new City { Id = 4, Name = "Осло", CountryId = 2 },
                    new City { Id = 5, Name = "Берген", CountryId = 2 },
                    new City { Id = 6, Name = "Нью Йорк", CountryId = 3 },
                    new City { Id = 7, Name = "Техас", CountryId = 3 },
                    new City { Id = 8, Name = "Лос-Анджелес", CountryId = 3 },
                    new City { Id = 9, Name = "Берлін", CountryId = 4 },
                    new City { Id = 10, Name = "Франкфурт", CountryId = 4 },
                    new City { Id = 11, Name = "Мюнхен", CountryId = 4 },
                    new City { Id = 12, Name = "Львів", CountryId = 6 },
                    new City { Id = 13, Name = "Київ", CountryId = 6 },
                    new City { Id = 14, Name = "Одеса", CountryId = 6 },
                    new City { Id = 15, Name = "Гданськ", CountryId = 5 },
                    new City { Id = 16, Name = "Краків", CountryId = 5 },
                    new City { Id = 17, Name = "Варшава", CountryId = 5 },
                });

            modelBuilder.Entity<Route>()
                .HasOne<City>(x => x.FromCity)
                .WithMany(x => x.FromCities)
                .HasForeignKey(x => x.FromCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Route>()
                .HasOne<City>(x => x.ToCity)
                .WithMany(x => x.ToCities)
                .HasForeignKey(x => x.ToCityId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Route>().HasData(
                new Route[]
                {
                    new Route { Id = 1, FromCityId = 12, ToCityId = 1, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(3), IsFlight = true, Price = 7500 },
                    new Route { Id = 2, FromCityId = 12, ToCityId = 2, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(3), IsFlight = true, Price = 5000 },
                    new Route { Id = 3, FromCityId = 12, ToCityId = 3, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(3), IsFlight = true, Price = 5000 },
                    new Route { Id = 4, FromCityId = 12, ToCityId = 4, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(3), IsFlight = true, Price = 10000 },
                    new Route { Id = 5, FromCityId = 12, ToCityId = 5, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(3), IsFlight = true, Price = 9800 },
                    new Route { Id = 6, FromCityId = 12, ToCityId = 6, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(15), IsFlight = true, Price = 40000 },
                    new Route { Id = 7, FromCityId = 12, ToCityId = 7, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(15), IsFlight = true, Price = 50000 },
                    new Route { Id = 8, FromCityId = 12, ToCityId = 8, StartDate = DateTime.Now, EndDate = DateTime.Now.AddHours(15), IsFlight = true, Price = 65000 }
                });

            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1, FullName = "Admin", Email = "admin", Password = "admin"}
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}
