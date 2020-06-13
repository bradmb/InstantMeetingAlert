using InstantMeetingAlert.Helpers;
using InstantMeetingAlert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InstantMeetingAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingToggleController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MeetingToggleController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Toggles the meeting status on/off
        /// </summary>
        /// <returns>The current meeting status the screen is in</returns>
        [HttpPost]
        public JsonResult Post()
        {
            HomeController.IsInMeeting = !HomeController.IsInMeeting;
            JoanDeviceHelper.RefreshDevice(_configuration);

            return new JsonResult(new MeetingStatus
            {
                CurrentStatus = HomeController.IsInMeeting ? " Meeting" : "Free"
            }); ;
        }
    }
}