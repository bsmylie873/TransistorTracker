using FluentValidation;
using TransistorTracker.Api.Validation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Users;

public class CreateUserViewModel : IValidatable<CreateUserViewModelValidator>
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Avatar { get; set; }
    public int UserTypeId { get; set; }
    
    public CreateUserViewModelValidator RetrieveValidator() => new();
}

public class CreateUserViewModelValidator : AbstractValidator<CreateUserViewModel>
{
    public CreateUserViewModelValidator()
    {
        RuleFor(x => x.Username)
            .Length(5, 255)
            .NotEmpty()
            .WithMessage("Username must be between 5 and 255 characters long."); 
        
        RuleFor(x => x.Email)
            .EmailAddress()
            .WithMessage("Email must be a valid email address.")
            .Length(5, 255)
            .NotEmpty()
            .WithMessage("Email must be between 5 and 255 characters long.");
        
        RuleFor(x => x.UserTypeId)
            .Must(i => Enum.IsDefined(typeof(UserTypes), i))
            .WithMessage("User type must be a valid user type.")
            .NotNull()
            .WithMessage("UserTypeId should not be null.");
    }
}