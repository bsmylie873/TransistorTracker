using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Users;

public class UserByIdSpec : Specification<User>
{
    private readonly int _id;

    public UserByIdSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<User, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}