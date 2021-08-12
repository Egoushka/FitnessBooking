using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Models.Dto.Coach;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Core.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FitnessBooking.Business.Managers
{
    public class CoachManager : ICoachManager
    {
        private ICoachRepository _coachRepository;

        public CoachManager(ICoachRepository coachRepository)
        {
            _coachRepository = coachRepository;
        }

        public async Task<CoachDto> AddNewCoach(NewCoachDto newCoach)
        {
            Coach coach = new Coach()
            {
                SectionId = newCoach.SectionId,
                UserId = newCoach.UserId
            };

            coach = await _coachRepository.AddAsync(coach);

            return FromEntityToDto(coach);
        }

        public IEnumerable<CoachDto> GetCoaches(GetCoachRequest request)
        {
            IEnumerable<Coach> coaches = _coachRepository.GetAll().AsEnumerable();

            if (request.SectionId != null)
            {
                coaches = coaches.Where(coach =>
               coach.SectionId.CompareTo(request.SectionId) == 0);
            }
            return coaches.Select(coach => FromEntityToDto(coach)) ;
        }

        public async Task<CoachDto> UpdateCoach(UpdateCoachDto updateCoach)
        {
            Coach coach = _coachRepository.GetAll().Where(gym => gym.Id.Equals(updateCoach.Id)).FirstOrDefault();
            if (coach == null)
            {
                return null;
            }
            coach.SectionId = updateCoach.SectionId;
            coach = await _coachRepository.UpdateAsync(coach);
            return FromEntityToDto(coach);
        }

        private CoachDto FromEntityToDto(Coach coach)
        {
            return new CoachDto()
            {
                Id = coach.Id,
                SectionId = coach.SectionId,
                UserId = coach.UserId
            };
        }

    }
}