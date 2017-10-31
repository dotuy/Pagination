using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DotUy.Pagination.Extensions
{
    public static class IQueryableExtensions
    {
        public async static Task<Page<T>> ToPagedItemsAsync<T>(
            this IQueryable<T> source, 
            int pageSize, 
            int pageNumber = 1, 
            CancellationToken cancellationToken = default(CancellationToken))
        {
            var count = await source.CountAsync(cancellationToken).ConfigureAwait(false);
            var collection = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync(cancellationToken).ConfigureAwait(false);

            return new Page<T>(collection, count, pageSize, pageNumber);
        }
    }
}