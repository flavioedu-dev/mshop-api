using Microsoft.AspNetCore.Mvc;
using mshop_api.Models;
using mshop_api.Services.Interfaces;

namespace mshop_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _users;

        public UserController(IUserServices users)
        {
            _users = users;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            try
            {
                var users = await _users.GetUsers();
                if (users == null) throw new Exception("Error finding users.");

                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<User>>> GetUserById(int id)
        {
            try
            {
                var user = await _users.GetUserById(id);
                if (user == null) throw new Exception("Error finding user.");

                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<User>> AddUser(User userData)
        {
            try
            {
                var user = await _users.CreateUser(userData);
                if (user == null) throw new Exception("Error creating user.");

                return CreatedAtAction(nameof(GetUsers), user);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, User userData)
        {
            try
            {
                if(id != userData.Id) return NotFound();

                bool userUpdated = await _users.UpdateUser(userData);
                if (!userUpdated) throw new Exception("Error updating user.");

                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            try
            {
                bool userDeleted = await _users.DeleteUser(id);
                if (!userDeleted) throw new Exception("Error deleting user.");

                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
