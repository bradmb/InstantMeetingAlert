using InstantMeetingAlert.Helpers;
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

        [HttpGet]
        public JsonResult Get()
        {
            HomeController.IsInMeeting = true;
            JoanDeviceHelper.RefreshDevice(_configuration);

            return new JsonResult("complete");
        }
    }
}