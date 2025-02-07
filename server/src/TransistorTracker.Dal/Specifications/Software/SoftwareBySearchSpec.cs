using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Software;

public class SoftwareBySearchSpec : Specification<Models.Software>
{
    private readonly Specification<Models.Software> _spec;
    
    public SoftwareBySearchSpec(string? search) => _spec = 
        new SoftwareByNameSpec(search);
    
    public override Expression<Func<Models.Software, bool>> BuildExpression() =>
        _spec.BuildExpression();
}