using ContactsDatabase.Domain.Entities;
using ContactsDatabase.Infrastructure.Identity;
using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace ContactsDatabase.Infrastructure.Persistence;

public class ApplicationDbContext : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions options, IOptions<OperationalStoreOptions> operationalStoreOptions) :
        base(options, operationalStoreOptions)
    {
    }

    public DbSet<Contact> Contacts { get; }
    public DbSet<ContactPhone> ContactPhones { get; }
    public DbSet<ContactList> ContactLists { get; }
    public DbSet<List> Lists { get; }
}