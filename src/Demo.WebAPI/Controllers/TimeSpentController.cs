using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SerilogTimings;

namespace Demo.WebAPI.Controllers;

[ApiController]
[Route("time-spent")]
public class TimeSpentController : ControllerBase
{
    private readonly ILogger<TimeSpentController> _logger;

    public TimeSpentController(ILogger<TimeSpentController> logger)
        => _logger = logger;



    [HttpGet]
    public IActionResult Get()
    {
        using(Operation.Time("Step 1"))
        {
            _logger.LogInformation("Working 1...");
        }

        using(Operation.Time("Step 2"))
        {
            _logger.LogInformation("Working 2...");
        }

        return Ok(nameof(Get));
    }
}
