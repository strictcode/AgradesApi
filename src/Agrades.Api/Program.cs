using Agrades.Data;
using Agrades.Data.Seeds;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration.Json;
using NLog;
using NLog.Config;
using NLog.Web;
using NodaTime;
using System.Diagnostics;

namespace Agrades.Api;
public class Program
{
    private static string ContentRootPath = Directory.GetCurrentDirectory();

    public static async Task Main(string[] args)
    {
        var builder = CreateHostBuilder(args);

        try
        {
            var host = builder.Build();

            await MigrateDb(host);
            await host.RunAsync();
        }
        catch (Exception exception)
        {
            var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
            // NLog: catch setup errors
            logger.Error(exception, "Stopped program because of exception");
            throw;

        }
        finally
        {
            // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
            LogManager.Shutdown();
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
        // CreateHostBuilder is run by EF tooling, while Main() is not. Putting layoutrenderer initialization
        // here avoids error in internal-nlog.txt when running add-migration or related tools.
        NLog.LayoutRenderers.LayoutRenderer.Register("basedir", x => ContentRootPath);
        NLog.LayoutRenderers.LayoutRenderer.Register("filteredStackTrace", x =>
            "\r\n" + String.Join(String.Empty, new StackTrace(true).GetFrames().Where(frame => frame.HasSource()).Skip(1))
        );
        if (File.Exists("./nlog.config"))
        {
            // nlog scanning doesn't try to use current directory (see
            // https://github.com/NLog/NLog/wiki/Configuration-file#configuration-file-locations). Default should be
            // to use published nlog.config without any changes, but it makes sense to allow local config in
            // exceptional situations.
            NLog.LogManager.Configuration = new XmlLoggingConfiguration("nlog.config");
        }

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
            })
            .UseNLog(new NLogAspNetCoreOptions
            {
                // respect minimal levels for categoreis specified in appsettings
                RemoveLoggerFactoryFilter = false,
            });
    }
}
