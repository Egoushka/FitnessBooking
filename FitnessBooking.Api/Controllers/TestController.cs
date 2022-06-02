using FitnessBooking.Api.Attributes;
using FitnessBooking.Core.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace FitnessBooking.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors]
    public class TestController : ControllerBase
    {
        [HttpGet]
        [Route("visitor")]
        [RoleBasedAuth(Roles.Visitor)]
        public IActionResult VisitorTest()
        {
            return Ok("visitor page");
        }

        [HttpGet]
        [Route("admin")]
        [RoleBasedAuth(Roles.Administrator)]
        public IActionResult AdminTest()
        {
            return Ok("admin page");
        }

        [HttpGet]
        [Route("coach")]
        [RoleBasedAuth(Roles.Coach)]
        public IActionResult CoachTest()
        {
            return Ok("coach page");
        }

        [HttpGet]
        [Route("register")]
        [RoleBasedAuth(Roles.Administrator | Roles.Coach | Roles.Visitor)]
        public IActionResult RegisterTest()
        {
            return Ok("Page for visitors, admins, coaches");
        }

        [HttpGet]
        [Route("allUsers")]
        [AllowAnonymous]
        public IActionResult AllUsersTest()
        {
            return Ok("Page for all users");
        }
    }
}