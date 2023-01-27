using Newtonsoft.Json;

namespace Agrades.Api.Utilities;

public interface IApiListResult<T>
    where T : class
{
    public IEnumerable<T> List { get; }
}

public static class ApiListResult
{
    public static ApiListResult<T> From<T>(IEnumerable<T> list)
        where T : class
        => new(list);
}

public class ApiListResult<T>
    where T : class
{
    [JsonProperty("list")]
    public IEnumerable<T> List { get; }

    public ApiListResult(IEnumerable<T> list)
    {
        List = list;
    }
}
