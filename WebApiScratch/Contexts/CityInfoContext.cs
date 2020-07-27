using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiScratch.Entities;

namespace WebApiScratch.Contexts
{
    public class CityInfoContext :DbContext
    {
        public DbSet<City> CityTable { set; get; }

        public DbSet<PointOfInterest> PointsTable { get; set; }

        public CityInfoContext(DbContextOptions<CityInfoContext> options ) :base(options)
        {
            //Database.EnsureCreated();
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City {
                    Id = 1,
                    Name = "Nairobi",
                    Detail = "Busy City especially during rush hours.",
                },
                new City
                {
                    Id = 2,
                    Name = "New York",
                    Detail = "Has a big park within the city center",
                }
            );

            modelBuilder.Entity<PointOfInterest>().HasData(
                new PointOfInterest { Id = 1, Name = "Maasai Mara", CityId=1, Comment = "Very enjoyable place" },
                new PointOfInterest { Id = 2, Name = "Bomas of Kenya", CityId = 1, Comment = "A bit too serious" },
                new PointOfInterest{ Id = 3, Name = "Nation Assembly", CityId = 2, Comment = "Ohh! Politicos!" },
                new PointOfInterest{ Id = 4, Name = "Oama park", CityId = 2, Comment = "Dinosaures leave here." }

            );
            base.OnModelCreating(modelBuilder);
        }

    }
}
