using Microsoft.AspNetCore.Mvc;

namespace IceBox.Web.Controllers
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