using InstantMeetingAlert.Helpers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace InstantMeetingAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingStopController : ControllerBase
    {
        private readonly IConfiguration _configuration;

        public MeetingStopController (IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpGet]
        public JsonResult Get()
        {
            HomeController.IsInMeeting = false;
            JoanDeviceHelper.RefreshDevice(_configuration);

            return new JsonResult("complete");
        }
    }
}