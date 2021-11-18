using Microsoft.EntityFrameworkCore;
using Movie.DataAccess.Entity;
using System.Reflection;

namespace Movie.DataAccess;
public class AppDBContext : DbContext
{
    public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }
    public DbSet<WatchList> WatchLists { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
