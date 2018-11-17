using System.Data.Entity;

namespace MyProject.Models
{
    public class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}
