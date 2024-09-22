using HR_System.BLL.DTOs; // استيراد الـ DTO
using HR_System.BLL.Sarvices.Interfaces;
using HRSystem.BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace HR_Sysytem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly JwtOptions _jwtOptions;

         
        public AuthController(IAuthService authService, IOptions<JwtOptions> jwtOptions)
        {
            _authService = authService;
            _jwtOptions = jwtOptions.Value;   
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var employee = _authService.Authenticate(model.Username, model.Password);

            if (employee == null)
            {
                return Unauthorized(); 
            }

            
            var token = GenerateJwtToken(employee.Username, employee.Roles);
            return Ok(new { token });
        }

         
        private string GenerateJwtToken(string username, List<string> roles)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_jwtOptions.SigningKey);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username)
               
            };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));
            Console.WriteLine("Generated claims: " + string.Join(", ", claims.Select(c => $"{c.Type}: {c.Value}")));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_jwtOptions.Lifetime),  
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _jwtOptions.Issuer,  
                Audience = _jwtOptions.Audience , 
                
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}