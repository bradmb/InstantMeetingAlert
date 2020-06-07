using Microsoft.AspNetCore.Mvc;

namespace InstantMeetingAlert.Controllers
{
    public class HomeController : Controller
    {
        /// <summary>
        /// If true, the user is in an unscheduled meeting
        /// </summary>
        internal static bool IsInMeeting { get; set; } = false;

        /// <summary>
        /// Displays the ad-hoc meeting notification or redirects to the
        /// standard calendar view
        /// </summary>
        /// <param name="id">The device UUID</param>
        /// <returns>A view or a redirect</returns>
        public IActionResult Index(string id)
        {
            if (IsInMeeting)
            {
                return View();
            }

            return Redirect($"https://master.joan.vnct.xyz/uuid/{id}/");
        }
    }
}