using NodaTime;

namespace Agrades.Api.Settings;
public class EnvironmentSettings
{
    public string Host { get; set; } = string.Empty;

    public string ServerTimezoneTzdb { get; set; } = string.Empty;

    public DateTimeZone ServerTimeZone => DateTimeZoneProviders.Tzdb[ServerTimezoneTzdb];
}
