using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("users")]
public class UsersController : TransistorTrackerBaseController
{
    [HttpGet]
    public ActionResult<string> GetUsers()
    {
        return Ok(1);
    }
    
    [HttpGet("{id}")]
    public ActionResult<string> GetUserById(int id)
    {
        return Ok(1);
    }
    
    [HttpPost]
    public ActionResult CreateUser([FromBody] string user)
    {
        return Created("", user);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateUser(int id, [FromBody] string user)
    {
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteUser(int id)
    {
        return NoContent();
    }
}