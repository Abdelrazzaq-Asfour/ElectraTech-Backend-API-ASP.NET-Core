

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Electratechs.Data;
using Electratechs.Models;

namespace Electratechs.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public AuthController(ApplicationDbContext context) => _context = context;


        // AuthController.cs

        [HttpPut("update/{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] User updatedUser)
        {
       
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new { message = "No Users" });
            }

            user.FullName = updatedUser.FullName;
            user.Email = updatedUser.Email;

     
            if (!string.IsNullOrEmpty(updatedUser.Password))
            {
                user.Password = updatedUser.Password;
            }

            try
            {
                await _context.SaveChangesAsync();
                return Ok(new { message = "updated Done" });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "Stop ", details = ex.Message });
            }
        }

       
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] User loginDto)
        {
            var user = await _context.Users
                .FirstOrDefaultAsync(u => u.Email.ToLower().Trim() == loginDto.Email.ToLower().Trim()
                                     && u.Password.Trim() == loginDto.Password.Trim());

            if (user == null)
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new
            {
                id = user.Id,
                fullName = user.FullName,
                role = user.Role.Trim()
            });
        }

       
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User userDto)
        {
            
            bool userExists = await _context.Users.AnyAsync(u => u.Email.ToLower() == userDto.Email.ToLower());
            if (userExists)
            {
                return BadRequest(new { message = "Register" });
            }

            try
            {
             
                var user = new User
                {
                    FullName = userDto.FullName,
                    Email = userDto.Email,
                    Password = userDto.Password,
                    Role = string.IsNullOrEmpty(userDto.Role) ? "User" : userDto.Role
                };

              
                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                return Ok(new { message = "Save", id = user.Id });
            }
            catch (Exception ex)
            {
               
                return StatusCode(500, new
                {
                    message = "message",
                    details = ex.InnerException?.Message ?? ex.Message
                });
            }
        }
    }
}
