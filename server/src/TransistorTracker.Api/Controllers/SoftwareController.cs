using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Software;
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
    public ActionResult<IList<SoftwareDto>> GetSoftware()
    {
        var software = _service.GetAllSoftware();
        return OkOrNoListContent((IList)_mapper.Map<IList<SoftwareViewModel>>(software));
    }
    
    [HttpGet("{id}")]
    public ActionResult<SoftwareDto> GetSoftwareById(int id)
    {
        var software = _service.GetSoftwareById(id);
        return OkOrNoNotFound(_mapper.Map<SoftwareViewModel>(software));
    }

    [HttpPost]
    public ActionResult CreateSoftware([FromBody] CreateSoftwareDto software)
    {
        _service.CreateSoftware(software);
        return Created();
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateSoftware(int id, [FromBody] UpdateSoftwareDto software)
    {
        var updated = _service.UpdateSoftware(id, software);
        if (updated) return Ok();
        return NotFound($"Software with id {id} not found");
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteSoftware(int id)
    {
        var deleted = _service.DeleteSoftware(id);
        if (deleted) return NoContent();
        return NotFound($"Software with id {id} not found");
    }
}