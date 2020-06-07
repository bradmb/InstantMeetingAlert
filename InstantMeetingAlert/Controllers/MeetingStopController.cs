using Microsoft.AspNetCore.Mvc;

namespace InstantMeetingAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingStopController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            HomeController.IsInMeeting = false;
            return new JsonResult("complete");
        }
    }
}