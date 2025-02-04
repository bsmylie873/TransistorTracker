using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("locations")]
public class LocationsController : TransistorTrackerBaseController
{
    [HttpGet]
    public ActionResult<string> GetLocations()
    {
        return Ok(1);
    }
    
    [HttpGet("{id}")]
    public ActionResult<string> GetLocationById(int id)
    {
        return Ok(1);
    }

    [HttpPost]
    public ActionResult CreateLocation([FromBody] string location)
    {
        return Created("", location);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateLocation(int id, [FromBody] string location)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteLocation(int id)
    {
        return NoContent();
    }
}