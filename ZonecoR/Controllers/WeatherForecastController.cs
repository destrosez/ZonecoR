using Microsoft.AspNetCore.Mvc;

namespace ZonecoR.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private static List<string> _summaries = new()
    {   
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };
    
    [HttpGet]
    public IActionResult GetAll(int? sortStrategy)
    {
        if (sortStrategy is null)
        {
            return Ok(_summaries);
        }

        else if (sortStrategy == 1)
        {
            var sorted = new List<string>(_summaries);
            sorted.Sort();
            return Ok(sorted);
        }

        else if (sortStrategy == -1)
        {
            var sorted = new List<string>(_summaries);
            sorted.Sort();
            sorted.Reverse();
            return Ok(sorted);
        }
        
        return BadRequest("Incorrect value param sortStrategy");
    }

    [HttpGet("{index}")]
    public IActionResult GetByIndex(int? index)
    {
        if (index is null || index < 0 || index >= _summaries.Count)
        {
            return BadRequest("Incorrect value param index");
        }


        return Ok(_summaries[index.Value]);
    }

    [HttpGet("find-by-name")]
    public IActionResult GetCountByName(string? name)
    {
        var count = 0;
        
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Incorrect value param name");
        }

        foreach (var summary in _summaries)
        {
            if (summary == name)
            {
                count++;
            }
        }
        return Ok(count);
    }

    [HttpPost]
    public IActionResult Add(string? name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return BadRequest("Incorrect value param name");
        }
        
        _summaries.Add(name);
        return Ok();
    }

    [HttpPut]
    public IActionResult Update(int? index, string? name)
    {
        if (index is null || string.IsNullOrEmpty(name) || index < 0 || index >= _summaries.Count)
        {
            return BadRequest("Incorrect value param name or index");
        }
        
        _summaries[index.Value] = name;
        return Ok();
    }

    [HttpDelete]
    public IActionResult Delete(int? index)
    {
        if (index is null || index < 0 || index >= _summaries.Count)
        {
            return BadRequest("Incorrect value param index");
        }

        _summaries.RemoveAt(index.Value);
        return Ok();
    }
}
