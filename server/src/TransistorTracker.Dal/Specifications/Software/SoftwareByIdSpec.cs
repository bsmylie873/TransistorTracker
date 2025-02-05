using System.Linq.Expressions;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Software;

public class SoftwareByIdSpec : Specification<Models.Software>
{
    private readonly int _id;

    public SoftwareByIdSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Models.Software, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}