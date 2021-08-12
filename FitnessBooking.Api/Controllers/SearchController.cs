using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Models.Dto.Gym;
using FitnessBooking.Core.Models.Dto.Section;
using FitnessBooking.Core.Models.Infrastructure;
using FitnessBooking.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SearchController : Controller
    {
        private readonly IGymManager _gymManager;

        public SearchController(IGymManager gymManager)
        {
            _gymManager = gymManager;
        }

        [HttpGet]
        public IActionResult GetGymsAndSection(GetGymRequest  request)
        {
            IEnumerable<GymDto> gyms = _gymManager.GetGyms(request);

            var response = new
            {
                gyms
            };

            return Json(response);
        }
    }
}