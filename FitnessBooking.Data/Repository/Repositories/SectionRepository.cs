using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class SectionRepository : Repository<Section>, ISectionRepository
    {
        public SectionRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }

        public Task<Section> GetSectionByIdAsync(int id)
        {
            return GetAll().FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}