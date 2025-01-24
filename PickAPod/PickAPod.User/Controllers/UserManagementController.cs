using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace PickAPod.User.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserManagementController : ControllerBase
    {

        private readonly ILogger<UserManagementController> _logger;

        public UserManagementController(ILogger<UserManagementController> logger)
        {
            _logger = logger;
        }

        //for simplicity, using in-memory list as database,
        // to be replaced with a database in local/staging code
        private static List<User> Users = new List<User>();

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] User user)
        {
            if (Users.Any(u => u.Id == user.Id)) 
            {
                return BadRequest("User already exists.");
            }
            Users.Add(user);
            return Ok("User added successfully.");
        }

        [HttpGet]
        public IActionResult GetAllUsers()
        {
            return Ok(Users);
        }

        [HttpDelete]
        public IActionResult DeleteUser([FromQuery] int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            Users.Remove(user);
            return Ok("User deleted successfully.");
        }
    }
}
