using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Parts;
using TransistorTracker.Server.DTOs.Parts;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("parts")]
public class PartsController : TransistorTrackerBaseController
{
    private readonly IMapper _mapper;
    private readonly IPartService _service;
    
    public PartsController(IMapper mapper, IPartService service)
    {
        (_mapper, _service) = (mapper, service);
    }
    
    [HttpGet]
    public ActionResult<IList<PartViewModel>> GetParts()
    {
        var parts = _service.GetAllParts();
        return OkOrNoListContent((IList)_mapper.Map<IList<PartViewModel>>(parts));
    }
    
    [HttpGet("{id}")]
    public ActionResult<PartViewModel> GetPartById(int id)
    {
        var part = _service.GetPartById(id);
        return OkOrNoNotFound(_mapper.Map<PartViewModel>(part));
    }

    [HttpPost]
    public ActionResult CreatePart([FromBody] CreatePartViewModel part)
    {
        _service.CreatePart(_mapper.Map<CreatePartDto>(part));
        return Created();
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDevice(int id, [FromBody] UpdatePartViewModel part)
    {
        var updated = _service.UpdatePart(id, _mapper.Map<UpdatePartDto>(part));
        if (updated) return Ok();
        return NotFound($"Part with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDevice(int id)
    {
        var deleted = _service.DeletePart(id);
        if (deleted) return NoContent();
        return NotFound($"Part with id {id} not found");
    }
}