using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Data.Models;

namespace FitnessBooking.Data.Repository.Repositories
{
    public class VisitorScheduleRepository : Repository<VisitorSchedule>, IVisitorScheduleRepository
    {
        public VisitorScheduleRepository(FitnessBookingContext fitnessBookingContext) : base(fitnessBookingContext)
        {
        }
    }
}