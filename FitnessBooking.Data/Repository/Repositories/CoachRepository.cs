using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class CoachRepository : Repository<Coach>, ICoachRepository
    {
        public CoachRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }
    }
}