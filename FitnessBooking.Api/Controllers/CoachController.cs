using FitnessBooking.Api.Attributes;
using FitnessBooking.Core.Enums;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Models.Dto.Coach;
using FitnessBooking.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoachController : Controller
    {
        private readonly ICoachManager _coachManager;

        public CoachController(ICoachManager coachManager)
        {
            _coachManager = coachManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
       // [RoleBasedAuth(allowedRoles: Roles.Administrator)]
        public async Task<IActionResult> AddNewCoach(NewCoachDto newCoach)
        {
            CoachDto answer = await _coachManager.AddNewCoach(newCoach);
            if (answer == null)
            {
                return BadRequest("Everything isn`t good, flowers aren`t colorful, the grass aren`t green");
            }

            return Json(answer);
        }

        [HttpPut]
        //[RoleBasedAuth(allowedRoles: Roles.Administrator)]
        public async Task<IActionResult> UpdateCoach(UpdateCoachDto updateCoach)
        {
            CoachDto answer = await _coachManager.UpdateCoach(updateCoach);
            if (answer == null)
            {
                return BadRequest("Everything isn`t good, flowers aren`t colorful, the grass aren`t green");
            }

            return Json(answer);
        }

        [HttpGet]
        public IActionResult GetCoaches(int? sectionId)
        {
            GetCoachRequest request = new GetCoachRequest();
            request.SectionId = sectionId;
            var answer = _coachManager.GetCoaches(request);
            if (answer == null)
            {
                return NotFound();
            }

            return Json(answer);
        }
    }
}