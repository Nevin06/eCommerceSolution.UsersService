namespace eCommerce.Core.DTOs;

public record AuthenticationResponse(
    Guid UserID,
    string? Email,
    string? PersonName,
    GenderOptions Gender,
    string? Token,
    bool Success)
//; (20)
{
    // new keyword uses above, Automapper uses below
    // Parameterless constructor
    public AuthenticationResponse() : this(default, default, default, default, default, default) 
        // parameterized constructor
    {

    }
}

