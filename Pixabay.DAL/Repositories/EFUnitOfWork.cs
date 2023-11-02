using Microsoft.EntityFrameworkCore;
using Pixabay.DAL.EF;
using Pixabay.DAL.Entities;
using Pixabay.DAL.Interfaces;

namespace Pixabay.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private ImageContext db;
        private ImageRepository imageRepository;


        public EFUnitOfWork(DbContextOptions<ImageContext> connectionString)
        {
            db = new ImageContext(connectionString);
        }
        public IRepository<MyImage> Images
        {
            get
            {
                if (imageRepository == null)
                    imageRepository = new ImageRepository(db);
                return imageRepository;
            }
        }


        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
