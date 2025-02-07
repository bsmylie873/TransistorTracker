using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Devices;

public class DevicesByNameSpec : Specification<Device>
{
    private readonly string? _name;

    public DevicesByNameSpec(string? name) => _name = name?.ToLower();

    public override Expression<Func<Device, bool>> BuildExpression()
    {
        if (string.IsNullOrEmpty(_name)) return ShowAll;
        
        return x => x.Name.ToLower().StartsWith(_name);
    }
}