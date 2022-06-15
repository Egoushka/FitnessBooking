using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Interfaces.Repositories;
using FitnessBooking.Core.Interfaces.Singletons;
using FitnessBooking.Core.Models;
using FitnessBooking.Core.Models.Dto.User;
using FitnessBooking.Core.Models.Requests;

namespace FitnessBooking.Business.Managers
{
    public class UserManager : IUserManager
    {
        private readonly IHashUtils _hashUtils;
        private readonly IJwtTokenUtils _jwtTokenUtils;
        private readonly IUserRepository _userRepository;

        public UserManager(IUserRepository userRepository, IHashUtils hashUtils, IJwtTokenUtils jwtTokenUtils)
        {
            _userRepository = userRepository;
            _hashUtils = hashUtils;
            _jwtTokenUtils = jwtTokenUtils;
        }

        public string Login(LoginUserDto loginUserDto)
        {
            var result = _userRepository.Find(user => string.Equals(user.Email, loginUserDto.Email)).FirstOrDefault();
            if (result == null)
            {
                return null;
            }

            if (!_hashUtils.VerifyHash(loginUserDto.Password, result.Password))
            {
                //return wrong pass
                return null;
            }

            var authenticateUser = new AuthenticateUserDto(result);
            var jwtToken = _jwtTokenUtils.GenerateJwtToken(authenticateUser);

            return jwtToken;
        }

        public async Task<string> RegisterAsync(RegisterUserDto registerUser)
        {
            var user = new User
            {
                Email = registerUser.Email,
                Name = registerUser.Name,
                Password = _hashUtils.GetHash(registerUser.Password),
                RoleId = registerUser.RoleId
            };
            user = await _userRepository.AddAsync(user);

            var authenticateUser = new AuthenticateUserDto(user);

            var jwtToken = _jwtTokenUtils.GenerateJwtToken(authenticateUser);

            return jwtToken;
        }

        public IEnumerable Get(GetUserRequest request)
        {
            var users = _userRepository.Find(user => user.IsAppreciateToRequest(request));

            return users.AsEnumerable().Select(item => new AuthenticateUserDto(item));
        }
    }
}