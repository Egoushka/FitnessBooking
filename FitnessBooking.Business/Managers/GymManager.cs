using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Dto.Gym;
using FitnessBooking.Core.Models.Dto.Section;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBooking.Business.Managers
{
    public class GymManager : IGymManager
    {
        private readonly IGymRepository _gymRepository;
        private readonly ISectionManager _sectionManager;

        public GymManager(IGymRepository gymRepository, ISectionManager sectionManager)
        {
            _gymRepository = gymRepository;
            _sectionManager = sectionManager;
        }

        public async Task<GymDto> AddNewGym(NewGymDto newGym)
        {
            Gym gym = new Gym()
            {
                Description = newGym.Description,
                Location = newGym.Location,
                Name = newGym.Name
            };

            Gym answer =  await _gymRepository.AddAsync(gym);

            return FromEntityToDto(answer);
        }
        public IEnumerable<GymDto> GetGyms(GetGymRequest request)
        {
            IEnumerable<Gym> gyms = _gymRepository.GetAll();
            if (request.Name != null)
            {
                gyms = gyms.Where(gym =>
                gym.Name.ToUpper().Contains(request.Name.ToUpper()));
            }
            if (request.Location != null)
            {
                gyms = gyms.Where(gym =>
                gym.Location.ToUpper().Contains(request.Location.ToUpper()));
            }
            if (request.SectionRequest != null) {

                var sections = _sectionManager.GetSections(request.SectionRequest);
                if(sections.Count() == 0)
                {
                    return gyms.Select(gym => FromEntityToDto(gym));
                }
                foreach (var section in sections.Select(section => FromEntityToDto(section)))
                {
                    gyms = gyms.Where(gym => gym.Sections.Contains(section));
                }
            }
            return gyms.Select(gym => FromEntityToDto(gym));
        }

        public async Task<GymDto> UpdateGym(UpdateGymDto updateGym)
        {
            Gym gym = _gymRepository.GetAll().Where(gym => gym.Id.Equals(updateGym.Id)).FirstOrDefault();
            if (gym == null)
            {
                return null;
            }
            gym.Name = updateGym.Name;
            gym.Location = updateGym.Location;
            gym.Description = updateGym.Description;
            var answer =  await _gymRepository.UpdateAsync(gym);
            return FromEntityToDto(answer);
        }
        private Section FromEntityToDto(SectionDto section)
        {
            return new Section()
            {
                Id = section.Id,
                GymId = section.GymId,
                TypeId = section.TypeId,
                Name = section.Name
            };
        }
        private GymDto FromEntityToDto(Gym gym)
        {
            return new GymDto()
            {
                Id = gym.Id,
                Description = gym.Description,
                Location = gym.Location,
                Name = gym.Name,
                Sections = gym.Sections
            };
        }
        public ICollection<Section> MapToDto(ICollection<SectionDto> sectionDtos)
        {
            List<Section> answer = new List<Section>();

            foreach (var sectionDto in sectionDtos)
            {
                answer.Add(new Section()
                {
                    GymId = sectionDto.GymId,
                    Id = sectionDto.Id,
                    Name = sectionDto.Name,
                    TypeId = sectionDto.TypeId
                });
            }
            return answer;
        }


    }
}