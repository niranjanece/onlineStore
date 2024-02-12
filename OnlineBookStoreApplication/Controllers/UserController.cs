using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineBookStoreApplication.Interfaces;
using OnlineBookStoreApplication.Models.DTOs;

namespace OnlineBookStoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("reactApp")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("Register")]
        public ActionResult Register(UserRegisterDTO registerDTO)
        {
            var register = _userService.Register(registerDTO);
            if(register!=null)
            {
                return Ok(register);
            }
            return BadRequest("Could not register");
        }

        [HttpPost("Login")]
        public ActionResult Login(UserDTO userDTO)
        {
            var login = _userService.Login(userDTO);
            if(login!=null)
            {
                return Ok(login);
            }
            return BadRequest("Invalid Credential");
        }
    }
}
