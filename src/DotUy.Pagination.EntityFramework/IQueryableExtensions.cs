using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace DotUy.Pagination.Extensions
{
    public static class IQueryableExtensions
    {
        public async static Task<Page<T>> ToPagedItemsAsync<T>(this IQueryable<T> source, int pageSize, int pageNumber = 1)
        {
            var count = await source.CountAsync().ConfigureAwait(false);
            var collection = await source
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToArrayAsync().ConfigureAwait(false);

            return new Page<T>(collection, count, pageSize, pageNumber);
        }
    }
}