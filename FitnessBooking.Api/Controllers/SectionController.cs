using System.Threading.Tasks;
using FitnessBooking.Api.Attributes;
using FitnessBooking.Core.Enums;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Models.Dto.Section;
using FitnessBooking.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionController : Controller
    {
        private readonly ISectionManager _sectionManager;

        public SectionController(ISectionManager sectionManager)
        {
            _sectionManager = sectionManager;
        }

        [HttpPost]
      //[RoleBasedAuth(allowedRoles: Roles.Administrator)]
        public async Task<IActionResult> AddNewSection(NewSectionDto newSection)
        {
            var answer = await _sectionManager.AddNewSection(newSection);
            if (answer == null)
            {
                return BadRequest("Can`t add section");
            }

            return Json(answer);
        }

        [HttpPut]
        [RoleBasedAuth(Roles.Administrator)]
        public async Task<IActionResult> UpdateSection(UpdateSectionDto updateSection)
        {
            var answer = await _sectionManager.UpdateSection(updateSection);
            if (answer == null)
            {
                return BadRequest("Can`t update section");
            }

            return Json(answer);
        }

        [HttpGet]
        public async Task<IActionResult> GetSections(string name, int? id, int? typeId, int? gymId, int? coachId)
        {
            var sectionRequest = new GetSectionRequest(name, id, typeId, gymId, coachId);
            var answer = _sectionManager.GetSections(sectionRequest);
            if (answer == null)
            {
                return BadRequest("Can`t update section");
            }

            return Json(answer);
        }
    }
}