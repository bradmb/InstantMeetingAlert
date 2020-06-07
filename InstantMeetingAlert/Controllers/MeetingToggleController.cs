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