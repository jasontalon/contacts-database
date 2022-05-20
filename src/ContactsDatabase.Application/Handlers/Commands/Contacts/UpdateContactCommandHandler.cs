using AutoMapper;
using ContactsDatabase.Application.Interfaces;
using ContactsDatabase.Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.EntityFrameworkCore;

namespace ContactsDatabase.Application.Handlers.Commands;

public class UpdateContactCommandHandler : RequestHandlerBase<UpdateContactCommand>
{
    public UpdateContactCommandHandler(IApplicationDbContext connectDataContext, IMapper mapper,
        IUserContext userContext) : base(connectDataContext, mapper, userContext)
    {
    }

    public override async Task<Unit> Handle(UpdateContactCommand request, CancellationToken cancellationToken)
    {
        var contactCtx = await applicationDbContext
            .Contacts
            .FirstOrDefaultAsync(p => p.Id == request.Id, cancellationToken);

        //map the ctx to dto
        var contactDto = Mapper.Map<UpdateContactDto>(contactCtx);

        //apply the patches to the dto
        request.Patch.ApplyTo(contactDto);

        //then map the dto back to ctx  
        Mapper.Map(contactDto, contactCtx);
        
        await applicationDbContext.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}

public class UpdateContactCommand : IRequest
{
    public Guid Id { get; set; }
    public JsonPatchDocument<UpdateContactDto> Patch { get; set; }
}

public class UpdateContactDto
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

public class UpdateContactCommandHandlerProfile : Profile
{
    public UpdateContactCommandHandlerProfile()
    {
        CreateMap<Contact, UpdateContactDto>()
            .ReverseMap();
        CreateMap<JsonPatchDocument<UpdateContactDto>, JsonPatchDocument<Contact>>();
        CreateMap<Operation<UpdateContactDto>, Operation<Contact>>();
    }
}