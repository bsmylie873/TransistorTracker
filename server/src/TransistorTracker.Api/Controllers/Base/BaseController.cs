using System.Collections;
using System.Diagnostics.CodeAnalysis;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Validation;

namespace TransistorTracker.Api.Controllers.Base;

[ExcludeFromCodeCoverage]
[ApiController]
public class TransistorTrackerBaseController : ControllerBase
{
    protected ActionResult OkOrNoContent(object value)
    {
        if (HasNoValueOrItems(value)) return NoContent();

        return Ok(value);
    }

    protected ActionResult OkOrNoListContent(IList value)
    {
        if (HasNoValueOrItems(value)) return NoContent();

        return Ok(value);
    }

    protected ActionResult OkOrNoNotFound(object value)
    {
        if (HasNoValueOrItems(value)) return NotFound();

        return Ok(value);
    }
    
    protected static async Task<ActionResult?> Validate<T>(T model) where T : IValidatable<IValidator<T>>, new()
    {
        var validator = model.RetrieveValidator();
        var result = await validator.ValidateAsync(model);
        return !result.IsValid ? new BadRequestObjectResult(result.Errors) : null;
    }

    private static bool HasNoValueOrItems(object value)
    {
        return value == null || value is IList { Count: < 1 };
    }
}