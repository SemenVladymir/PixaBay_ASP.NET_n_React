using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TestASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        [HttpGet]
        [Route("GetImages")]
        public IActionResult GetImages()
        {

        }
    }
}
