using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Software;

public class SoftwareCompatibilitiesBySoftwareIdSpec : Specification<SoftwareCompatibility>
{
    private readonly string? _softwareId;

    public SoftwareCompatibilitiesBySoftwareIdSpec(string? softwareId) => _softwareId = softwareId?.ToLower();

    public override Expression<Func<SoftwareCompatibility, bool>> BuildExpression()
    {
        int.TryParse(_softwareId, out var softwareId);
        return x => x.SoftwareId == softwareId;
    }
}