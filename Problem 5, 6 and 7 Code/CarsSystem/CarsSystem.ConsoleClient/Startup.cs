namespace CarsSystem.ConsoleClient
{
    using CarsSystem.Data;
    using CarsSystem.Data.Migrations;
    using System.Data.Entity;
    using System.Linq;
    public class Startup
    {
        public static void Main()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<CarsSystemDbContext>());

            var db = new CarsSystemDbContext();

            JsonCarsImporter.Import();
        }
    }
}
