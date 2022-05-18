using System.Security.Claims;
using ContactsDatabase.Application.Interfaces;

namespace ContactsDatabase.Infrastructure.Security;

public class UserContext : IUserContext
{
    public string Id { get; set; }
    public string Email { get; set; }
    public List<string> Roles { get; set; }

    public void SetUser(IEnumerable<Claim> claims)
    {
        Email = claims.FirstOrDefault(p => p.Type == ClaimTypes.Email)?.Value;
        Roles = claims.Where(p => p.Type == ClaimTypes.Role).Select(p => p.Value).ToList();
        Id = claims.FirstOrDefault(p => p.Type == ClaimTypes.NameIdentifier)?.Value;

        var individualIdClaim = claims.FirstOrDefault(p => p.Type == "individualId");
    }
}