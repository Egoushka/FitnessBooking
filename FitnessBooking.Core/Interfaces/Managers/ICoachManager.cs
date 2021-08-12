using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Dto.Coach;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Core.Models.Requests;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitnessBooking.Core.Interfaces.Managers
{
    public interface ICoachManager : ITransientService
    {
        public Task<CoachDto> AddNewCoach(NewCoachDto newCoach);

        public IEnumerable<CoachDto> GetCoaches(GetCoachRequest request);

        public Task<CoachDto> UpdateCoach(UpdateCoachDto updateCoach);
    }
}