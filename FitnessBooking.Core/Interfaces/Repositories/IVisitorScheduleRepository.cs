using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Infrastructure;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface IVisitorScheduleRepository : ITransientService, IRepository<VisitorSchedule>
    {
        Task<VisitorSchedule> GetVisitorScheduleByIdAsync(int Id);
    }
}