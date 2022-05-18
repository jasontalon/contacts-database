using AutoMapper;
using ContactsDatabase.Application.Interfaces;
using MediatR;

namespace ContactsDatabase.Application.Handlers;

public abstract class BaseCommandHandler<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected readonly IApplicationDbContext applicationDbContext;
    protected readonly IMapper Mapper;
    protected readonly IUserContext UserContext;

    protected BaseCommandHandler(IApplicationDbContext connectDataContext, IMapper mapper, IUserContext userContext)
    {
        applicationDbContext = connectDataContext;
        Mapper = mapper;
        UserContext = userContext;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}