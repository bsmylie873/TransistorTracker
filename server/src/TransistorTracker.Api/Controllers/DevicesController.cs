using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Devices;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Server.DTOs.Devices;
using TransistorTracker.Server.DTOs.Pagination;
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
    public async Task<ActionResult> GetDevices([FromQuery] PaginationDto pagination)
    {
        var devices = await _service.GetAllDevices(pagination);
        return OkOrNoContent(_mapper.Map<PaginatedViewModel<DeviceViewModel>>(devices));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult<DeviceViewModel>> GetDeviceById(int id)
    {
        var device = await _service.GetDeviceById(id);
        return OkOrNoNotFound(_mapper.Map<DeviceViewModel>(device));
    }

    [HttpPost]
    public async Task<ActionResult> CreateDevice([FromBody] CreateDeviceViewModel device)
    {
        var badRequest = await Validate(device);
        if (badRequest != null) return badRequest;
        await _service.CreateDevice(_mapper.Map<CreateDeviceDto>(device));
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDevice(int id, [FromBody] UpdateDeviceViewModel device)
    {
        var badRequest = await Validate(device);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdateDevice(id, _mapper.Map<UpdateDeviceDto>(device));
        if (updated.Result) return Ok();
        return NotFound($"Device with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDevice(int id)
    {
        var deleted = _service.DeleteDevice(id);
        if (deleted.Result) return NoContent();
        return NotFound($"Device with id {id} not found");
    }
}