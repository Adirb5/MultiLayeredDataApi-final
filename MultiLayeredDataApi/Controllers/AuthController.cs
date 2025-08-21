using Microsoft.AspNetCore.Mvc;
using MultiLayeredDataApi.DTOs;
using MultiLayeredDataApi.Infrastructure.Security;

namespace MultiLayeredDataApi.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController : ControllerBase
    {
        private readonly JwtService _jwtService;

        public AuthController(JwtService jwtService) => _jwtService = jwtService;

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequestDto dto)
        {
            if (dto.Username == "admin" && dto.Password == "1234")
                return Ok(new LoginResponseDto { Token = _jwtService.GenerateToken("admin", "Admin") });

            if (dto.Username == "user" && dto.Password == "1234")
                return Ok(new LoginResponseDto { Token = _jwtService.GenerateToken("user", "User") });

            return Unauthorized();
        }
    }

}
