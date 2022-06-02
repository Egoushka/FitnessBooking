using System.Threading.Tasks;
using FitnessBooking.Core.Interfaces.Managers;
using FitnessBooking.Core.Models.Dto.VisitorSchedule;
using FitnessBooking.Core.Models.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubscriptionController : Controller
    {
        private readonly IVisitorScheduleManager _visitorScheduleManager;

        public SubscriptionController(IVisitorScheduleManager visitorScheduleManager)
        {
            _visitorScheduleManager = visitorScheduleManager;
        }

        [HttpPost]
        [Route("subscribe")]
        public async Task<IActionResult> SubscribeAsync(NewVisitorScheduleDto visitorScheduleDto)
        {
            var answer = await _visitorScheduleManager.Subscribe(visitorScheduleDto);

            if (answer == null)
            {
                return BadRequest("Can`t subscribe");
            }
            return Json(answer);
        }

        [HttpPut]
        [Route("unSubscribe")]
        public async Task<IActionResult> UnSubscribeAsync(RemoveVisitorScheduleDto visitorScheduleDto)
        {
            var answer = await _visitorScheduleManager.UnSubscribe(visitorScheduleDto);

            if (answer == null)
            {
                return BadRequest("Can`t update subscribe");
            }
            return Json(answer);
        }

        [HttpPut]
        [Route("updateSubscribe")]
        public async Task<IActionResult> UpdateSubscribeAsync(UpdateVisitorScheduleDto  updateVisitorSchedule)
        {
            var answer = await _visitorScheduleManager.UpdateSubscribe(updateVisitorSchedule);

            if (answer == null)
            {
                return BadRequest("Can`t unsubscribe");
            }
            return Json(answer);
        }
        [HttpGet]
        public IActionResult GetUserSubscriptions(int? id, int? userId, int? visitorScheduleId)
        {
            var request = new GetVisitorScheduleRequest(id, userId, visitorScheduleId);
            var answer =  _visitorScheduleManager.Get(request);

            if (answer == null)
            {
                return BadRequest("Can`t subscribe");
            }
            return Json(answer);
        }

    }
}