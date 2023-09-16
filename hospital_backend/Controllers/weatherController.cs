using Microsoft.AspNetCore.Mvc;

namespace hospital_backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class weatherController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<weatherController> _logger;

        public weatherController(ILogger<weatherController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Getweather")]
        public IEnumerable<weather> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new weather
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            })
            .ToArray();
        }
    }
}