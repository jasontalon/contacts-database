using AutoMapper;
using ContactsDatabase.Application.Interfaces;
using MediatR;

namespace ContactsDatabase.Application.Handlers.Commands.Contact;

public class CreateContactCommandHandler : BaseCommandHandler<CreateContactCommand, Guid>
{
    public CreateContactCommandHandler(IApplicationDbContext connectDataContext, IMapper mapper,
        IUserContext userContext) : base(connectDataContext, mapper, userContext)
    {
    }

    public override async Task<Guid> Handle(CreateContactCommand request, CancellationToken cancellationToken)
    {
        var contact = Mapper.Map<CreateContactCommand, Domain.Entities.Contact>(request);

        applicationDbContext.Contacts.Add(contact);

        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return contact.Id;
    }
}

public class CreateContactCommand : IRequest<Guid>
{
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

public class CreateContactCommandProfile : Profile
{
    public CreateContactCommandProfile() => CreateMap<CreateContactCommand, Domain.Entities.Contact>();
}