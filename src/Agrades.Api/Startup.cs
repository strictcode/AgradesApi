using Agrades.Api.Mapper;
using Agrades.Api.Settings;
using Agrades.Data;
using Agrades.Services;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption.ConfigurationModel;
using Microsoft.AspNetCore.DataProtection.AuthenticatedEncryption;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using NodaTime;
using Serilog;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using Agrades.Data.Entities.Identity;

namespace Agrades.Api;
public class Startup
{
    private static readonly Regex ANGULAR_BUNDLE_RX = new(".*\\.[0-9a-f]{20}\\..*", RegexOptions.Compiled);
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

        // Identity registration
        services
            .AddIdentityCore<User>(options =>
            {
                options.SignIn.RequireConfirmedEmail = true;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
            //.AddClaimsPrincipalFactory<UserPrincipalClaimFactory>()
            .AddEntityFrameworkStores<AppDbContext>()
            //.AddSignInManager()
            //.AddDefaultTokenProviders()
            ;

        {
            var dpBuilder = services
                .AddDataProtection()
                .PersistKeysToFileSystem(new DirectoryInfo("runtime_data/keys"))
                .UseCryptographicAlgorithms(new AuthenticatedEncryptorConfiguration()
                {
                    EncryptionAlgorithm = EncryptionAlgorithm.AES_256_CBC,
                    ValidationAlgorithm = ValidationAlgorithm.HMACSHA256
                });
            if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                dpBuilder
                    .ProtectKeysWithDpapi();
            }
        }

        // HttpContextAccessor
        services.AddHttpContextAccessor();

        ConfigureDIContainer(services);

        // Configuration AppSettings classes
        ConfigureOptions(services);

        services
           .AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
           .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, (options) =>
           {
               options.Cookie.Name = CookieAuthenticationDefaults.AuthenticationScheme;
               options.Cookie.SameSite = Microsoft.AspNetCore.Http.SameSiteMode.Strict;
               options.Cookie.HttpOnly = true;
               options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
               options.Events = new CookieAuthenticationEvents
               {
                   OnRedirectToLogin = redirectContext =>
                   {
                       redirectContext.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                       return Task.CompletedTask;
                   },
                   OnRedirectToAccessDenied = redirectContext =>
                   {
                       redirectContext.HttpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                       return Task.CompletedTask;
                   },
               };
           });

        services
            .AddAuthorization(config =>
            {
                /*
                config.AddPolicy(Policies.SUPERADMIN, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.RequireClaim(Claims.SUPERUSER);
                });
                config.AddPolicy(Policies.COMPANY_ADMIN, policy =>
                {
                    policy.RequireAuthenticatedUser();
                    policy.AddRequirements(new CompanyAdminRequirement());
                });*/
            });

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

        services.AddApiVersioning(config =>
        {
            config.DefaultApiVersion = new ApiVersion(1, 0);
            config.AssumeDefaultVersionWhenUnspecified = true;
            config.ReportApiVersions = true;
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

        app.UseSerilogRequestLogging();

        app.UseForwardedHeaders();

        app.UseRouting();

        app.UseCors(CorsPolicy);

        app.UseSpaStaticFiles(new StaticFileOptions
        {
            // used for static assets:
            // - js bundles which have their rev-based invalidation in index.html
            // - other assets (icons, images) which should be immutable
            OnPrepareResponse = ctx =>
            {
                var headers = ctx.Context.Response.GetTypedHeaders();
                CacheControlHeaderValue cchv;
                if (ANGULAR_BUNDLE_RX.IsMatch(ctx.File.Name))
                {
                    // angular ma build-in cache busting, cache expiraci nepotrebujeme vubec
                    cchv = new CacheControlHeaderValue
                    {
                        NoCache = false,
                        NoStore = false,
                        MustRevalidate = false,
                        MaxAge = TimeSpan.FromDays(365),
                    };
                }
                else if (ctx.File.Name == "index.html")
                {
                    // normalne index.html poskytuje SPA middleware, tohle je fallback pokud si nekdo rekne primo o ten soubor
                    cchv = new CacheControlHeaderValue
                    {
                        NoCache = true,
                        NoStore = false,
                        MustRevalidate = true,
                    };
                }
                else if (ctx.File.Name.EndsWith(".json"))
                {
                    // json se meni pri release (preklady, i18n/cs.json), a angular ho neumi verzovat.
                    // Je potreba aby si front obcas kontroloval jestli jeste plati (mel by zajistit etag
                    // mechanismus)
                    cchv = new CacheControlHeaderValue
                    {
                        NoCache = false,
                        NoStore = false,
                        MustRevalidate = true,
                        MaxAge = TimeSpan.FromMinutes(30),
                    };
                }
                else
                {
                    // ostatni assety - png, svg, ico. Nemaji duvod se menit ani pri release, maximalne se prida
                    // novy obrazek.
                    cchv = new CacheControlHeaderValue
                    {
                        NoCache = false,
                        NoStore = false,
                        MustRevalidate = false,
                        MaxAge = TimeSpan.FromDays(1),
                    };
                    cchv.Extensions.Add(new("immutable"));
                }
                headers.CacheControl = cchv;
            }
        });
        app.UseSpa(configuration =>
        {
            // only used for main page, i.e. index.html
            configuration.Options.SourcePath = "ClientApp/dist";
            configuration.Options.DefaultPage = "/index.html";
            configuration.Options.DefaultPageStaticFileOptions = new StaticFileOptions
            {
                OnPrepareResponse = ctx =>
                {
                    var headers = ctx.Context.Response.GetTypedHeaders();
                    if (headers.ContentType == null)
                    {
                        headers.ContentType = new MediaTypeHeaderValue("text/html");
                    }
                    headers.ContentType.Charset = "UTF-8";
                    headers.CacheControl = new CacheControlHeaderValue
                    {
                        NoCache = true,
                        NoStore = false,
                        MustRevalidate = true,
                    };
                }
            };
        });

        app.UseAuthentication();
        app.UseAuthorization();
        app.UseStaticFiles();

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
