using Microsoft.AspNetCore.Mvc;
using TransistorTracker.Api.Controllers.Base;

namespace TransistorTracker.Api.Controllers;

[ApiController]
[Route("devices")]
public class DevicesController : TransistorTrackerBaseController
{
    [HttpGet]
    public ActionResult<string> GetDevices()
    {
        return Ok(1);
    }
    
    [HttpGet("{id}")]
    public ActionResult<string> GetDeviceById(int id)
    {
        return Ok(1);
    }

    [HttpPost]
    public ActionResult CreateDevice([FromBody] string device)
    {
        return Created("", device);
    }

    [HttpPut("{id}")]
    public ActionResult UpdateDevice(int id, [FromBody] string device)
    {
        return NoContent();
    }

    [HttpDelete("{id}")]
    public ActionResult DeleteDevice(int id)
    {
        return NoContent();
    }
}