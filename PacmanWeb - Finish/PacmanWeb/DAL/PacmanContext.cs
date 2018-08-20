using Microsoft.EntityFrameworkCore;
using PacmanWeb.Models;

namespace PacmanWeb
{
    public class PacmanContext : DbContext 
    {
        public PacmanContext(DbContextOptions<PacmanContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
