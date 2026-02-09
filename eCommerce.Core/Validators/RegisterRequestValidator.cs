using eCommerce.Core.DTOs;
using FluentValidation;

namespace eCommerce.Core.Validators;

public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required.")
            .EmailAddress().WithMessage("Invalid email format.");
        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required.")
            .MinimumLength(6).WithMessage("Password must be at least 6 characters long.");
        RuleFor(x => x.PersonName)
            .NotEmpty().WithMessage("Person name is required.")
            .Length(1, 50).WithMessage("Person name must be atleast 1 character and " +
            "cannot exceed 50 characters");
            //.MaximumLength(100).WithMessage("Person name cannot exceed 100 characters.");
        RuleFor(x => x.Gender)
            .IsInEnum().WithMessage("Gender must be a valid value (Male, Female, or Others).");
    }
}
