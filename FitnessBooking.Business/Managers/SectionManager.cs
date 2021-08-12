using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Dto.Section;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Core.Models.Requests;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBooking.Business.Managers
{
    public class SectionManager : ISectionManager
    {
        private readonly ISectionRepository _sectionRepository;

        public SectionManager(ISectionRepository sectionRepository)
        {
            _sectionRepository = sectionRepository;
        }

        public async Task<SectionDto> AddNewSection(NewSectionDto newSection)
        {
            Section section = new Section()
            {
                Name = newSection.Name,
                GymId = newSection.GymId,
                TypeId = newSection.TypeId,
            };
            var answer = await _sectionRepository.AddAsync(section);
            return FromEntityToDto(answer);
        }

        public async Task<SectionDto> UpdateSection(UpdateSectionDto updateSection)
        {
            Section section = _sectionRepository.GetAll().Where(gym => gym.Id.Equals(updateSection.Id)).FirstOrDefault();
            if (section == null)
            {
                return null;
            }
            section.GymId = updateSection.GymId;
            section.Name = updateSection.Name;
            section.TypeId = updateSection.TypeId;

            var answer = await _sectionRepository.UpdateAsync(section);

            return FromEntityToDto(answer);

        }

        public IEnumerable<SectionDto> GetSections(GetSectionRequest request)
        {
            IEnumerable<Section> sections = _sectionRepository.GetAll();
            if (request.Id != null)
            {
                sections = sections.Where(section =>
                section.Id == request.Id);
            }
            if (request.Name != null)
            {
                sections = sections.Where(section =>
                section.Name.ToUpper().Contains(request.Name.ToUpper()));
            }
            if (request.GymId != null)
            {
                sections = sections.Where(section =>
                section.GymId == request.GymId);
            }
            if (request.TypeId != null)
            {
                sections = sections.Where(gym =>
                gym.TypeId == request.TypeId);
            }
            if (request.CoachId != null)
            {
                sections = sections.Where(section =>
                 section.Coaches.Any(coach => coach.Id.CompareTo(request.CoachId) == 0));
            }
            return sections.Select(section=> FromEntityToDto(section));
        }

        private SectionDto FromEntityToDto(Section section)
        {
            return new SectionDto()
            {
                Id = section.Id,
                GymId = section.GymId,
                TypeId = section.TypeId,
                Name = section.Name
            };
        }
    }
}