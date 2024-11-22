using Microsoft.AspNetCore.Mvc;

namespace Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HealthController : Controller
    {
        [HttpGet]
        public IActionResult GetStatus()
        {
            return Ok(new { status = "Server is running" });
        }
    }
}
