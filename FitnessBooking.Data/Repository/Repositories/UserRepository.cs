using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }

        public Task<User> GetUserByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}