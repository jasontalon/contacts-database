using System.Security.Claims;

namespace ContactsDatabase.Application.Interfaces;

public interface IUserContext
{
    void SetUser(IEnumerable<Claim> claims);
    public string Email { get; set; }
    public string Id { get; set; }
    public List<string> Roles { get; set; }
}