using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Devices;
using TransistorTracker.Server.DTOs.Devices;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("devices")]
public class DevicesController : TransistorTrackerBaseController
{
    private readonly IMapper _mapper;
    private readonly IDeviceService _service;
    
    public DevicesController(IMapper mapper, IDeviceService service)
    {
        (_mapper, _service) = (mapper, service);
    }
    
    [HttpGet]
    public ActionResult<IList<DeviceViewModel>> GetDevices()
    {
        var devices = _service.GetAllDevices();
        return OkOrNoListContent((IList)_mapper.Map<IList<DeviceViewModel>>(devices));
    }
    
    [HttpGet("{id}")]
    public ActionResult<DeviceViewModel> GetDeviceById(int id)
    {
        var device = _service.GetDeviceById(id);
        return OkOrNoNotFound(_mapper.Map<DeviceViewModel>(device));
    }

    [HttpPost]
    public async Task<ActionResult> CreateDevice([FromBody] CreateDeviceViewModel device)
    {
        var badRequest = await Validate(device);
        if (badRequest != null) return badRequest;
        _service.CreateDevice(_mapper.Map<CreateDeviceDto>(device));
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDevice(int id, [FromBody] UpdateDeviceViewModel device)
    {
        var badRequest = await Validate(device);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdateDevice(id, _mapper.Map<UpdateDeviceDto>(device));
        if (updated) return Ok();
        return NotFound($"Device with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDevice(int id)
    {
        var deleted = _service.DeleteDevice(id);
        if (deleted) return NoContent();
        return NotFound($"Device with id {id} not found");
    }
}