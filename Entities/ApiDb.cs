using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace KMF.Entities
{
    public class ApiDb : IdentityDbContext
    {
        public ApiDb(DbContextOptions options) : base(options) { }
        public DbSet<Concerto> Concertos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
