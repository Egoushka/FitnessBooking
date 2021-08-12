using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Infrastructure;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface ICoachRepository : ITransientService, IRepository<Coach>
    {
        Task<Coach> GetCoachByIdAsync(int id);
    }
}