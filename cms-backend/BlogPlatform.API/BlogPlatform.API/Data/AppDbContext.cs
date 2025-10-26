using BlogPlatform.API.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.API.Data
{
    // AppDbContext MUST inherit from DbContext to connect to the database.
    public class AppDbContext : DbContext
    {
        // Constructor: Receives configuration (like connection string) via Dependency Injection (DI).
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // DbSet properties: These represent the tables in your SQL database.
        // EF Core will create tables named 'Posts' and 'Categories' based on your models.
        public DbSet<Post>Posts { get; set; }
        public DbSet<Category> Categories { get; set; }
    }
}

