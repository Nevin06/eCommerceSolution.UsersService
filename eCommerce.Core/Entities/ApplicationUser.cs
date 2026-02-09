namespace eCommerce.Core.Entities;

/// <summary>
/// Define the ApplicationUser class, which acts as an entity model class to store user details
/// in data store.
/// </summary>
public class ApplicationUser
{
    public Guid UserID { get; set; }
    //public string UserName { get; set; } = string.Empty;
    public string? Email { get; set; } = string.Empty;
    //public string PasswordHash { get; set; } = string.Empty;
    public string? Password { get; set; } = string.Empty;
    public string? PersonName { get; set; } = string.Empty;
    public string? Gender { get; set; } = string.Empty;

}

