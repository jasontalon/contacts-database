using ContactsDatabase.Application.Common;
using MediatR;

namespace ContactsDatabase.Application.Interfaces;

public interface IPagedRequest<T> : IRequest<PagedResponse<T>>, IPageQuery
    where T : class
{
}