using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Dto.User;

namespace FitnessBooking.Core.Interfaces.Singletons
{
    public interface IJwtTokenUtils : ISingletonService
    {
        public string GenerateJwtToken(AuthenticateUserDto authenticateUseruser);
    }
}