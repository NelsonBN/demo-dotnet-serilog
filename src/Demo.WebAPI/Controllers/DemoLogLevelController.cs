using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Demo.WebAPI.Controllers;

[ApiController]
[Route("demo-log-level")]
public class DemoLogLevelController : ControllerBase
{
    private readonly ILogger<DemoLogLevelController> _logger;

    public DemoLogLevelController(ILogger<DemoLogLevelController> logger)
        => _logger = logger;



    [HttpGet("trace")]
    public IActionResult Trace()
    {
        _logger.LogTrace(nameof(Trace));

        return Ok(nameof(Trace));
    }

    [HttpGet("debug")]
    public IActionResult Debug()
    {
        _logger.LogDebug(nameof(Debug));

        return Ok(nameof(Debug));
    }

    [HttpGet("info")]
    public IActionResult Info()
    {
        _logger.LogInformation(nameof(Info));

        return Ok(nameof(Debug));
    }

    [HttpGet("warning")]
    public IActionResult Warning()
    {
        _logger.LogWarning(nameof(Warning));

        return Ok(nameof(Warning));
    }

    [HttpGet("error")]
    public IActionResult Error()
    {
        _logger.LogError(nameof(Error));

        return Ok(nameof(Error));
    }

    [HttpGet("exception")]
    public IActionResult Exception()
    {
        _logger.LogError(new Exception("demo"), nameof(Exception));

        return Ok(nameof(Exception));
    }

    [HttpGet("critical")]
    public IActionResult Critical()
    {
        _logger.LogCritical(nameof(Critical));

        return Ok(nameof(Critical));
    }
}
