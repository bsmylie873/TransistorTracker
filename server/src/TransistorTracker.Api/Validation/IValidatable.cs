using FluentValidation;

namespace TransistorTracker.Api.Validation;

public interface IValidatable<out T> where T : IValidator
{
    T RetrieveValidator();
}