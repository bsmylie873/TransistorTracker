using FluentValidation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Locations;

public class CreateLocationViewModel
{
    public string Name { get; set; } = null!;
    public string? Avatar { get; set; }
    public string? HouseNumber { get; set; }
    public string? Street { get; set; }
    public string? City { get; set; }
    public string? State { get; set; }
    public string? PostalCode { get; set; }
    public string? Country { get; set; }
    public int UserId { get; set; }
}

public class CreateLocationViewModelValidator : AbstractValidator<CreateLocationViewModel>
{
    public CreateLocationViewModelValidator()
    {
        RuleFor(x => x.Name)
            .Length(5, 255)
            .NotEmpty()
            .WithMessage("Name must be between 5 and 255 characters long."); 
        
        RuleFor(x => x.HouseNumber)
            .Length(5, 50)
            .When(x => x.HouseNumber != null)
            .WithMessage("House number must be between 5 and 50 characters long.");

        RuleFor(x => x.Street)
            .Length(5, 255)
            .When(x => x.Street != null)
            .WithMessage("Street must be between 5 and 50 characters long.");

        RuleFor(x => x.City)
            .Length(5, 255)
            .When(x => x.City != null)
            .WithMessage("City must be between 5 and 255 characters long.");
        
        RuleFor(x => x.State)
            .Length(5, 255)
            .When(x => x.State != null)
            .WithMessage("State must be between 5 and 255 characters long.");
        
        RuleFor(x => x.PostalCode)
            .Length(3, 10)
            .When(x => x.PostalCode != null)
            .WithMessage("Postal code must be between 3 and 10 characters long.");
        
        RuleFor(x => x.Country)
            .Length(5, 255)
            .When(x => x.Country != null)
            .WithMessage("Country must be between 3 and 10 characters long.");
        
        RuleFor(x => x.UserId)
            .NotNull()
            .WithMessage("UserId must not be null.");
    }
}