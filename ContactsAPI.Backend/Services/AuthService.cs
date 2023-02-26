using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ContactsAPI.Backend.Interfaces;
using ContactsAPI.Shared.Models.DbModels;
using ContactsAPI.Shared.Models.General;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace ContactsAPI.Backend.Services;

public class AuthService: IJwtAuthentication
{
    private readonly AppSettings _appSettings;

    public AuthService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    /// <summary>
    /// Create the JWT for a User Login Session
    /// </summary>
    /// <param name="user"></param>
    /// <returns></returns>
    public async Task<(string, DateTime)> Authenticate(User user)
    {
        // 1. Create Security Token Handler
        var tokenHandler = new JwtSecurityTokenHandler();

        // 2. Create Private Key to Encrypted
        var tokenKey = Encoding.ASCII.GetBytes(_appSettings.Secret);

        //3. Create JWT descriptor
        var tokenDescriptor = new SecurityTokenDescriptor()
        {
            Subject = new ClaimsIdentity(
                new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(ClaimTypes.NameIdentifier, user.Id),
                    new Claim(ClaimTypes.Role, nameof(User))
                }),
            Expires = DateTime.UtcNow.AddDays(_appSettings.TokenExpiration),
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
        };
        //4. Create Token
        var token = tokenHandler.CreateToken(tokenDescriptor);

        // 5. Return Token from method
        return (tokenHandler.WriteToken(token), tokenDescriptor.Expires.Value);
    }
}