using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Parts;
using TransistorTracker.Server.DTOs.Pagination;
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
    public async Task<ActionResult> GetParts([FromQuery] PaginationDto pagination)
    {
        var parts = await _service.GetAllParts(pagination);
        return OkOrNoContent(_mapper.Map<PaginatedViewModel<PartViewModel>>(parts));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetPartById(int id)
    {
        var part = await _service.GetPartById(id);
        return OkOrNoNotFound(_mapper.Map<PartViewModel>(part));
    }

    [HttpPost]
    public async Task<ActionResult> CreatePart([FromBody] CreatePartViewModel part)
    {
        var badRequest = await Validate(part);
        if (badRequest != null) return badRequest;
        await _service.CreatePart(_mapper.Map<CreatePartDto>(part));
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateDevice(int id, [FromBody] UpdatePartViewModel part)
    {
        var badRequest = await Validate(part);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdatePart(id, _mapper.Map<UpdatePartDto>(part));
        if (updated.Result) return Ok();
        return NotFound($"Part with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDevice(int id)
    {
        var deleted = _service.DeletePart(id);
        if (deleted.Result) return NoContent();
        return NotFound($"Part with id {id} not found");
    }
}