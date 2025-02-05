using System.Collections;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;
using TransistorTracker.Api.ViewModels.Users;
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
    public ActionResult<IList<UserViewModel>> GetUsers()
    {
        var users = _service.GetAllUsers();
        return OkOrNoListContent((IList)_mapper.Map<IList<UserViewModel>>(users));
    }
    
    [HttpGet("{id}")]
    public ActionResult<UserViewModel> GetUserById(int id)
    {
        var user = _service.GetUserById(id);
        return OkOrNoNotFound(_mapper.Map<UserViewModel>(user));
    }
    
    [HttpPost]
    public ActionResult CreateUser([FromBody] CreateUserViewModel user)
    {
        _service.CreateUser(_mapper.Map<CreateUserDto>(user));
        return Created();
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] UpdateUserViewModel user)
    {
        var updated = _service.UpdateUser(id, _mapper.Map<UpdateUserDto>(user));
        if (updated) return Ok();
        return NotFound($"User with id {id} not found");
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        var deleted = _service.DeleteUser(id);
        if (deleted) return NoContent();
        return NotFound($"User with id {id} not found");
    }
}