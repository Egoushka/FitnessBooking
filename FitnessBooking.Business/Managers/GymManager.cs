﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models;
using FitnessBooking.Core.Models.Dto.Gym;
using FitnessBooking.Core.Models.Dto.Section;
using FitnessBooking.Core.Models.Requests;

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
            var gym = new Gym
            {
                Description = newGym.Description,
                Location = newGym.Location,
                Name = newGym.Name
            };

            var answer = await _gymRepository.AddAsync(gym);

            return new GymDto(answer);
        }

        public IEnumerable<GymDto> GetGyms(GetGymRequest request)
        {
            return _gymRepository
                .Find(gym => gym.Equals(request))
                .AsEnumerable()
                .Select(GymDto.FromEntityToDto);
        }

        public async Task<GymDto> UpdateGym(UpdateGymDto updateGym)
        {
            var gym = _gymRepository.GetEntityById(updateGym.Id);
           
            if (gym == null)
            {
                return null;
            }
            
            gym.Name = updateGym.Name;
            gym.Location = updateGym.Location;
            gym.Description = updateGym.Description;
            
            var answer =  await _gymRepository.UpdateAsync(gym);

            return new GymDto(answer);
        }
      
       
        public ICollection<Section> MapToDto(IEnumerable<SectionDto> sectionDtos)
        {
            return sectionDtos
                .Select(sectionDto => 
                    new Section
                    {
                        GymId = sectionDto.GymId, 
                        Id = sectionDto.Id, 
                        Name = sectionDto.Name, 
                        TypeId = sectionDto.TypeId
                    })
                .ToList();
        }


    }
}