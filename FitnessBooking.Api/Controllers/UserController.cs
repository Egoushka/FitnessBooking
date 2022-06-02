using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Models.Dto.User;
using FitnessBooking.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : Controller
    {
        private readonly IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPut]
        public IActionResult Register(RegisterUserDto registerUser)
        {
            var answer = _userManager.RegisterAsync(registerUser).Result;
            if (string.IsNullOrEmpty(answer))
            {
                return BadRequest("Can`t register user");

            }
            var response = new
            {
                access_token = answer,
                username = registerUser.Email
            };
            return Json(response);
        }

        [HttpPost]
        public IActionResult Login(LoginUserDto loginUser)
        {
            var answer = _userManager.Login(loginUser);
            if (string.IsNullOrEmpty(answer))
            {
                return BadRequest("Can`t login user");
            }
            var response = new
            {
                access_token = answer,
                username = loginUser.Email
            };
            return Json(response);
        }
        [HttpGet]
        public IActionResult Get(int? id, int? roleId, string name, string email)
        {
            var request = new GetUserRequest(id, roleId, email, name);

            var answer = _userManager.Get(request);
            if(answer == null)
            {
                return BadRequest();
            }
            return Json(answer);
        }


    }
}