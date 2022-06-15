using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Core.Models.Dto.SectionSchedule;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Business.Managers
{
    public class SectionScheduleManager : ISectionScheduleManager
    {
        private readonly ISectionScheduleRepository _sectionScheduleRepository;

        public SectionScheduleManager(ISectionScheduleRepository sectionScheduleRepository)
        {
            _sectionScheduleRepository = sectionScheduleRepository;
        }

        public async Task<SectionScheduleDto> AddNewSectionSchedule(NewSectionScheduleDto newSectionSchedule)
        {
            var sectionSchedule = new SectionSchedule
            {
                EndHour = TimeSpan.FromSeconds(newSectionSchedule.EndHour),
                SectionId = newSectionSchedule.SectionId,
                StartHour = TimeSpan.FromSeconds(newSectionSchedule.StartHour)
            };
            var result = await _sectionScheduleRepository.AddAsync(sectionSchedule);
            return new SectionScheduleDto(result);
        }

        public IEnumerable<SectionScheduleDto> GetSectionSchedules(GetSectionScheduleRequest request)
        {
            return _sectionScheduleRepository
                .Find(section => section.IsAppreciateToRequest(request))
                .AsEnumerable()
                .Select(section => new SectionScheduleDto(section));
        }

        public async Task<SectionScheduleDto> UpdateSectionSchedule(UpdateSectionScheduleDto updateSectionSchedule)
        {
            var sectionSchedule = _sectionScheduleRepository.GetAll()
                .FirstOrDefault(gym => gym.Id == updateSectionSchedule.Id);
            if (sectionSchedule == null)
            {
                return null;
            }

            sectionSchedule.StartHour = TimeSpan.FromSeconds(updateSectionSchedule.StartHour);
            sectionSchedule.EndHour = TimeSpan.FromSeconds(updateSectionSchedule.EndHour);
            sectionSchedule.SectionId = updateSectionSchedule.SectionId;

            var result = await _sectionScheduleRepository.UpdateAsync(sectionSchedule);
            return new SectionScheduleDto(result);
        }
    }
}