using InstantMeetingAlert.Helpers;
using InstantMeetingAlert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InstantMeetingAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingStopController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MeetingStopController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Toggles the meeting status off
        /// </summary>
        /// <returns>The current meeting status the screen is in in a HomeKit-ready value</returns>
        [HttpPost]
        public JsonResult Post()
        {
            HomeController.IsInMeeting = false;
            JoanDeviceHelper.RefreshDevice(_configuration);

            return new JsonResult(0);
        }
    }
}
