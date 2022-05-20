using ContactsDatabase.Application.Interfaces;

namespace ContactsDatabase.Application.Common;


public abstract class PagedRequestBase<T> : IPagedRequest<T> where T : class
{
    public string SearchTerm { get; set; }
    public int Page { get; set; } = 1;
    public int PageSize { get; set; } = 20;
}
public abstract class PagedResponse<T> : IPagedResponse<T>
{
    public int Page { get; set; }
    public int PageSize { get; set; }
    public List<T> Results { get; set; }
    public int TotalCount { get; set; }
}
