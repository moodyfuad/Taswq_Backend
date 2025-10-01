using Microsoft.AspNetCore.Mvc;

namespace Taswq_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly string username = "m";
        private readonly string password = "p";

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "Person")]
        public Person Get()
        {
            return new Person(){ username= username, password=password };
        }
        [HttpPost]
        public LoginResult login(Person person) {
            if (person.username != username)
            {
                return new LoginResult(false, "wrong username!");
            }
            if (person.password != password)
            {
                return new LoginResult(false, "wrong password!");
            }
            return new LoginResult(true, "");

        }
    }
    public class LoginResult
    {
        public LoginResult(bool success, string message)
        {
            Success = success;
            Message = message;
        }

        public bool Success { get; set; }
        public string Message { get; set; }
    }
}
