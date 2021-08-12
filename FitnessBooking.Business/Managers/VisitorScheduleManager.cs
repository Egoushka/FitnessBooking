using FitnessBooking.Core.Enums;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Dto.VisitorSchedule;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Core.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            VisitorSchedule visitorSchedule = FromDtoToEntity(visitorScheduleDto);
            visitorSchedule.StatusId = (int)ScheduleStatus.Ordered;
            var result = await _visitorScheduleRepository.AddAsync(visitorSchedule);

            return FromEntityToDto(result);
        }

        public IEnumerable<VisitorScheduleDto> Get(GetVisitorScheduleRequest request)
        {

            var result = _visitorScheduleRepository.GetAll();
            if (request.Id != null)
            {
                result = result.Where(item => item.Id == request.Id);
            }
            if (request.VisitorScheduleId != null)
            {
                result = result.Where(item => item.Id == request.VisitorScheduleId);
            }
            if (request.UserId != null)
            {
                result = result.Where(item => item.UserId == request.UserId);
            }
            return result.AsEnumerable().Select(item => FromEntityToDto(item));
        }
        public async Task<VisitorScheduleDto> UpdateSubscribe(UpdateVisitorScheduleDto visitorScheduleDto)
        {
            VisitorSchedule visitorSchedule = FromDtoToEntity(visitorScheduleDto);

            var result = await _visitorScheduleRepository.UpdateAsync(visitorSchedule);

            return FromEntityToDto(result);
        }

        public async Task<VisitorScheduleDto> UnSubscribe(RemoveVisitorScheduleDto visitorScheduleDto)
        {
            VisitorSchedule visitorSchedule = FromDtoToEntity(visitorScheduleDto);
            visitorSchedule.StatusId = 3;
            var result =  await _visitorScheduleRepository.UpdateAsync(visitorSchedule);

            return FromEntityToDto(result);

        }

        public VisitorScheduleDto FromEntityToDto(VisitorSchedule visitorSchedule)
        {
            return new VisitorScheduleDto()
            {
                Id = visitorSchedule.Id,
                StatusId = visitorSchedule.StatusId,
                SectionScheduleId =visitorSchedule.SectionScheduleId,
                UserId = visitorSchedule.UserId,
                Day =visitorSchedule.Day,
            };


        }
        public VisitorSchedule FromDtoToEntity(RemoveVisitorScheduleDto newVisitorSchedule)
        {
            return new VisitorSchedule()
            {
                StatusId = newVisitorSchedule.StatusId,
                Id = newVisitorSchedule.Id
            };
        }
        public VisitorSchedule FromDtoToEntity(UpdateVisitorScheduleDto newVisitorSchedule)
        {
            return new VisitorSchedule()
            {
                SectionScheduleId = newVisitorSchedule.SectionScheduleId,
                UserId = newVisitorSchedule.UserId,
                StatusId = newVisitorSchedule.StatusId,
                Day = newVisitorSchedule.Day,
                Id = newVisitorSchedule.Id
            };
        }
        public VisitorSchedule FromDtoToEntity(NewVisitorScheduleDto newVisitorSchedule)
        {
            return new VisitorSchedule()
            {
                SectionScheduleId = newVisitorSchedule.SectionScheduleId,
                UserId = newVisitorSchedule.UserId,
                StatusId = newVisitorSchedule.StatusId,
                Day = newVisitorSchedule.Day
            };
        }


    }
}