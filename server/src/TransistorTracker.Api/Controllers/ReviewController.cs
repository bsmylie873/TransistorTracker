using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Reviews;
using TransistorTracker.Server.DTOs.Pagination;
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
    public async Task<ActionResult> GetReviews([FromQuery] PaginationDto pagination)
    {
        var reviews = await _service.GetAllReviews(pagination);
        return OkOrNoContent(_mapper.Map<PaginatedViewModel<ReviewViewModel>>(reviews));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetReviewById(int id)
    {
        var review = await _service.GetReviewById(id);
        return OkOrNoNotFound(_mapper.Map<ReviewViewModel>(review));
    }

    [HttpPost]
    public async Task<ActionResult> CreateReview([FromBody] CreateReviewViewModel review)
    {
        var badRequest = await Validate(review);
        if (badRequest != null) return badRequest;
        await _service.CreateReview(_mapper.Map<CreateReviewDto>(review));
        return Created();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateReview(int id, [FromBody] UpdateReviewViewModel review)
    {
        var badRequest = await Validate(review);
        if (badRequest != null) return badRequest;
        var updated = _service.UpdateReview(id, _mapper.Map<UpdateReviewDto>(review));
        if (updated.Result) return Ok();
        return NotFound($"Review with id {id} not found");
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteReview(int id)
    {
        var deleted = _service.DeleteReview(id);
        if (deleted.Result) return NoContent();
        return NotFound($"Review with id {id} not found");
    }
}