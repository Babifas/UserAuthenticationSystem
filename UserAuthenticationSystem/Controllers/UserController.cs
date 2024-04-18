using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserAuthenticationSystem.model;
using UserAuthenticationSystem.services;

namespace UserAuthenticationSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(User user)
        {
            var res=await userService.RegisterUser(user);
            if (!res)
            {
                return BadRequest("user already exist");
            }
            return Ok("Successfully registered user");
        }
        [HttpGet]
        public async Task<IActionResult> Login(string email,string password)
        {
            var user=await userService.Login(email,password);    
            if (user==null)
            {
                return NotFound("user not found");
            }
            return Ok(user);
        }
    }
}
