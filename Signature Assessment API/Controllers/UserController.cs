using Microsoft.AspNetCore.Mvc;
using Signature_Assessment_API.Contracts;
using Signature_Assessment_Models;

namespace Signature_Assessment_API.Controllers
{
    [ApiController]
    [Route("api/{controller}/{action}")]
    public class UserController : ControllerBase
    {

        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpGet("{username}/{password}")]
        [ActionName("Login")]
        public string Login(string username, string password)
        {
            return _userService.Login(username, password).Id.ToString();
        }

        [HttpGet("{id}")]
        [ActionName("GetPersonById")]
        public Person GetPersonById(int id)
        {
            return _userService.GetPersonById(id);
        }
    }
}



