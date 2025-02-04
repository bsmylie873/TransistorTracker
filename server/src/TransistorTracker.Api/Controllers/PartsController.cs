using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("parts")]
public class PartsController : TransistorTrackerBaseController
{
    [HttpGet]
    public ActionResult<string> GetParts()
    {
        return Ok(1);
    }
    
    [HttpGet("{id}")]
    public ActionResult<string> GetPartById(int id)
    {
        return Ok(1);
    }

    [HttpPost]
    public ActionResult CreatePart([FromBody] string part)
    {
        return Created("", part);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDevice(int id, [FromBody] string part)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDevice(int id)
    {
        return NoContent();
    }
}