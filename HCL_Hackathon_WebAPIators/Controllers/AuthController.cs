using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HCL_Hackathon_WebAPIators.DTOs;

namespace HCL_Hackathon_WebAPIators.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        // Points directly to the fallback context tracking class at the root level
        private readonly DbContextMock _context;
        private readonly HCL_Hackathon_WebAPIators.Helpers.JwtHelper _jwtHelper;

        public AuthController(DbContextMock context, HCL_Hackathon_WebAPIators.Helpers.JwtHelper jwtHelper)
        {
            _context = context;
            _jwtHelper = jwtHelper;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            // Duplication verification checkpoint
            if (await _context.Users.AnyAsync(u => u.Email == dto.Email))
            {
                return BadRequest("Email is already taken.");
            }

            // Maps user information securely
            var user = new User
            {
                Email = dto.Email,
                Username = dto.Username,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password),
                Role = "Customer"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            var token = _jwtHelper.GenerateToken(user);
            return Ok(new AuthResponseDto(token, user.Username, user.Role));
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid account credentials.");
            }

            var token = _jwtHelper.GenerateToken(user);
            return Ok(new AuthResponseDto(token, user.Username, user.Role));
        }
    }
}