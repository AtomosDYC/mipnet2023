using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mipBackend.Models;

namespace mipBackend.Data
{
    public class AppDbContext: IdentityDbContext<Usuario>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Inmueble>? Inmuebles { get; set; }
    }
}
