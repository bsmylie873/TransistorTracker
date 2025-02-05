using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Locations;
using TransistorTracker.Api.ViewModels.Software;
using TransistorTracker.Server.DTOs.Locations;
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
    public ActionResult<IList<LocationViewModel>> GetLocations()
    {
        var locations = _service.GetAllLocations();
        return OkOrNoListContent((IList)_mapper.Map<IList<LocationViewModel>>(locations));
    }
    
    [HttpGet("{id}")]
    public ActionResult<LocationViewModel> GetLocationById(int id)
    {
        var location = _service.GetLocationById(id);
        return OkOrNoNotFound(_mapper.Map<LocationViewModel>(location));
    }

    [HttpPost]
    public ActionResult CreateLocation([FromBody] CreateLocationViewModel location)
    { 
        _service.CreateLocation(_mapper.Map<CreateLocationDto>(location));
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateLocation(int id, [FromBody] UpdateLocationViewModel location)
    {
        var updated = _service.UpdateLocation(id, _mapper.Map<UpdateLocationDto>(location));
        if (updated) return Ok();
        return NotFound($"Location with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLocation(int id)
    {
        var deleted = _service.DeleteLocation(id);
        if (deleted) return NoContent();
        return NotFound($"Location with id {id} not found");
    }
}