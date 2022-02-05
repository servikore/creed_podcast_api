using Creed.Podcast.Domain.Common;
using Creed.Podcast.Domain.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Creed.Podcast.Services
{
    public class SecurityService : ISecurityService
    {
        private readonly SecuritySettings securitySettings;

        public SecurityService(IOptions<SecuritySettings> securitySettings)
        {
            this.securitySettings = securitySettings.Value;
        }

        public AccessToken AuthenticateUser(string username, string password)
        {
            if (username != "admin" || password != "admin")
                return null;

            return GenerateToken(username);
        }

        /// <summary>
        /// Creates JW Token using HmacSha256
        /// </summary>
        /// <param name="username">owner of the token</param>
        /// <returns></returns>
        private AccessToken GenerateToken(string username)
        {
            var secretKey = Encoding.ASCII.GetBytes(securitySettings.TokenSecretKey);
            var expires = DateTime.UtcNow.AddMinutes(securitySettings.TokenDuration);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                //More claims could be added, like role or email
                Subject = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.Name, username) }),
                Expires = expires,
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtoken = tokenHandler.WriteToken(token);

            return new AccessToken(jwtoken,expires);
        }

    }
}
