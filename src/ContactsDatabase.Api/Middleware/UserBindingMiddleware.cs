using ContactsDatabase.Application.Interfaces;

namespace ContactsDatabase.Api.Middleware;

public interface ICustomMiddleware
{
    Task Invoke(HttpContext httpContext, IUserContext userContext);
}
public class UserBindingMiddleware : ICustomMiddleware
{
    private readonly RequestDelegate next;

    public UserBindingMiddleware(RequestDelegate next)
    {
        this.next = next;
    }
    public async Task Invoke(HttpContext httpContext, IUserContext userContext)
    {
        //userContext
        userContext.SetUser(httpContext.User.Claims);
        await next(httpContext);
    }
}