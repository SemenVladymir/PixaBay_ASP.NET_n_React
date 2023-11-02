using Microsoft.EntityFrameworkCore;
using Pixabay.DAL.EF;
using Pixabay.DAL.Entities;
using Pixabay.DAL.Interfaces;

namespace Pixabay.DAL.Repositories
{
    public class ImageRepository : IRepository<MyImage>
    {
        private ImageContext db;

        public ImageRepository(ImageContext context)
        {
            this.db = context;
        }

        public IEnumerable<MyImage> GetAll()
        {
            return db.Images;
        }

        public MyImage Get(int id)
        {
            return db.Images.Find(id);
        }

        public void Create(MyImage item)
        {
            db.Images.Add(item);
        }

        public void Update(MyImage item)
        {
            db.Entry(item).State = EntityState.Modified;
        }

        public IEnumerable<MyImage> Find(Func<MyImage, Boolean> predicate)
        {
            return db.Images.Where(predicate).ToList();
        }

        public void Delete(int id)
        {
            MyImage book = db.Images.Find(id);
            if (book != null)
                db.Images.Remove(book);
        }
    }
}
