using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Pixabay.DAL.Entities;

namespace Pixabay.DAL.EF
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<MyImage> Images { get; set; }
        public AuthContext(DbContextOptions<AuthContext> options)
            : base(options)
        {}

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
