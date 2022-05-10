using ContactsDatabase.Infrastructure.Identity;
using ContactsDatabase.Infrastructure.Persistence;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ContactsDatabase.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection serviceCollection,
        IConfiguration configuration)
    {
        serviceCollection.AddDbContext<ApplicationDbContext>(options =>
        {
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection"),
                builder => { builder.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName); });
        });
        
        serviceCollection.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
            .AddEntityFrameworkStores<ApplicationDbContext>();

        serviceCollection.AddIdentityServer()
            .AddApiAuthorization<ApplicationUser, ApplicationDbContext>();

        serviceCollection.AddAuthentication()
            .AddIdentityServerJwt();
        
        return serviceCollection;
    }
    
    public static void LoadDotEnv(this ConfigurationManager configuration)
    {
        var path = Path.Combine(".env");

        for (var level = 0; level <= 3 && !File.Exists(path); level++)
            path = Path.Combine("../", path);

        if (!File.Exists(path))
            return;
        
        var variables = File.ReadAllLines(path)
            .Where(p => !string.IsNullOrWhiteSpace(p))
            .Where(p => p.Contains("="))
            .Where(p => !p.StartsWith("/") || !p.StartsWith("#")).ToList();

        var environmentVariables = variables.ToDictionary(
            variable => variable.Substring(0, variable.IndexOf("=", StringComparison.Ordinal))
            , variable =>
            {
                var value = variable.Remove(0, variable.IndexOf("=", StringComparison.Ordinal) + 1);
                if (value.StartsWith("\"") && value.EndsWith("\""))
                    return value.Remove(0, 1)
                        .Remove(value.LastIndexOf("\"", StringComparison.Ordinal) - 1,
                            1); //.Substring(value.LastIndexOf("\""));
                return value;
            });

        foreach (var (key, value) in environmentVariables)
            Environment.SetEnvironmentVariable(key, value);
        
        configuration.AddEnvironmentVariables();
    }
}