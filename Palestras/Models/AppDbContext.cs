using Microsoft.EntityFrameworkCore;

namespace Lecture.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :
            base(options)
        {

        }
        public DbSet<Speakers> Speakers { get; set; }
    }
}
