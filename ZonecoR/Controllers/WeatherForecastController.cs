using Microsoft.AspNetCore.Mvc;

namespace ZonecoR.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<string> Summaries = new()
    {   
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(ILogger<WeatherForecastController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public List<string> Get()
    {
        return Summaries;
    }

    [HttpPost]
    public IActionResult Add(string name)
    {
        Summaries.Add(name);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update (int index, string name)
    {
        Summaries[index] = name;
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int index)
    {
        Summaries.RemoveAt(index);
        return Ok();
    }
}
