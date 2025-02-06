using FluentValidation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Software;

public class UpdateSoftwareViewModel
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public string? Avatar { get; set; }
    public string? Version { get; set; }
    public DateOnly? ReleaseDate { get; set; }
    public int? CategoryId { get; set; }
}

public class UpdateSoftwareViewModelValidator : AbstractValidator<UpdateSoftwareViewModel>
{
    public UpdateSoftwareViewModelValidator()
    {
        RuleFor(x => x.Name)
            .Length(5, 255)
            .NotEmpty()
            .WithMessage("Name must be between 5 and 255 characters long."); 
        
        RuleFor(x => x.Version)
            .Length(3, 50)
            .When(x => x.Version != null)
            .WithMessage("Version must be between 3 and 50 characters long.");
        
        RuleFor(x => x.ReleaseDate)
            .LessThanOrEqualTo(DateOnly.FromDateTime(DateTime.Today))
            .When(x => x.ReleaseDate.HasValue)
            .WithMessage("Release date must not be in the future.");
        
        RuleFor(x => x.CategoryId)
            .Must(i => Enum.IsDefined(typeof(SoftwareCategories), i))
            .WithMessage("Device category must be a valid category type.")
            .NotNull()
            .WithMessage("CategoryId should not be null.");
    }
}