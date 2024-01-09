using DateTimeCheck.Data.Model;
using Microsoft.EntityFrameworkCore;

namespace DateTimeCheck.Data.Context;

public class DataDbContext : DbContext
{
    public DbSet<Thing> Things => Set<Thing>();

    public DataDbContext(DbContextOptions<DataDbContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataDbContext).Assembly);
    }
}