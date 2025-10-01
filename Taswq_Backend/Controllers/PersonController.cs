using Microsoft.AspNetCore.Mvc;

namespace Taswq_Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
      

        private readonly string username = "m";
        private readonly string password = "p";

        private readonly ILogger<PersonController> _logger;

        public PersonController(ILogger<PersonController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Person Get()
        {
            return new Person(){ username= username, password=password };
        }
        [HttpGet("test")]
        public Person GetTest()
        {
            return new Person(){ username= username, password=password };
        }
        [HttpPost("login")]
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
