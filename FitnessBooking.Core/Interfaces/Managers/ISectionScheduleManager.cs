using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Dto.SectionSchredule;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Interfaces.Managers
{
    public interface ISectionScheduleManager : ITransientService
    {
        public Task<SectionSchreduleDto> AddNewSectionSchedule(NewSectionSchreduleDto newSectionSchredule);

        public IEnumerable<SectionSchreduleDto> GetSectionSchedules(GetSectionShreduleRequest request);

        public Task<SectionSchreduleDto> UpdateSectionSchedule(UpdateSectionSchreduleDto updateSectionSchredule);
    }
}