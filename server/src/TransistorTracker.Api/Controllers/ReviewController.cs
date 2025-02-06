using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Reviews;
using TransistorTracker.Server.DTOs.Reviews;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("Reviews")]
public class ReviewsController : TransistorTrackerBaseController
{
    private readonly IMapper _mapper;
    private readonly IReviewService _service;
    
    public ReviewsController(IMapper mapper, IReviewService service)
    {
        (_mapper, _service) = (mapper, service);
    }
    
    [HttpGet]
    public ActionResult<IList<ReviewViewModel>> GetReviews()
    {
        var reviews = _service.GetAllReviews();
        return OkOrNoListContent((IList)_mapper.Map<IList<ReviewViewModel>>(reviews));
    }
    
    [HttpGet("{id}")]
    public ActionResult<ReviewViewModel> GetReviewById(int id)
    {
        var review = _service.GetReviewById(id);
        return OkOrNoNotFound(_mapper.Map<ReviewViewModel>(review));
    }

    [HttpPost]
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewViewModel Review)
    {
        var badRequest = await Validate(Review);
        if (badRequest != null) return badRequest;
        _service.CreateReview(_mapper.Map<CreateReviewDto>(Review));
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateReview(int id, [FromBody] UpdateReviewViewModel Review)
    {
        var badRequest = await Validate(Review);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdateReview(id, _mapper.Map<UpdateReviewDto>(Review));
        if (updated) return Ok();
        return NotFound($"Review with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteReview(int id)
    {
        var deleted = _service.DeleteReview(id);
        if (deleted) return NoContent();
        return NotFound($"Review with id {id} not found");
    }
}