using KeyServer.Models;
using Microsoft.EntityFrameworkCore;

namespace KeyServer;

public class ApplicationDbContext:DbContext
{
    public DbSet<Key> Keys { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
        Database.EnsureCreated();
    }
}