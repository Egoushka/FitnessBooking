using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Data.Models;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class GymRepository : Repository<Gym>, IGymRepository
    {
        public GymRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }
    }
}