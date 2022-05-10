using Duende.IdentityServer.EntityFramework.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Options;

namespace ContactsDatabase.Infrastructure.Persistence;

public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public ApplicationDbContext CreateDbContext(string[] args)
    {
        var connectionString = args.FirstOrDefault();

        if (string.IsNullOrEmpty(connectionString)) throw new ArgumentNullException();

        var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
        builder.UseNpgsql(connectionString);

        return new ApplicationDbContext(builder.Options, new OperationalStoreOptionsMigrations());
    }
}

public class OperationalStoreOptionsMigrations :
    IOptions<OperationalStoreOptions>
{
    public OperationalStoreOptions Value => new OperationalStoreOptions()
    {
        DeviceFlowCodes = new TableConfiguration("DeviceCodes"),
        EnableTokenCleanup = false,
        PersistedGrants = new TableConfiguration("PersistedGrants"),
        TokenCleanupBatchSize = 100,
        TokenCleanupInterval = 3600,
    };
}