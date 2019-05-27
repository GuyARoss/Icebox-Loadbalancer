using Microsoft.AspNetCore.Mvc;

namespace Icebox.Web.Controllers
{
    [Route("Analytics")]
    [ApiController]
    public class AnalyticsController : ControllerBase
    {
        [HttpGet("isActive")]
        public ActionResult IsServerActive()
        {
            return StatusCode(200);
        }
    }
}