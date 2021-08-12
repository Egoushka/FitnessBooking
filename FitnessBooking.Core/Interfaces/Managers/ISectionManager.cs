using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Dto.Section;
using FitnessBooking.Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Managers
{
    public interface ISectionManager : ITransientService
    {
        public Task<SectionDto> AddNewSection(NewSectionDto newSection);

        public IEnumerable<SectionDto> GetSections(GetSectionRequest request);
        public Task<SectionDto> UpdateSection(UpdateSectionDto updateSection);
    }
}