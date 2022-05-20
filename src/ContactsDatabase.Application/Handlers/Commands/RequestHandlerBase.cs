using AutoMapper;
using ContactsDatabase.Application.Interfaces;
using MediatR;

namespace ContactsDatabase.Application.Handlers;

public abstract class RequestHandlerBase<TRequest, TResponse> : IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    protected readonly IApplicationDbContext applicationDbContext;
    protected readonly IMapper Mapper;
    protected readonly IUserContext UserContext;

    protected RequestHandlerBase(IApplicationDbContext connectDataContext, IMapper mapper, IUserContext userContext)
    {
        applicationDbContext = connectDataContext;
        Mapper = mapper;
        UserContext = userContext;
    }

    public abstract Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken);
}

public abstract class RequestHandlerBase<TRequest> : IRequestHandler<TRequest>
    where TRequest : IRequest
{
    protected readonly IApplicationDbContext applicationDbContext;
    protected readonly IMapper Mapper;
    protected readonly IUserContext UserContext;

    protected RequestHandlerBase(IApplicationDbContext connectDataContext, IMapper mapper, IUserContext userContext)
    {
        applicationDbContext = connectDataContext;
        Mapper = mapper;
        UserContext = userContext;
    }

    public abstract Task<Unit> Handle(TRequest request, CancellationToken cancellationToken);
}