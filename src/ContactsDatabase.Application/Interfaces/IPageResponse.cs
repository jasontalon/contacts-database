namespace ContactsDatabase.Application.Interfaces;

public interface IPagedResponse
{
    int Page { get; set; }
    int PageSize { get; set; }
    int TotalCount { get; set; }
}

public interface IPagedResponse<T> : IPagedResponse
{
    List<T> Results { get; set; }
}