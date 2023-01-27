using Agrades.Api.Settings;
using Microsoft.Extensions.Options;
using NodaTime;

namespace Agrades.Api.Mapper;
public interface IAppMapper
{
    DateTimeZone ServerTimeZone { get; }
    Instant Now { get; }
}

public class AppMapper : IAppMapper
{
    private readonly EnvironmentSettings environmentOptions;
    private readonly IClock clock;

    public DateTimeZone ServerTimeZone => environmentOptions.ServerTimeZone;

    public Instant Now => clock.GetCurrentInstant();

    public AppMapper(
        IOptionsSnapshot<EnvironmentSettings> environmentOptions,
        IClock clock
        )
    {
        this.environmentOptions = environmentOptions.Value;
        this.clock = clock;
    }
}
