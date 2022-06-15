using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Data.Models;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class SectionScheduleRepository : Repository<SectionSchedule>, ISectionScheduleRepository
    {
        public SectionScheduleRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }
    }
}