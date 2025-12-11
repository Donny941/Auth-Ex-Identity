using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Auth_Ex_Identity.Models.Entity
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public DbSet<AppUser> AspNetUsers { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

    }
}
