using Chat_WEBAPP.Context;
using Chat_WEBAPP.Models;
using Chat_WEBAPP.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Chat_WEBAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserAuthController : ControllerBase
    {

        private readonly AuthService _authService;
        private readonly ChatContext _context;

        public UserAuthController(ChatContext chatContext, AuthService authService)
        {
            _context = chatContext;
            _authService = authService;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] User user)
        {
            if (_context.Users.Any(u => u.Email.Equals(user.Email)))
            {
                return BadRequest("Email already exists");
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(user.PasswordHash);

            user.CreatedAt = DateTime.UtcNow;
            user.LastUpdated = DateTime.UtcNow;

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _authService.GenerateJWTToken(user);
            return Ok(new { Token = token });
        }

        [HttpPost("login")]
        public async Task<IActionResult> login([FromBody] User loginUser)
        {
            var user = _context.Users.SingleOrDefault(u => u.Email == loginUser.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(loginUser.PasswordHash, user.PasswordHash))
            {
                return Unauthorized("Invalid credentials");
            }

            var token = _authService.GenerateJWTToken(user);
            return Ok(new { Token = token });

        }
    }
}
