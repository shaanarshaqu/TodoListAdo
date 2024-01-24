using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TodoListAdo.Models;

namespace TodoListAdo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUsers _usersData;
        public UsersController(IUsers usersData) 
        {
            _usersData=usersData;
        }






        [HttpGet(Name = "GetData")]
        public IActionResult Get()
        {
            return Ok(_usersData.DisplayUsers());
        }
    }
}
