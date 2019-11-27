using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CarDatabase
{
    public static partial class Program
    {
        public static async Task CleanDatabaseAsync(CarDbContext context)
        {
            // Note that we are using a DB transaction here. Either all records are
            // inserted or none of them (A in ACID).
            using var transaction = context.Database.BeginTransaction();

            // Note that we are using a "Raw" SQL statement here. With that, we can use
            // all features of the underlying database. We are not limited to what EFCore
            // can do.
            await context.Database.ExecuteSqlRawAsync("DELETE FROM CarMakes");
            await context.Database.ExecuteSqlRawAsync("DELETE FROM CarModels");
            await context.Database.ExecuteSqlRawAsync("DELETE FROM People");
            await context.Database.ExecuteSqlRawAsync("DELETE FROM Ownerships");


            await transaction.CommitAsync();
        }

        public static async Task FillCarMakesAsync(CarDbContext context)
        {
            var carMakeData = await File.ReadAllTextAsync("Data/CarMakeData.json");
            var carModel = JsonSerializer.Deserialize<IEnumerable<CarMake>>(carMakeData);

            using var transaction = context.Database.BeginTransaction();

            try
            {
                foreach (var c in carModel)
                {
                    context.CarMakes.Add(c);
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Something bad happened: {ex.Message}");

                throw;
            }
        }
        public static async Task FillCarModelsAsync(CarDbContext context)
        {
            var carModelData = await File.ReadAllTextAsync("Data/CarModelData.json");
            var carModel = JsonSerializer.Deserialize<IEnumerable<CarModel>>(carModelData);

            using var transaction = context.Database.BeginTransaction();

            try
            {
                foreach (var c in carModel)
                {
                    Random rand = new Random();
                    int id = rand.Next(1, 20);
                    c.CarMake = context.CarMakes.Find(id);
                    context.CarModels.Add(c);
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Something bad happened: {ex.Message}");

                throw;
            }
        }
        private static async Task FillPeopleAsync(CarDbContext context)
        {
            var peopleData = await File.ReadAllTextAsync("Data/PersonData.json");
            var people = JsonSerializer.Deserialize<IEnumerable<Person>>(peopleData);

            using var transaction = context.Database.BeginTransaction();

            try
            {
                foreach (var p in people)
                {
                    context.People.Add(p);
                }

                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Something bad happened: {ex.Message}");

                throw;
            }
        }
        private static async Task FillOwnershipsAsync(CarDbContext context)
        {
            var people = context.People;
            Random rand = new Random();

            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var p in people)
                {
                    Ownership o = new Ownership();
                    int id = rand.Next(1, 101);
                    o.CarModel = context.CarModels.Find(id);
                    o.Person = p;
                    o.VehicleIdentificationNumber = Guid.NewGuid().ToString();
                    context.Ownerships.Add(o);
                }
                await context.SaveChangesAsync();

                await transaction.CommitAsync();
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine($"Something bad happened: {ex.Message}");

                throw;
            }

        }



    }

    
}
