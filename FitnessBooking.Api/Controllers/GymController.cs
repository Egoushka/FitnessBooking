using System.Threading.Tasks;
using FitnessBooking.Api.Attributes;
using FitnessBooking.Core.Enums;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Models.Dto.Gym;
using FitnessBooking.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymController : Controller
    {
        private readonly IGymManager _gymManager;

        public GymController(IGymManager gymManager)
        {
            _gymManager = gymManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [RoleBasedAuth(Roles.Administrator)]
        public async Task<IActionResult> AddNewGym(NewGymDto newGym)
        {
            var answer = await _gymManager.AddNewGym(newGym);
            if (answer == null)
            {
                return BadRequest("Can`t add gym");
            }

            return Json(answer);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGym(UpdateGymDto updateGym)
        {
            var answer = await _gymManager.UpdateGym(updateGym);
            if (answer == null)
            {
                return BadRequest("Can`t update gym");
            }

            return Json(answer);
        }

        [HttpGet]
        public async Task<IActionResult> GetGyms(string name, string location)
        {
            var gymRequest = new GetGymRequest(name, location);
            var answer = _gymManager.GetGyms(gymRequest);
            if (answer == null)
            {
                return BadRequest("Can`t get gyms");
            }

            return Json(answer);
        }
    }
}