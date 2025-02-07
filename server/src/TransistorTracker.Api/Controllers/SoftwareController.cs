using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Software;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Software;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("software")]
public class SoftwareController : TransistorTrackerBaseController
{
    private readonly IMapper _mapper;
    private readonly ISoftwareService _service;
    
    public SoftwareController(IMapper mapper, ISoftwareService service)
    {
        (_mapper, _service) = (mapper, service);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetSoftware([FromQuery] PaginationDto pagination)
    {
        var software = await _service.GetAllSoftware(pagination);
        return OkOrNoContent(_mapper.Map<PaginatedViewModel<SoftwareViewModel>>(software));
    }
    
    [HttpGet("compatibilities")]
    public async Task<ActionResult> GetSoftwareCompatibility([FromQuery] PaginationDto pagination)
    {
        var softwareCompatibilities = await _service.GetAllSoftwareCompatibilities(pagination);
        return OkOrNoContent(_mapper.Map<IList<SoftwareCompatibilityViewModel>>(softwareCompatibilities));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetSoftwareById(int id)
    {
        var software = await _service.GetSoftwareById(id);
        return OkOrNoNotFound(_mapper.Map<SoftwareViewModel>(software));
    }
    
    [HttpGet("compatibilities/{id}")]
    public async Task<ActionResult> GetSoftwareCompatibilityById(int id)
    {
        var softwareCompatibility = await _service.GetSoftwareCompatibilityById(id);
        return OkOrNoNotFound(_mapper.Map<SoftwareCompatibilityViewModel>(softwareCompatibility));
    }

    [HttpPost]
    public async Task<ActionResult> CreateSoftware([FromBody] CreateSoftwareViewModel software)
    {
        var badRequest = await Validate(software);
        if (badRequest != null) return badRequest;
        await _service.CreateSoftware(_mapper.Map<CreateSoftwareDto>(software));
        return Created();
    }
    
    [HttpPost("compatibilities")]
    public async Task<ActionResult> CreateSoftwareCompatibility([FromBody] CreateSoftwareCompatibilityViewModel softwareCompatibility)
    {
        var badRequest = await Validate(softwareCompatibility);
        if (badRequest != null) return badRequest;
        await _service.CreateSoftwareCompatibility(_mapper.Map<CreateSoftwareCompatibilityDto>(softwareCompatibility));
        return Created();
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateSoftware(int id, [FromBody] UpdateSoftwareViewModel software)
    {
        var badRequest = await Validate(software);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdateSoftware(id, _mapper.Map<UpdateSoftwareDto>(software));
        if (updated.Result) return Ok();
        return NotFound($"Software with id {id} not found");
    }
    
    [HttpPut("compatibilities/{id}")]
    public async Task<ActionResult> UpdateSoftwareCompatibility(int id, [FromBody] UpdateSoftwareCompatibilityViewModel softwareCompatibility)
    {
        var badRequest = await Validate(softwareCompatibility);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdateSoftwareCompatibility(id, _mapper.Map<UpdateSoftwareCompatibilityDto>(softwareCompatibility));
        if (updated.Result) return Ok();
        return NotFound($"Software compatibility with id {id} not found");
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteSoftware(int id)
    {
        var deleted = _service.DeleteSoftware(id);
        if (deleted.Result) return NoContent();
        return NotFound($"Software with id {id} not found");
    }
    
    [HttpDelete("compatibilities/{id}")]
    public ActionResult DeleteSoftwareCompatibility(int id)
    {
        var deleted = _service.DeleteSoftwareCompatibility(id);
        if (deleted.Result) return NoContent();
        return NotFound($"Software compatibility with id {id} not found");
    }
}