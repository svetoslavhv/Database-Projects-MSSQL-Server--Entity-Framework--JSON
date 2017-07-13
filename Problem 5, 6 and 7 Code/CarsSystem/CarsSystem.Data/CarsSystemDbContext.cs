namespace CarsSystem.Data
{
    using CarsSystem.Models;
using System.Data.Entity;
    public class CarsSystemDbContext : DbContext
    {
        public CarsSystemDbContext()
            :base("CarsSystem")
        {

        }

        public virtual IDbSet<Car> Cars { get; set; }

        public virtual IDbSet<Dealer> Dealers { get; set; }

        public virtual IDbSet<Manufacturer> Manufacturers { get; set; }

        public virtual IDbSet<City> Cities { get; set; }

    }
}
