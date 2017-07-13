namespace CarsSystem.ConsoleClient
{
    using System.IO;
    using System.Linq;
    using Newtonsoft.Json;
    using CarsSystem.ConsoleClient.Models;
    using System.Collections.Generic;
    using CarsSystem.Models;
    using System;
    using CarsSystem.Data;
    public static class JsonCarsImporter
    {
        private const string JsonFilePathFormat = "/JsonFiles/data.{0}.json";
        public static void Import()
        {
            var carsToAdd = Directory.GetFiles(Directory.GetCurrentDirectory() + "/JsonFiles/")
                .Where(f => f.EndsWith(".json"))
                .Select(f => File.ReadAllText(f))
                .SelectMany(str => JsonConvert.DeserializeObject<IEnumerable<CarJsonModel>>(str))
                .ToList();

            var addedCities = new HashSet<string>();
            var addedManufacturers = new HashSet<string>();
            Console.WriteLine("Addind cars");
            var addedCars = 0;
            var db = new CarsSystemDbContext();

            db.Configuration.AutoDetectChangesEnabled = false;
            db.Configuration.ValidateOnSaveEnabled = false;

            foreach (var car in carsToAdd)
            {
                var cityName = car.Dealer.City;
                if(!addedCities.Contains(cityName))
                {
                    var city = new City
                    {
                        Name = cityName,

                    };

                    db.Cities.Add(city);
                    db.SaveChanges();

                    addedCities.Add(cityName);

                }

                var manufacturer = car.ManufacturerName;

                if (!addedManufacturers.Contains(manufacturer))
                {
                    var newManufacturer = new Manufacturer
                    {
                        Name = manufacturer
                    };
                    addedManufacturers.Add(manufacturer);
                    db.Manufacturers.Add(newManufacturer);
                    db.SaveChanges();

                }

                var dealerToAdd = new Dealer
                {
                    Name = car.Dealer.Name
                };

                var dbCity = db.Cities.FirstOrDefault(c => c.Name == cityName);
                dealerToAdd.Cities.Add(dbCity);
                var dbManufacturer = db.Manufacturers.FirstOrDefault(m => m.Name == car.ManufacturerName);

                var carToAdd = new Car
                {
                    Manufacturer = dbManufacturer, 
                    Dealer = dealerToAdd, 
                    Model = car.Model,
                    Price = car.Price, 
                    Transmission = (TransmissionType)car.TransmissionType,
                    Year = car.Year
                };

                db.Cars.Add(carToAdd);

                if(addedCars % 100 == 0)
                {
                    Console.Write(".");
                    db.SaveChanges();
                    db.Dispose();
                    db = new CarsSystemDbContext();
                    db.Configuration.AutoDetectChangesEnabled = false;
                    db.Configuration.ValidateOnSaveEnabled = false;
                }

                addedCars++;
            }

            db.SaveChanges();
            db.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}
