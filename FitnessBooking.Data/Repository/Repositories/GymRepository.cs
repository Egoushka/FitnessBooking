using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class GymRepository : Repository<Gym>, IGymRepository
    {
        public GymRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }

        public Task<Gym> GetGymByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}