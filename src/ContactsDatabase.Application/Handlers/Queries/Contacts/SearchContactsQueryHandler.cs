using AutoMapper;
using ContactsDatabase.Application.Common;
using ContactsDatabase.Application.Interfaces;

namespace ContactsDatabase.Application.Handlers.Queries.Contacts;

public class SearchContactsQueryHandler : PagedRequestHandlerBase<SearchContactsQuery, SearchContactsResult>
{
    public SearchContactsQueryHandler(IApplicationDbContext connectDataContext, IMapper mapper,
        IUserContext userContext) : base(connectDataContext, mapper, userContext)
    {
    }

    public override async Task<PagedResponse<SearchContactsResult>> Handle(SearchContactsQuery request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}

public class SearchContactsQuery : PagedRequestBase<SearchContactsResult>
{
    
}

public class SearchContactsResult
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? Email { get; set; }
    public string? Address { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
}

public class SearchContactsQueryHandlerProfile : Profile
{
    public SearchContactsQueryHandlerProfile()
    {
    }
}