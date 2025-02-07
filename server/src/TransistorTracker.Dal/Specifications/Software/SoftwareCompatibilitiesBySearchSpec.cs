using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Software;

public class SoftwareCompatibilitiesBySearchSpec : Specification<SoftwareCompatibility>
{
    private readonly Specification<SoftwareCompatibility> _spec;
    
    public SoftwareCompatibilitiesBySearchSpec(string? search) => _spec = 
        new SoftwareCompatibilitiesBySoftwareIdSpec(search);
    
    public override Expression<Func<SoftwareCompatibility, bool>> BuildExpression() =>
        _spec.BuildExpression();
}