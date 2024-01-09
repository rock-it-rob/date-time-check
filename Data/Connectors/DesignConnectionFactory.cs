using DateTimeCheck.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Npgsql;

namespace DateTimeCheck.Data.Connectors;

// ReSharper disable once UnusedType.Global
public class DesignConnectionFactory : IDesignTimeDbContextFactory<DataDbContext>
{
    public DataDbContext CreateDbContext(string[] args)
    {
        var config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        var connectionStringBuilder = new NpgsqlConnectionStringBuilder();
        config.GetSection("DataSource").Bind(connectionStringBuilder);
        var optionsBuilder = new DbContextOptionsBuilder<DataDbContext>().ConnectWithBuilder(connectionStringBuilder);
        return new DataDbContext((optionsBuilder.Options as DbContextOptions<DataDbContext>)!);
    }
}