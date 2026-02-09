using eCommerce.Core.DTOs;
using eCommerce.Core.Entities;
using eCommerce.Core.Entities.RepositoryContracts;
using eCommerce.Infrastructure.DbContext;
using Dapper;

namespace eCommerce.Infrastructure.Repositories;

internal class UsersRepository : IUsersRepository
{
    private readonly DapperDbContext _dbContext;
    public UsersRepository(DapperDbContext dapperDbContext)
    {
        _dbContext = dapperDbContext;
    }
    public async Task<ApplicationUser?> AddUser(ApplicationUser user)
    {
        // Generate a new UserID for the user
        user.UserID = Guid.NewGuid();
        int rowCountAffected = 0;

        // SQL query to insert the user into the database
        string query = "INSERT INTO public.\"Users\" (\"UserID\", \"Email\", " +
            "\"Password\", \"PersonName\", \"Gender\") " +
            "VALUES(@UserID, @Email, @Password, @PersonName, @Gender)";
        //_dbContext.DbConnection.ExecuteAsync(query, user);
        using (var connection = _dbContext.CreateConnection())
        {
            rowCountAffected = await connection.ExecuteAsync(query, user); //23
        }

        if (rowCountAffected == 0)
        {
            return null;
        }
        else
        {
            // Return the user with the generated UserID
             return user;
        }
    }

    public async Task<ApplicationUser?> GetUserByEmailAndPassword(string? email, string? password)
    {
        string query = "SELECT * FROM public.\"Users\" WHERE \"Email\" = @email AND \"Password\" = @Password";
        ApplicationUser? user = null;

        using (var connection = _dbContext.CreateConnection())
        {
            user = await connection.QueryFirstOrDefaultAsync<ApplicationUser>(query, 
                new { Email = email, Password = password });
        }

        //return new ApplicationUser
        //{
        //    UserID = Guid.NewGuid(),
        //    Email = email,
        //    Password = password,
        //    PersonName = "Person Name",
        //    Gender = GenderOptions.Male.ToString()
        //};

        return user;
    }
}
