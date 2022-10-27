using BornaCvitanicPortfolioWebapp.Model.Portfolio;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BornaCvitanicPortfolioWebapp.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Post> Posts { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
    }
}