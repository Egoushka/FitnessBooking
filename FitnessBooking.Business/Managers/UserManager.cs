using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using FitnessBooking.Core.Enums;
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
        private readonly IUserRepository _userRepository;
        private readonly IJwtTokenUtils _jwtTokenUtils;

        public UserManager(IUserRepository userRepository, IHashUtils hashUtils, IJwtTokenUtils jwtTokenUtils)
        {
            _userRepository = userRepository;
            _hashUtils = hashUtils;
            _jwtTokenUtils = jwtTokenUtils;
        }

        public string Login(LoginUserDto loginUserDto)
        {
            var result = _userRepository.GetAll().FirstOrDefault(user => string.Equals(user.Email, loginUserDto.Email));
            if (result == null)
            {
                return null;
            }
            if (!_hashUtils.VerifyHash(loginUserDto.Password, result.Password))
            {
                //return wrong pass
                return null;
            }
            var authenticateUser = new AuthenticateUserDto
            {
                Id = result.Id,
                Email = result.Email,
                Name = result.Name,
                Password = result.Password,
                Role = (Roles)result.RoleId
            };
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
            var authenticateUser = MapToDto(user);
            var jwtToken = _jwtTokenUtils.GenerateJwtToken(authenticateUser);
            return jwtToken;
        }
        public IEnumerable Get(GetUserRequest request)
        {
            var users = _userRepository.GetAll();
            if(request.Id != null)
            {
                users = users.Where(item => item.Id == request.Id);
            }
            if(request.RoleId != null)
            {
                users = users.Where(item => item.RoleId == request.RoleId);
            }
            if (request.Name != null)
            {
                users = users.Where(item => item.Name == request.Name);
            }
            if (request.Email != null)
            {
                users = users.Where(item => item.Email == request.Email);
            }
            return users.AsEnumerable().Select(item => MapToDto(item));
        }
        public AuthenticateUserDto MapToDto(User user)
        {
            return new AuthenticateUserDto
            {
                Id = user.Id,
                Email = user.Email,
                Name = user.Name,
                Password = user.Password,
                Role = (Roles)user.RoleId
            };
        }
    }
}