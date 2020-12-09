using InstantMeetingAlert.Helpers;
using InstantMeetingAlert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InstantMeetingAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingStatusController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        /// <summary>
        /// Gets the current meeting status value
        /// for use within HomeKit
        /// </summary>
        /// <returns>The status value</returns>
        [HttpPost]
        public JsonResult Post()
        {
            return new JsonResult(HomeController.IsInMeeting ? 1 : 0);
        }
    }
}
