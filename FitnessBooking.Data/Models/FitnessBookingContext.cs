using FitnessBooking.Core.Models.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace FitnessBooking.Data.Models
{
    public class FitnessBookingContext : DbContext
    {
        public DbSet<Administrator> Administrator { get; set; }
        public DbSet<Coach> Coach { get; set; }
        public DbSet<Gym> Gym { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Section> Section { get; set; }
        public DbSet<SectionSchedule> SectionSchedule { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<VisitorSchedule> VisitorSchedule { get; set; }

        public FitnessBookingContext(DbContextOptions<FitnessBookingContext> options) : base(options)
        {
        }
    }
}