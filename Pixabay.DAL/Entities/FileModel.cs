using System.Globalization;

namespace Pixabay.DAL.Entities
{

    public class FileModel
    {
        public string FileName { get; set; }
        public IFormFile FormFile { get; set;}
    }
}
