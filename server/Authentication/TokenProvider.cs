using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using shared.Dtos;

public sealed class TokenProvider
{
    private readonly IConfiguration _configuration;

    public TokenProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public string Create(UserDto user)
    {
        string issuer = Environment.GetEnvironmentVariable("JWT_ISSUER");
        string audience = Environment.GetEnvironmentVariable("JWT_AUDIENCE");
        string secretKey = Environment.GetEnvironmentVariable("JWT_SECRET");

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, user.Id.ToString()),
            }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = credentials,
            Issuer = issuer,
            Audience = audience,
        };

        var handler = new JwtSecurityTokenHandler();

        var token = handler.CreateToken(tokenDescriptor);

        return handler.WriteToken(token);
    }
}
