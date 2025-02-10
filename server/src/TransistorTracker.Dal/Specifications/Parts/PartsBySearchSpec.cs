using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Parts;

public class PartsBySearchSpec : Specification<Part>
{
    private readonly Specification<Part> _spec;
    
    public PartsBySearchSpec(string? search) => _spec = 
        new PartsByNameSpec(search);
    
    public override Expression<Func<Part, bool>> BuildExpression() =>
        _spec.BuildExpression();
}