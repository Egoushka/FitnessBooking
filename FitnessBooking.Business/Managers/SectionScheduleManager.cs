using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Core.Models.Dto.SectionSchredule;
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

        public async Task<SectionSchreduleDto> AddNewSectionSchedule(NewSectionSchreduleDto newSectionSchredule)
        {
            var sectionSchedule = new SectionSchedule
            {
                EndHour = TimeSpan.FromSeconds(newSectionSchredule.EndHour),
                SectionId = newSectionSchredule.SectionId,
                StartHour = TimeSpan.FromSeconds(newSectionSchredule.StartHour)
            };
            var result = await _sectionScheduleRepository.AddAsync(sectionSchedule);
            return FromEntityToDto(result);
        }

        public IEnumerable<SectionSchreduleDto> GetSectionSchedules(GetSectionShreduleRequest request)
        {
            IEnumerable<SectionSchedule> sectionShredules = _sectionScheduleRepository.GetAll();

            if (request.Id != null)
            {
                sectionShredules = sectionShredules.Where(sectionShredule =>
                sectionShredule.Id == request.Id);
            }
            if (request.SectionId != null)
            {
                sectionShredules = sectionShredules.Where(sectionShredule =>
                sectionShredule.SectionId == request.SectionId);
            }
            if (request.StartHour != null)
            {
                sectionShredules = sectionShredules.Where(sectionShredule =>
                sectionShredule.StartHour.CompareTo(request.StartHour) < 0);
            }
            if (request.EndHour != null)
            {
                sectionShredules = sectionShredules.Where(sectionShredule =>
                sectionShredule.EndHour.CompareTo(request.EndHour) > 0);
            }

            return sectionShredules.Select(section => FromEntityToDto(section));
        }

        public async Task<SectionSchreduleDto> UpdateSectionSchedule(UpdateSectionSchreduleDto updateSectionSchredule)
        {
            var sectionSchedule = _sectionScheduleRepository.GetAll().FirstOrDefault(gym => gym.Id == updateSectionSchredule.Id);
            if (sectionSchedule == null)
            {
                return null;
            }

            sectionSchedule.StartHour = TimeSpan.FromSeconds(updateSectionSchredule.StartHour);
            sectionSchedule.EndHour = TimeSpan.FromSeconds(updateSectionSchredule.EndHour);
            sectionSchedule.SectionId = updateSectionSchredule.SectionId;

            var result = await _sectionScheduleRepository.UpdateAsync(sectionSchedule);
            return FromEntityToDto(result);
        }
        public SectionSchreduleDto FromEntityToDto(SectionSchedule sectionSchedule)
        {
            return new SectionSchreduleDto
            {
                Id = sectionSchedule.Id,
                EndHour = sectionSchedule.EndHour,
                SectionId = sectionSchedule.SectionId,
                StartHour = sectionSchedule.StartHour,
            };
        }
    }
}