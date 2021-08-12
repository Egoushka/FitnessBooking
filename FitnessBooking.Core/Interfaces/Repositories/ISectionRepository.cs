using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Infrastructure;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Repositories
{
    public interface ISectionRepository : ITransientService, IRepository<Section>
    {
        Task<Section> GetSectionByIdAsync(int id);
    }
}