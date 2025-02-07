using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Locations;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Software;
using TransistorTracker.Server.DTOs.Locations;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("locations")]
public class LocationsController : TransistorTrackerBaseController
{
    private readonly IMapper _mapper;
    private readonly ILocationService _service;
    
    public LocationsController(IMapper mapper, ILocationService service)
    {
        (_mapper, _service) = (mapper, service);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetLocations([FromQuery] PaginationDto pagination)
    {
        var locations = await _service.GetAllLocations(pagination);
        return OkOrNoContent(_mapper.Map<PaginatedViewModel<LocationViewModel>>(locations));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetLocationById(int id)
    {
        var location = await _service.GetLocationById(id);
        return OkOrNoNotFound(_mapper.Map<LocationViewModel>(location));
    }

    [HttpPost]
    public async Task<ActionResult> CreateLocation([FromBody] CreateLocationViewModel location)
    { 
        var badRequest = await Validate(location);
        if (badRequest != null) return badRequest;
        await _service.CreateLocation(_mapper.Map<CreateLocationDto>(location));
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateLocation(int id, [FromBody] UpdateLocationViewModel location)
    {
        var badRequest = await Validate(location);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdateLocation(id, _mapper.Map<UpdateLocationDto>(location));
        if (updated.Result) return Ok();
        return NotFound($"Location with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLocation(int id)
    {
        var deleted = _service.DeleteLocation(id);
        if (deleted.Result) return NoContent();
        return NotFound($"Location with id {id} not found");
    }
}