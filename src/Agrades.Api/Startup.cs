using Agrades.Api.Mapper;
using Agrades.Api.Settings;
using Agrades.Data;
using Agrades.Services;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using System.Reflection;

namespace Agrades.Api;
public class Startup
{
    private const string CorsPolicy = "_corsPolicy";

    private readonly IConfiguration _configuration;
    private readonly IWebHostEnvironment _environment;

    public Startup(IConfiguration configuration, IWebHostEnvironment environment)
    {
        _configuration = configuration;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            var connectionString = _configuration.GetConnectionString("DefaultConnection");
            options.UseNpgsql(connectionString!, builder =>
            {
                builder.UseNodaTime();
            });
        });

        ConfigureDIContainer(services);

        // Configuration AppSettings classes
        ConfigureOptions(services);

        // CORS
        var origins = _configuration.GetSection("CorsOrigins").Get<string[]>() ?? Array.Empty<string>();
        services.AddCors(opt =>
        {
            opt.AddPolicy(CorsPolicy,
            builder =>
            {
                builder.WithOrigins(origins)
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();
            });
        });

        services
            .AddControllersWithViews()
            .AddNewtonsoftJson();
        ;

        services.AddSwaggerGen(config =>
        {
            var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
            config.IncludeXmlComments(xmlPath);
        });
    }

    public void Configure(IApplicationBuilder app)
    {
        if (_environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseForwardedHeaders();

        app.UseRouting();

        app.UseCors(CorsPolicy);

        app.UseAuthorization();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }

    private static void ConfigureDIContainer(IServiceCollection services)
    {

        // Add services to the container.
        services.AddSingleton<IClock>(SystemClock.Instance);

        services.AddScoped<IAppMapper, AppMapper>();
        services.AddScoped<ICurrentOperationService, CurrentOperationService>();
    }

    private void ConfigureOptions(IServiceCollection services)
    {
        services.Configure<EnvironmentSettings>(_configuration.GetSection("EnvironmentSettings"));
    }
}
