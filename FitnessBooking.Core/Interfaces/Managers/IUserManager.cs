using System.Collections;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Infrastructure;
using FitnessBooking.Core.Models.Dto.User;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Core.Interfaces.Managers
{
    public interface IUserManager : ITransientService
    {
        Task<string> RegisterAsync(RegisterUserDto registerUser);

        string Login(LoginUserDto loginUserDto);

        IEnumerable Get(GetUserRequest request);
    }
}