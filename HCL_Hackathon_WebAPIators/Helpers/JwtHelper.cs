using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace HCL_Hackathon_WebAPIators.Helpers
{
    public class JwtHelper
    {
        private readonly IConfiguration _config;
        public JwtHelper(IConfiguration config) => _config = config;

        // Generates an encrypted 8-hour token mapping to your exact user claims structure
        public string GenerateToken(string userId, string email, string username, string role)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            // Grabs your secret key from the central application configuration
            var jwtKey = _config["Jwt:Key"] ?? "SuperSecretHCLHackathonLongKey2026";
            var keyBytes = Encoding.UTF8.GetBytes(jwtKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier, userId),
                    new Claim(ClaimTypes.Email, email),
                    new Claim(ClaimTypes.Name, username),
                    new Claim(ClaimTypes.Role, role)
                }),
                Expires = DateTime.UtcNow.AddHours(8), // Enforces security session bounds
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                )
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}