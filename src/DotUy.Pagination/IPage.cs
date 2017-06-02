namespace DotUy.Pagination
{
    public interface IPage
    {
        int PageSize { get; }

        int CurrentPage { get; }

        int TotalCount { get; }

        bool HasPreviousPage { get; }

        bool HasNextPage { get; }

        int TotalPages { get; }
    }
}