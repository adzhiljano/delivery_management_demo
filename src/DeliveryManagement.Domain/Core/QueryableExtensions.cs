using System.Linq;

namespace DeliveryManagement.Domain.Core
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> WithOffsetAndLimit<T>(this IQueryable<T> query, int? offset, int? limit)
        {
            if (offset.HasValue && offset.Value > 0)
            {
                query = query.Skip(offset.Value);
            }

            if (limit.HasValue)
            {
                query = query.Take(limit.Value);
            }

            return query;
        }
    }
}
