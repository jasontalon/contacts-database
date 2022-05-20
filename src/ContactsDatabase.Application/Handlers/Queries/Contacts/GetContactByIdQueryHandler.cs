using AutoMapper;
using AutoMapper.QueryableExtensions;
using ContactsDatabase.Application.Interfaces;
using ContactsDatabase.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ContactsDatabase.Application.Handlers.Queries.Contacts;

public class GetContactByIdQueryHandler : RequestHandlerBase<GetContactByIdQuery, GetContactByIdQueryResponse>
{
    public GetContactByIdQueryHandler(IApplicationDbContext connectDataContext, IMapper mapper,
        IUserContext userContext) : base(connectDataContext, mapper, userContext)
    {
    }

    public override async Task<GetContactByIdQueryResponse> Handle(GetContactByIdQuery request,
        CancellationToken cancellationToken)
    {
        var contact = await applicationDbContext.Contacts
            .AsNoTracking()
            .ProjectTo<GetContactByIdQueryResponse>(Mapper.ConfigurationProvider)
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken: cancellationToken);

        return contact;
    }
}

public class GetContactByIdQuery : IRequest<GetContactByIdQueryResponse>
{
    public Guid Id { get; set; }
}

[AutoMap(typeof(Contact))]
public class GetContactByIdQueryResponse
{
    public Guid Id { get; set; }
    public string? Firstname { get; set; }
    public string? Surname { get; set; }
    public string? Middlename { get; set; }
    public string? Email { get; set; }
    public string? Address1 { get; set; }
    public string? Address2 { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? Zip { get; set; }
    public string? Country { get; set; }
    public string? Notes { get; set; }
    public string? Website { get; set; }
}