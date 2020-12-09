using InstantMeetingAlert.Helpers;
using InstantMeetingAlert.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InstantMeetingAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingStartController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MeetingStartController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        /// <summary>
        /// Toggles the meeting status on
        /// </summary>
        /// <returns>The current meeting status the screen is in in a HomeKit-ready value</returns>
        [HttpPost]
        public JsonResult Post()
        {
            HomeController.IsInMeeting = true;
            JoanDeviceHelper.RefreshDevice(_configuration);

            return new JsonResult(1);
        }
    }
}
