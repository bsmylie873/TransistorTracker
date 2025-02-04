using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("software")]
public class SoftwareController : TransistorTrackerBaseController
{
    [HttpGet]
    public ActionResult<string> GetSoftware()
    {
        return Ok(1);
    }
    
    [HttpGet("{id}")]
    public ActionResult<string> GetSoftwareById(int id)
    {
        return Ok(1);
    }

    [HttpPost]
    public ActionResult CreateSoftware([FromBody] string software)
    {
        return Created("", software);
    }
    
    [HttpPut("{id}")]
    public ActionResult UpdateSoftware(int id, [FromBody] string software)
    {
        return NoContent();
    }
    
    [HttpDelete("{id}")]
    public ActionResult DeleteSoftware(int id)
    {
        return NoContent();
    }
}