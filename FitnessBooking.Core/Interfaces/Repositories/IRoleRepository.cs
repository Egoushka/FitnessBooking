using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Infrastructure;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface IRoleRepository : ITransientService, IRepository<Role>
    {
        Task<Role> GetRoleByIdAsync(int id);
    }
}