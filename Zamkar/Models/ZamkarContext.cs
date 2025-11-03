using Microsoft.EntityFrameworkCore;

namespace Zamkar.Models;

public class ZamkarContext : DbContext
{
    public DbSet<User> Users { get; set; }
    public DbSet<Company> Companies { get; set; }

    public ZamkarContext(DbContextOptions<ZamkarContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}