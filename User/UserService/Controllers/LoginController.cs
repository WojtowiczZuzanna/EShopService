using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using User.Application;
using User.Domain;
using User.Domain.Exceptions;

namespace UserService.Controllers
{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class LoginController : ControllerBase
//    {

//        private ILoginService _loginService;
//        public LoginController(ILoginService loginService)
//        {
//            _loginService = loginService;
//        }


//        [HttpPost]
//        public async Task<ActionResult> Login([FromBody] User.Domain.LoginRequest request)
//        {
//            var result = await _loginService.AuthenticateAsync(request.Username, request.Password);

//            if (!result)
//                return Unauthorized("Invalid username or password");

//            return Ok("Login successful");
//        }


//        [HttpGet]
//        [Authorize]
//        [Authorize(Policy = "AdminOnly")]
//        public IActionResult AdminPage()
//        {
//            return Ok("Dane tylko dla administratora");
//        }
//    }

    [ApiController]
[Route("api/[controller]")]
public class LoginController : ControllerBase
{
    private readonly ILoginService _loginService;

    public LoginController(ILoginService loginService)
    {
        _loginService = loginService;
    }

    [HttpPost("login")]
    public IActionResult Login([FromBody] LoginRequest request)
    {
        try
        {
            var token = _loginService.Login(request.Username, request.Password);
            return Ok(new { Token = token });
        }
        catch (InvalidCredentialsException ex)
        {
            return Unauthorized(new { Message = ex.Message });
        }
    }

    [HttpGet]
    [Authorize]
    [Authorize(Policy = "AdminOnly")]
    public IActionResult AdminPage()
    {
        return Ok("Dane tylko dla administratora");
    }
}

}
