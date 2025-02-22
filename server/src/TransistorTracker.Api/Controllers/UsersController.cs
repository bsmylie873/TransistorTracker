using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Pagination;
using TransistorTracker.Api.ViewModels.Users;
using TransistorTracker.Server.DTOs.Pagination;
using TransistorTracker.Server.DTOs.Users;
using TransistorTracker.Server.Interfaces;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : TransistorTrackerBaseController
{
    private readonly IMapper _mapper;
    private readonly IUserService _service;

    public UsersController(IMapper mapper, IUserService service)
    {
        (_mapper, _service) = (mapper, service);
    }
    
    [HttpGet]
    public async Task<ActionResult> GetUsers([FromQuery] PaginationDto pagination)
    {
        var users = await _service.GetAllUsers(pagination);
        return OkOrNoContent(_mapper.Map<PaginatedViewModel<UserViewModel>>(users));
    }
    
    [HttpGet("{id}")]
    public async Task<ActionResult> GetUserById(int id)
    {
        var user = await _service.GetUserById(id);
        return OkOrNoNotFound(_mapper.Map<UserViewModel>(user));
    }
    
    [HttpPost]
    public async Task<ActionResult> CreateUser([FromBody] CreateUserViewModel user)
    {
        var badRequest = await Validate(user);
        if (badRequest != null) return badRequest;
        await _service.CreateUser(_mapper.Map<CreateUserDto>(user));
        return Created();
    }
    
    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser(int id, [FromBody] UpdateUserViewModel user)
    {
        var badRequest = await Validate(user);
        if (badRequest != null) return badRequest;
        var updated = await _service.UpdateUser(id, _mapper.Map<UpdateUserDto>(user));
        if (updated) return Ok();
        return NotFound($"User with id {id} not found");
    }
    
    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        var deleted = await _service.DeleteUser(id);
        if (deleted) return NoContent();
        return NotFound($"User with id {id} not found");
    }
}