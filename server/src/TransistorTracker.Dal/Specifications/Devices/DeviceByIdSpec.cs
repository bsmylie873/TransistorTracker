using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Devices;

public class DeviceByIdSpec : Specification<Device>
{
    private readonly int _id;

    public DeviceByIdSpec(int id)
    {
        _id = id;
    }

    public override Expression<Func<Device, bool>> BuildExpression()
    {
        return x => x.Id == _id;
    }
}