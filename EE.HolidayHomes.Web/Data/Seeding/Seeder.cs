using EE.HolidayHomes.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace EE.HolidayHomes.Web.Data.Seeding
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder modelBuilder)
        {
            HomeProperty[] homeProperties = new HomeProperty[]
            {
                new HomeProperty{Id = 1, Name = "Rural"},
                new HomeProperty{Id = 2, Name = "Seaside"},
                new HomeProperty{Id = 3, Name = "Luxury"},
                new HomeProperty{Id = 4, Name = "Budget"},
                new HomeProperty{Id = 5, Name = "Family"},
                new HomeProperty{Id = 6, Name = "Business"},
            };
            Location[] locations = new Location[]
            {
                new Location{Id = 1, Name = "Lapscheure"},
                new Location{Id = 2, Name = "Izegem"},
                new Location{Id = 3, Name = "Blankenberge"},
                new Location{Id = 4, Name = "Sint-Pieterskapelle"},
            };

            HomeType[] homeTypes = new HomeType[]
            {
                new HomeType{Id=1, Name = "Cottage"},
                new HomeType{Id=2, Name = "Villa"},
                new HomeType{Id=3, Name = "Appartment"},
                new HomeType{Id=4, Name = "Room"},
            };

            HolidayHome[] holidayHomes = new HolidayHome[]
            {
                new HolidayHome{Id = 1,Name = "The Villa",Price = 120.50M,Image = "house1.jpg",LocationId = 1, HomeTypeId=2},
                new HolidayHome{Id = 2,Name = "The Cottage",Price = 250.55M,Image = "house2.jpg", LocationId = 2, HomeTypeId=1},
                new HolidayHome{Id = 3,Name = "The farmhouse",Price = 350.50M,Image = "house3.jpg", LocationId = 3, HomeTypeId=4},
                new HolidayHome{Id = 4,Name = "The seaside house",Price = 350.55M,Image = "house4.jpg", LocationId = 4, HomeTypeId=3},
            };



            modelBuilder.Entity<HomeProperty>().HasData(homeProperties);
            modelBuilder.Entity<Location>().HasData(locations);
            modelBuilder.Entity<HomeType>().HasData(homeTypes);
            modelBuilder.Entity<HolidayHome>().HasData(holidayHomes);
        }
    }
}
