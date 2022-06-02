using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface IUserRepository : ITransientService, IRepository<User>
    {
    }
}