using FluentValidation;
using TransistorTracker.Api.Validation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Reviews;

public class CreateReviewViewModel : IValidatable<CreateReviewViewModelValidator>
{
    public string? ReviewText { get; set; }
    public int Rating { get; set; }
    public int UserId { get; set; }
    public int? DeviceId { get; set; }
    public int? PartId { get; set; }
    
    public CreateReviewViewModelValidator RetrieveValidator() => new();
}

public class CreateReviewViewModelValidator : AbstractValidator<CreateReviewViewModel>
{
    public CreateReviewViewModelValidator()
    {
        RuleFor(x => x.ReviewText)
            .Length(5, 1024)
            .NotEmpty()
            .WithMessage("Review text must be between 5 and 1024 characters long."); 
        
        RuleFor(x => x.Rating)
            .InclusiveBetween(1,10)
            .WithMessage("Rating must be between 1 and 10.");
        
        RuleFor(x => x.UserId)
            .GreaterThan(0)
            .WithMessage("UserId must be greater than 0.")
            .NotNull()
            .WithMessage("UserId must not be null.");
        
        RuleFor(x => x)
            .Must(x => (x.PartId is > 0 || x.DeviceId is > 0) && x is not { PartId: not null, DeviceId: not null })
            .WithMessage("Either PartId or DeviceId must be provided and greater than 0, but not both.");
    }
}