using AutoMapper;
using ContactsDatabase.Application.Common;
using ContactsDatabase.Application.Handlers.Queries.Contacts;
using ContactsDatabase.Application.Interfaces;
using MediatR;

namespace ContactsDatabase.Application.Handlers;

public abstract class
    PagedRequestHandlerBase<TRequest, TResponse> : RequestHandlerBase<TRequest, PagedResponse<TResponse>>
    where TRequest : IRequest<PagedResponse<TResponse>>
{
    protected PagedRequestHandlerBase(IApplicationDbContext connectDataContext, IMapper mapper,
        IUserContext userContext) : base(connectDataContext, mapper, userContext)
    {
    }
}

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