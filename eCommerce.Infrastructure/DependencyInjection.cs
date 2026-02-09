using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using eCommerce.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.infrastructure;
public static class DependencyInjection
{
    /// <summary>
    /// Adds infrastructure-related services to the specified service collection for dependency 
    /// injection.
    /// Extension method to add infrastructure services such as repositories, database contexts, and
    /// other related services to the dependency injection container
    /// </summary>
    /// <remarks>This method registers repository implementations for products, orders, and 
    /// customers with
    /// scoped lifetimes. Call this method during application startup to ensure required 
    /// infrastructure services are
    /// available for dependency injection.</remarks>
    /// <param name="services">The service collection to which infrastructure services will be added. Cannot be null.</param>
    public static IServiceCollection AddInfrastructure(this IServiceCollection services)
    {
        // TO DO: Add Services to the IoC container, such as repositories, database contexts, etc.
        // infrastructure services often include data access, caching, and other low-level components.
        services.AddTransient<IUsersRepository, UsersRepository>();
        services.AddTransient<DapperDbContext>(); //22: Added DapperDbContext to the service collection for dependency injection. This allows the application to use Dapper for database operations, providing a lightweight and efficient way to interact with the database. By registering DapperDbContext, we can inject it into repositories or services that require database access, enabling seamless integration of Dapper into the application's data access layer.
        return services;
    }
}

