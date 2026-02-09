using eCommerce.Core.DTOs;

namespace eCommerce.Core.Entities.ServiceContracts;

/// <summary>
/// Contract for user service that contains use cases for users, such as login and registration. 
/// This service acts as an intermediary between the presentation layer (e.g., controllers) and 
/// the data access layer (e.g., repositories) to handle user-related business logic and operations.
/// It defines methods for user authentication and registration, allowing the application to manage 
/// user accounts and authentication processes effectively.
/// </summary>
public interface IUserService
{
    /// <summary>
    /// Method to handle user login use case.
    /// </summary>
    /// <param name="loginRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Login(LoginRequest loginRequest);
    /// <summary>
    /// Method to handle user registration use case.
    /// </summary>
    /// <param name="registerRequest"></param>
    /// <returns></returns>
    Task<AuthenticationResponse?> Register(RegisterRequest registerRequest);
}
