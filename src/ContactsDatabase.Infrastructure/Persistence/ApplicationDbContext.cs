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
    public DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");
        
        base.OnModelCreating(builder);

        builder.Entity<ContactList>().HasKey(p => new { p.ContactId, p.ListId });
        
        builder.Entity<ContactPhone>().HasKey(p => new { p.ContactId, p.PhoneId });
    }
}