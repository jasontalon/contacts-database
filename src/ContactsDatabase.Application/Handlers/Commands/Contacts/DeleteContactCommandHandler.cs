using AutoMapper;
using ContactsDatabase.Application.Interfaces;
using MediatR;

namespace ContactsDatabase.Application.Handlers.Commands;

public class DeleteContactCommandHandler : RequestHandlerBase<DeleteContactCommand>
{
    public DeleteContactCommandHandler(IApplicationDbContext connectDataContext, IMapper mapper,
        IUserContext userContext) : base(connectDataContext, mapper, userContext)
    {
    }

    public override async Task<Unit> Handle(DeleteContactCommand request, CancellationToken cancellationToken)
    {
        var contactCtx = await applicationDbContext.Contacts.FindAsync(request.Id);

        if (contactCtx is null) return Unit.Value;

        applicationDbContext.Contacts.Remove(contactCtx);

        await applicationDbContext.SaveChangesAsync(cancellationToken);
        
        return Unit.Value;
    }
}

public class DeleteContactCommand : IRequest
{
    public Guid Id { get; set; }
}