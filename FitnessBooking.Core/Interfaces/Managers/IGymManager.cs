using System.Collections.Generic;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Dto.Gym;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Interfaces.Managers
{
    public interface IGymManager : ITransientService
    {
        public Task<GymDto> AddNewGym(NewGymDto newGym);

        public IEnumerable<GymDto> GetGyms(GetGymRequest request);

        public Task<GymDto> UpdateGym(UpdateGymDto updateGym);
    }
}