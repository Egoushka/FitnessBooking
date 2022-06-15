using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessBooking.Core.Enums;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Core.Models.Dto.VisitorSchedule;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Business.Managers
{
    public class VisitorScheduleManager : IVisitorScheduleManager
    {
        private readonly IVisitorScheduleRepository _visitorScheduleRepository;

        public VisitorScheduleManager(IVisitorScheduleRepository visitorScheduleRepository)
        {
            _visitorScheduleRepository = visitorScheduleRepository;
        }

        public async Task<VisitorScheduleDto> Subscribe(NewVisitorScheduleDto visitorScheduleDto)
        {
            var visitorSchedule = new VisitorSchedule(visitorScheduleDto);
            visitorSchedule.StatusId = (int) ScheduleStatus.Ordered;
            var result = await _visitorScheduleRepository.AddAsync(visitorSchedule);

            return new VisitorScheduleDto(result);
        }

        public IEnumerable<VisitorScheduleDto> Get(GetVisitorScheduleRequest request)
        {
            var result =
                _visitorScheduleRepository.Find(schedule => schedule.IsAppreciateToRequest(request));

            return result.AsEnumerable().Select(item => new VisitorScheduleDto(item));
        }

        public async Task<VisitorScheduleDto> UpdateSubscribe(UpdateVisitorScheduleDto visitorScheduleDto)
        {
            var visitorSchedule = new VisitorSchedule(visitorScheduleDto);

            var result = await _visitorScheduleRepository.UpdateAsync(visitorSchedule);

            return new VisitorScheduleDto(result);
        }

        public async Task<VisitorScheduleDto> UnSubscribe(RemoveVisitorScheduleDto visitorScheduleDto)
        {
            var visitorSchedule = new VisitorSchedule(visitorScheduleDto);
            visitorSchedule.StatusId = 3;
            var result = await _visitorScheduleRepository.UpdateAsync(visitorSchedule);

            return new VisitorScheduleDto(result);
        }
    }
}