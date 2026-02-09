namespace eCommerce.Core.Entities.RepositoryContracts;

/// <summary>
/// Contract interface for user repository, defining the methods for adding a new user and 
/// retrieving a user based on email and password. (data access logic of Users data store.)
/// </summary>
public interface IUsersRepository
{
    /// <summary>
    /// Method to add a new user to the data store and return the added user.
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    Task<ApplicationUser?> AddUser(ApplicationUser user);
    /// <summary>
    /// Method to retrieve a user from the data store based on the provided email and password. 
    /// This method is used for authentication purposes, allowing the application 
    /// to verify user credentials and retrieve user details if the credentials are valid.
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <returns></returns>
    Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password);
}
