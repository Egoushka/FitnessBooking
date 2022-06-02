using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Dto.VisitorSchedule;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Interfaces.Managers
{
    public interface IVisitorScheduleManager : ITransientService
    {
        public Task<VisitorScheduleDto> Subscribe(NewVisitorScheduleDto visitorSchedule);

        public Task<VisitorScheduleDto> UpdateSubscribe(UpdateVisitorScheduleDto  visitorSchedule);

        public Task<VisitorScheduleDto> UnSubscribe(RemoveVisitorScheduleDto visitorSchedule);
        public IEnumerable<VisitorScheduleDto> Get(GetVisitorScheduleRequest request);
    }
}