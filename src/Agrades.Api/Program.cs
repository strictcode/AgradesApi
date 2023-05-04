using Agrades.Data;
using Agrades.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using Serilog;
using Serilog.AspNetCore;
using NodaTime;
using System.Diagnostics;
using System;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.Extensions.Options;

namespace Agrades.Api;
public class Program
{
    private static string ContentRootPath = Directory.GetCurrentDirectory();

    public static async Task Main(string[] args)
    {
        var builder = CreateHostBuilder(args);
        var configuration = new ConfigurationBuilder().
            SetBasePath(Directory.GetCurrentDirectory()).
            AddJsonFile("appsettings.json").
            Build();

        Log.Logger = new LoggerConfiguration().
            ReadFrom.Configuration(configuration).
            CreateLogger().ForContext<Program>();

        AppDomain.CurrentDomain.FirstChanceException += (sender, eventArgs) =>
        {
            Log.Logger.Fatal(eventArgs.Exception.ToString());
        };

        try
        {
            builder.UseSerilog(Log.Logger);

            var host = builder.Build();

            await MigrateDb(host);
            await host.RunAsync();
        }
        catch (Exception exception)
        {
            // serilog: catch setup errors
            throw;
        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            Log.CloseAndFlush();
        }
    }

    private static async Task MigrateDb(IHost host)
    {
        using var scope = host.Services.CreateScope();

        var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();
        var clock = scope.ServiceProvider.GetRequiredService<IClock>();
        await dbContext.Database.MigrateAsync();

        await ITGSeed.SeedAsync(clock, dbContext);
    }

    public static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostBuilderContext, configurationBuilder) =>
            {
                for (int pos = configurationBuilder.Sources.Count - 1; pos >= 0; --pos)
                {
                    ContentRootPath = hostBuilderContext.HostingEnvironment.ContentRootPath;
                    if (configurationBuilder.Sources[pos] is JsonConfigurationSource)
                    {
                        var source = new JsonConfigurationSource()
                        {
                            Path = Path.Join(ContentRootPath, "appsettings.local.json"),
                            Optional = true,
                            ReloadOnChange = true,
                        };
                        source.ResolveFileProvider();
                        configurationBuilder.Sources.Insert(pos + 1, source);
                    }
                }
            })
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            });
    }
}
