using FluentValidation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Users;

public class CreateUserViewModel
{
    public string Username { get; set; } = null!;
    public string Email { get; set; } = null!;
    public string? Avatar { get; set; }
    public int UserTypeId { get; set; }
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
            .Length(5, 255)
            .NotEmpty()
            .WithMessage("Email must be between 5 and 255 characters long.");
        
        RuleFor(x => x.UserTypeId)
            .Must(i => Enum.IsDefined(typeof(UserTypes), i))
            .WithMessage("Device category must be a valid category type.")
            .NotNull()
            .WithMessage("CategoryId should not be null.");
    }
}