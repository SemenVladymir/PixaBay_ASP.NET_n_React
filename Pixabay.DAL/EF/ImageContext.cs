using Microsoft.EntityFrameworkCore;
using Pixabay.DAL.Entities;


namespace Pixabay.DAL.EF
{
    public class ImageContext : DbContext
    {
        public DbSet<MyImage> Images { get; set; }

        public ImageContext(DbContextOptions<ImageContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-MV43C0T;Database=PhonesBase;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }
}
