using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Architect.ApplicationCore.Services;
using Architect.Web.Models;
using Microsoft.IdentityModel.Tokens;

namespace Architect.Web.Utils
{
    public class AuthUtils
    {
        private readonly IServiceUnit _serviceUnit;

        public AuthUtils(IServiceUnit serviceUnit) => _serviceUnit = serviceUnit;

        public async Task<AuthenticateResponse> Authenticate(AuthenticateRequest model)
        {
            var user = await _serviceUnit.UserService.FindByUsernameAsync(model.Username);

            if (user == null)
            {
                throw new InvalidOperationException($"User not found. Username: {model.Username}");
            }
            else if (user.Password != model.Password)
            {
                throw new InvalidOperationException($"User password is incorrect. Username: {model.Username}");
            }

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Instance.JwtSecret);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Audience = Settings.Instance.JwtAudience,
                Issuer = Settings.Instance.JwtIssuer,
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.Username)
                }),
                Expires = DateTime.UtcNow.AddMinutes(Settings.Instance.JwtExpiresMinutes),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(securityToken);

            return new AuthenticateResponse(user, token);
        }
    }
}
