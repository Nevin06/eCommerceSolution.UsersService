using eCommerce.Core.Entities.ServiceContracts;
using eCommerce.Core.Entities.Services;
using eCommerce.Core.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace eCommerce.Core;
public static class DependencyInjection
{
    /// <summary>
    /// Adds core-related services to the specified service collection for dependency 
    /// injection.
    /// Extension method to add core services such as repositories, database contexts, and
    /// other related services to the dependency injection container
    /// </summary>
    /// <remarks>This method registers repository implementations for products, orders, and 
    /// customers with
    /// scoped lifetimes. Call this method during application startup to ensure required 
    /// core services are
    /// available for dependency injection.</remarks>
    /// <param name="services">The service collection to which core services will be added. Cannot be null.</param>
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        // TO DO: Add Services to the IoC container, such as repositories, database contexts, etc.
        // core services often include data access, caching, and other low-level components.

        services.AddTransient<IUserService, UserService>();
        services.AddValidatorsFromAssemblyContaining<LoginRequestValidator>();
        services.AddValidatorsFromAssemblyContaining<RegisterRequestValidator>();
        return services;
    }
}

