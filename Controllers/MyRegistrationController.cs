using Microsoft.AspNetCore.Mvc;
using Pixabay.DAL.Entities;
using System.Net;

namespace TestASP.Net.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class MyRegistrationController : Controller
    {
        [HttpPost]
        [Route("Verification")]
        public JsonResult ClientRegistration([FromForm] MyRegistration newData)
        {
            try
            {
                if (!string.IsNullOrEmpty(newData.Login) && !string.IsNullOrEmpty(newData.Password) && !string.IsNullOrEmpty(newData.Email) && newData.AvatarFile!=null)
                {
                    
                    return new JsonResult("You have passed the registration verification!");
                }
                else
                    return new JsonResult("You haven`t passed the registration verification!");
            }
            catch (Exception)
            {
                return new JsonResult("");
            }
        }

    }
}
