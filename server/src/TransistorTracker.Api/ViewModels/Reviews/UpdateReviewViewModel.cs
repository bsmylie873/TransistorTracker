using FluentValidation;
using TransistorTracker.Api.Validation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Reviews;

public class UpdateReviewViewModel : IValidatable<UpdateReviewViewModelValidator>
{
    public string? ReviewText { get; set; }
    public int Rating { get; set; }
    
    public UpdateReviewViewModelValidator RetrieveValidator() => new();
}

public class UpdateReviewViewModelValidator : AbstractValidator<UpdateReviewViewModel>
{
    public UpdateReviewViewModelValidator()
    {
        RuleFor(x => x.ReviewText)
            .Length(5, 1024)
            .NotEmpty()
            .WithMessage("Review text must be between 5 and 1024 characters long."); 
        
        RuleFor(x => x.Rating)
            .InclusiveBetween(1,10)
            .WithMessage("Rating must be between 1 and 10.");
    }
}