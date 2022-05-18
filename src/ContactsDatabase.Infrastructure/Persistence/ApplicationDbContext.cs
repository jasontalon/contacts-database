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
    //public DbSet<ContactPhone> ContactPhones { get; }
    //public DbSet<ContactList> ContactLists { get; }
    //public DbSet<List> Lists { get; }
    //public DbSet<Phone> Phones { get; set; }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.HasPostgresExtension("uuid-ossp");

        base.OnModelCreating(builder);

        builder.Entity<Contact>(entity =>
        {
            entity.Property(p => p.Firstname).HasMaxLength(64);
            entity.Property(p => p.Surname).HasMaxLength(64);
            entity.Property(p => p.Middlename).HasMaxLength(64);
            entity.Property(p => p.Email).HasMaxLength(64);
            entity.Property(p => p.Address1).HasMaxLength(128);
            entity.Property(p => p.Address2).HasMaxLength(128);
            entity.Property(p => p.City).HasMaxLength(64);
            entity.Property(p => p.State).HasMaxLength(64);
            entity.Property(p => p.Zip).HasMaxLength(32);
            entity.Property(p => p.Country).HasMaxLength(64);
            entity.Property(p => p.Notes).HasMaxLength(256);
            entity.Property(p => p.Website).HasMaxLength(256);
        });
        
        //builder.Entity<ContactList>().HasKey(p => new { p.ContactId, p.ListId });

        //builder.Entity<ContactPhone>().HasKey(p => new { p.ContactId, p.PhoneId });
    }
}