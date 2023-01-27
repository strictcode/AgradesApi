using System.Linq.Expressions;

namespace Agrades.Data.Interfaces;
public interface IVersionable
{
    public Instant ValidSince { get; set; }

    public Instant? ValidUntil { get; set; }
}

public static class VersionableExtensions
{
    public static IQueryable<T> FilterByInterval<T>(this IQueryable<T> query, Instant since, Instant? until)
            where T : IVersionable
    {
        return query.Where(x => (since < x.ValidUntil || x.ValidUntil == null) && (x.ValidSince < until || until == null));
    }

    public static IQueryable<T> FilterByInstant<T>(this IQueryable<T> query, Instant when)
    where T : IVersionable
    {
        return query.Where(x => x.ValidSince <= when && (when < x.ValidUntil || x.ValidUntil == null));
    }
}
