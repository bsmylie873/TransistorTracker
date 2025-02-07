using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Software;

public class SoftwareCompatibilityByIdSpec : Specification<SoftwareCompatibility>
{
    private readonly int _id;

    public SoftwareCompatibilityByIdSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<SoftwareCompatibility, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}