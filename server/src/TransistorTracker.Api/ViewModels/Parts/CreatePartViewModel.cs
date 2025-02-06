using FluentValidation;
using TransistorTracker.Api.Validation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Parts;

public class CreatePartViewModel : IValidatable<CreatePartViewModelValidator>
{
    public string Name { get; set; } = null!;
    public string? Avatar { get; set; }
    public string? Description { get; set; }
    public int? Wattage { get; set; }
    public string? Colour { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public int? DeviceId { get; set; }
    public int UserId { get; set; }
    public int? LocationId { get; set; }
    public int CategoryId { get; set; }
    public int ConditionId { get; set; }
    public int StatusId { get; set; }
    
    public CreatePartViewModelValidator RetrieveValidator() => new();
}

public class CreatePartViewModelValidator : AbstractValidator<CreatePartViewModel>
{
    public CreatePartViewModelValidator()
    {
        RuleFor(x => x.Name)
            .Length(5, 255)
            .NotEmpty()
            .WithMessage("Name must be between 5 and 255 characters long.");
        
        RuleFor(x => x.Description)
            .Length(5, 255)
            .When(x => x.Description != null)
            .WithMessage("Description must be between 5 and 255 characters long.");
        
        RuleFor(x => x.Wattage)
            .LessThanOrEqualTo(2000)
            .When(x => x.Wattage.HasValue)
            .WithMessage("Wattage must be less than 2000W.");
        
        RuleFor(x => x.Colour)
            .Length(3, 50)
            .When(x => x.Colour != null)
            .WithMessage("Colour must be between 3 and 50 characters long.");
        
        RuleFor(x => x.ReleaseDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .When(x => x.ReleaseDate.HasValue)
            .WithMessage("Release date must not be in the future.");
        
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be greater than 0.")
            .NotNull()
            .WithMessage("UserId must not be null.");
        
        RuleFor(x => x.ConditionId)
            .Must(i => Enum.IsDefined(typeof(HardwareConditions), i))
            .WithMessage("Condition must be a valid condition type.")
            .NotNull()
            .WithMessage("ConditionId should not be null.");
        
        RuleFor(x => x.StatusId)
            .Must(i => Enum.IsDefined(typeof(HardwareStatuses), i))
            .WithMessage("Status must be a valid status type.")
            .NotNull()
            .WithMessage("StatusId should not be null.");
        
        RuleFor(x => x.CategoryId)
            .Must(i => Enum.IsDefined(typeof(PartsCategories), i))
            .WithMessage("Part category must be a valid category type.")
            .NotNull()
            .WithMessage("CategoryId should not be null.");
    }
}