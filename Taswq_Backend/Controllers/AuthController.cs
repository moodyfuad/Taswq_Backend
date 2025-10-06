using Microsoft.AspNetCore.Mvc;

namespace Taswq.Api.Controllers
{
    public class AuthController : Controller
    {
        private readonly string _code = "1234";

        [HttpPost("Login")]
        public ActionResult Login([FromForm] string phoneNumber)
        {

            return Ok(new { success = true, message = $"the code is {_code}" });
        }
        [HttpPost("Login/CodeConfirmation")]
        public ActionResult CodeConfirmation([FromForm] string code)
        {
            if (code == _code)
            {
                return Ok(new { success = true, message = $"Login Succeed" });
            }
            else
            {
                return Ok(new { success = false, message = $"the code you entered is not correct" });
            }
        }

    }
}
