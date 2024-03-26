using AuthProject.Models;
using AuthProject.Services;
using AuthProject.Services.HelpersServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AuthProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;
        private IAuthService _authService;

        public UsersController(IUserService userService, IAuthService authService)
        {
            _userService = userService;
            _authService = authService;
        }

        [HttpPost]
        public IActionResult CreateUser(RequestRegisterModel requestRegisterModel)
        {
           var result =  _userService.CreateUser(requestRegisterModel);

           if(result == false)
            {
                return BadRequest(result);
            }
            return StatusCode(201);
    
        }


        [HttpPost("auth")]
        public IActionResult Login(RequestLoginModel requestLoginModel)
        {
          var result =   _authService.UserLogin(requestLoginModel);

           return Ok(result);
        }


        [Authorize("Admin")]
        [HttpGet("test")]
        public IActionResult GetAllUser()
        {
            var result = "crafter devs";

            return Ok(result);
        }
    }
}