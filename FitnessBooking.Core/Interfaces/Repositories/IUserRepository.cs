using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Infrastructure;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface IUserRepository : ITransientService, IRepository<User>
    {
        Task<User> GetUserByIdAsync(int Id);
    }
}