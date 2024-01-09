using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace DateTimeCheck.Data.Connectors;

public static class PostgreSqlConnector
{
    public static DbContextOptionsBuilder ConnectWithBuilder(this DbContextOptionsBuilder builder,
        NpgsqlConnectionStringBuilder connectionStringBuilder)
    {
        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connectionStringBuilder.ConnectionString);
        return builder.UseNpgsql(dataSourceBuilder.Build());
    }
}