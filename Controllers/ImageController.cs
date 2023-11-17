using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using Pixabay.DAL.EF;
using Pixabay.DAL.Entities;
using System.Net;

namespace TestASP.Net.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private MyWebRequest _request;

        [HttpPost]
        [Route("GetImages")]
        public JsonResult GetImages([FromForm] MyImage newData)
        {

            if (newData.Size != 0 && !string.IsNullOrEmpty(newData.Name))
            {
                var key = "39206396-a3d0261b98314ee7c13677bfd";
                var searchingText = newData.Name.Replace(' ', '+');

                _request = new MyWebRequest($"https://pixabay.com/api/?key={key}&q={searchingText}&image_type=photo&per_page={newData.Size}");
                _request.Start("GET");
                var response = _request.Response;
                if (response != null && response.Length > 0)
                {
                    var json = JObject.Parse(response);
                    var newimages = json["hits"];
                    Uri img;
                    Uri img1;
                    List<MyImage> Images = new List<MyImage>();
                    foreach (var item in newimages)
                    {
                        img = new Uri(item["largeImageURL"].ToString());
                        img1 = new Uri(item["pageURL"].ToString());
                        string[] tmp = img1.Segments.ToArray();
                        Images.Add(new MyImage { Name = $"{tmp.Last().Substring(0, tmp.Last().Length - 1)}{Path.GetExtension(img.ToString())}", Size = (double)Convert.ToInt32(item["imageWidth"])/ Convert.ToInt32(item["imageHeight"]), UrlPhoto = img.ToString() });
                    }
                    return new JsonResult(Images);
                }
                else
                    return new JsonResult("Images with this text aren`t found!");
            }
            else
                return new JsonResult("You need to input an amount of images!\nThe amount has to be 3 or more.");
        }

        [HttpPost]
        [Route("SaveImage")]
        public JsonResult SaveFile([FromForm] MyImage newData)
        {
            try
            {
                if (newData.UrlPhoto != null)
                {
                    WebClient client = new WebClient();
                    Uri img;
                    img = new Uri(newData.UrlPhoto);
                    client.DownloadFile(img, $@"D:/Images/{newData.Name}");
                    return new JsonResult("The image saved");
                }
                else
                    return new JsonResult("The image don`t save!");
            }
            catch (Exception)
            {
                return new JsonResult("");
            }
        }

        

    }
}
