using System;
using System.Collections;
using System.Collections.Generic;

namespace DotUy.Pagination
{
    public class Page<T> : IEnumerable<T>, IPage
    {
        private IEnumerable<T> items;

        public Page(IEnumerable<T> items, int totalCount, int pageSize, int pageNumber)
        {
            if (items == null)
            {
                throw new ArgumentNullException(nameof(items));
            }

            if (pageNumber < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(CurrentPage));
            }

            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException(nameof(PageSize));
            }

            this.items = items;
            CurrentPage = pageNumber;
            PageSize = pageSize;
            TotalCount = totalCount;
        }

        public int CurrentPage { get; }

        public int PageSize { get; }

        public int TotalCount { get; }

        public int TotalPages => (int)Math.Ceiling(TotalCount / (double)PageSize);

        public bool HasPreviousPage => CurrentPage > 1;

        public bool HasNextPage => CurrentPage < TotalPages;

        public IEnumerator<T> GetEnumerator() => items.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}