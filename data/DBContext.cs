
using Microsoft.EntityFrameworkCore;
using WebApi.Entities;

namespace WebApi.data
{
    public class ADBContext : DbContext
    {
        public ADBContext(DbContextOptions<ADBContext> options) : base(options) { 
        
        }
        public DbSet<User> Users { get; set; }
        public DbSet<BlogPost> BlogPosts { get; set; }
    }
   
}
