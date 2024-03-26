using AuthProject.Models;
using AuthProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace AuthProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private IUserService _userService;

        public UsersController(IUserService userService)
        {
            _userService = userService;
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
    }
}