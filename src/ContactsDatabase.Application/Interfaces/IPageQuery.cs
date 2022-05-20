namespace ContactsDatabase.Application.Interfaces;

public interface IPageQuery
{
    string SearchTerm { get; set; }
    int Page { get; set; }
    int PageSize { get; set; }
}