using System;
using System.Threading.Tasks;

namespace CarDatabase
{
    public static partial class Program
    {
        static async Task Main()
        {
            using var context = new CarDbContext();
            await CleanDatabaseAsync(context);
            await FillCarMakesAsync(context);
            await FillCarModelsAsync(context);
            await FillPeopleAsync(context);
            await FillOwnershipsAsync(context);

            Statistics stats = new Statistics(context);
            // Task  
            // How many car ownerships have been created per car make
            Console.WriteLine(stats.GetNumberOfCarMakes());
            // Task
            // Which car models do not have any assigned ownerships
            Console.WriteLine(stats.GetUnassignedCarModels());

        }
    }
}
