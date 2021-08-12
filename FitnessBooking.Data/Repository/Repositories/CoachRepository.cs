using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        public CoachRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }

        public Task<Coach> GetCoachByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}