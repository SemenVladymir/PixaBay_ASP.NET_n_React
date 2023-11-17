using Microsoft.AspNetCore.Mvc;
using Pixabay.DAL.Entities;
using System.Net;
using System.Reflection.Metadata;

namespace TestASP.Net.Controllers
{
    [Route("api/file")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        public ActionResult GetFile([FromForm] FileModel file) 
        {
            try
            {
                string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", file.FormFile.FileName);

                using (Stream stream = new FileStream(path, FileMode.Create))
                {
                    file.FormFile.CopyTo(stream);
                }
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        }

        
    }
}
