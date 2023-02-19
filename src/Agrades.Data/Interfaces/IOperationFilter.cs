namespace Agrades.Data.Interfaces;
public interface IOperationFilter
{
    public Guid OperationId { get; set; }
}
public static class IOperationFilterExtensions
{
    public static IQueryable<T> FilterByOperation<T>(this IQueryable<T> query, Guid operationId)
        where T : IOperationFilter
        => query.Where(x => x.OperationId == operationId);
}
