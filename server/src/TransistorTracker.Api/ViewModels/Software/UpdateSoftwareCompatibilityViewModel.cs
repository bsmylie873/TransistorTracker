using FluentValidation;
using TransistorTracker.Api.Validation;
using TransistorTracker.Dal.Enums;

namespace TransistorTracker.Api.ViewModels.Software;

public class UpdateSoftwareCompatibilityViewModel : IValidatable<UpdateSoftwareCompatibilityViewModelValidator>
{
    public int SoftwareId { get; set; }
    public int? PartId { get; set; }
    public int? DeviceId { get; set; }
    public int SoftwareCompatibilityLevelId { get; set; }
    
    public UpdateSoftwareCompatibilityViewModelValidator RetrieveValidator() => new();
}

public class UpdateSoftwareCompatibilityViewModelValidator : AbstractValidator<UpdateSoftwareCompatibilityViewModel>
{
    public UpdateSoftwareCompatibilityViewModelValidator()
    {
        RuleFor(x => x.SoftwareId)
            .NotNull()
            .WithMessage("SoftwareId should not be null.");
        
        RuleFor(x => x.SoftwareCompatibilityLevelId)
            .Must(i => Enum.IsDefined(typeof(SoftwareCompatibilityLevels), i))
            .WithMessage("Software compatibility level must be a valid level type.")
            .NotNull()
            .WithMessage("SoftwareCompatibilityLevelId should not be null.");
        
        RuleFor(x => x)
            .Must(x => (x.PartId is > 0 || x.DeviceId is > 0) && x is not { PartId: not null, DeviceId: not null })
            .WithMessage("Either PartId or DeviceId must be provided and greater than 0, but not both.");
    }
}