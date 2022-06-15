using System;
using System.Threading.Tasks;
using FitnessBooking.Api.Attributes;
using FitnessBooking.Core.Enums;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Models.Dto.SectionSchedule;
using FitnessBooking.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SectionScheduleController : Controller
    {
        private readonly ISectionScheduleManager _sectionScheduleManager;

        public SectionScheduleController(ISectionScheduleManager sectionSchedule)
        {
            _sectionScheduleManager = sectionSchedule;
        }

        [HttpPost]
        [RoleBasedAuth(Roles.Administrator)]
        public async Task<IActionResult> AddNewSectionScheduleAsync(NewSectionScheduleDto newSection)
        {
            var answer = await _sectionScheduleManager.AddNewSectionSchedule(newSection);

            if (answer == null)
            {
                return BadRequest("Can`t add section schedule");
            }

            return Json(answer);
        }

        [HttpPut]
        [RoleBasedAuth(Roles.Administrator)]
        public async Task<IActionResult> UpdateSectionSchedule(UpdateSectionScheduleDto updateSection)
        {
            var answer = await _sectionScheduleManager.UpdateSectionSchedule(updateSection);

            if (answer == null)
            {
                return BadRequest("Can`t update section schedule");
            }

            return Json(answer);
        }

        [HttpGet]
        public IActionResult GetSectionSchedules(int? id, int? sectionId, TimeSpan? startHour, TimeSpan? endHour)
        {
            var request = new GetSectionScheduleRequest(id, sectionId, startHour, endHour);
            var answer = _sectionScheduleManager.GetSectionSchedules(request);
            if (answer == null)
            {
                return NotFound();
            }

            return Json(answer);
        }
    }
}