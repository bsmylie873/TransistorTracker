using System.Linq.Expressions;
using TransistorTracker.Dal.Models;
using Unosquare.EntityFramework.Specification.Common.Primitive;

namespace TransistorTracker.Dal.Specifications.Devices;

public class DevicesByModelSpec : Specification<Device>
{
    private readonly string? _model;

    public DevicesByModelSpec(string? model) => _model = model?.ToLower();

    public override Expression<Func<Device, bool>> BuildExpression()
    {
        if (string.IsNullOrEmpty(_model)) return ShowAll;
        
        return x => x.Model.ToLower().StartsWith(_model);
    }
}