using EE.HolidayHomes.Core.Entities;
using EE.HolidayHomes.Web.Data.Seeding;
using Microsoft.EntityFrameworkCore;

namespace EE.HolidayHomes.Web.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<HolidayHome> HolidayHomes { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<HomeProperty> HomeProperties { get; set; }
        public DbSet<HomeType> HomeTypes { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<HolidayHome>().Property(h => h.Price)
                .HasColumnType("money");
            base.OnModelCreating(modelBuilder);
            Seeder.Seed(modelBuilder);
        }
    }
}
