using App.Services;
using DateTimeCheck.Data.Connectors;
using DateTimeCheck.Data.Context;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Npgsql;

var hostBuilder = Host.CreateApplicationBuilder();

hostBuilder
    .Services
    .AddScoped<IThingService, ThingService>()
    .AddDbContext<DataDbContext>(builder =>
    {
        var config = hostBuilder.Configuration.GetSection("DataSource");
        var connectionStringBuilder = new NpgsqlConnectionStringBuilder();
        config.Bind(connectionStringBuilder);
        builder.ConnectWithBuilder(connectionStringBuilder);
    });

using var host = hostBuilder.Build();

host.Start();
var service = host.Services.GetRequiredService<IThingService>();

var writer = new StringWriter();

// Insert
var thing = await service.CreateAsync();
writer.WriteLine($"Insert Thing: {thing}");

// Update
thing.When = DateTime.UtcNow;
writer.WriteLine($"Update Thing: {thing}");
await service.UpdateAsync(thing);

// Re-query
var verify = await service.GetById(thing.Id);
writer.WriteLine($"Verify Thing: {verify}");

writer.Flush();
Console.Write(writer.ToString());

for (var i = 0; i < 4; ++i)
{
    Console.WriteLine(DateTime.UtcNow.ToString("O"));
}
