using Microsoft.AspNetCore.Mvc;

namespace InstantMeetingAlert.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MeetingStartController : ControllerBase
    {
        [HttpGet]
        public JsonResult Get()
        {
            HomeController.IsInMeeting = true;
            return new JsonResult("complete");
        }
    }
}