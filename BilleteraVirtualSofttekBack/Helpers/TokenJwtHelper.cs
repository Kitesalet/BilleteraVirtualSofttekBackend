using BilleteraVirtualSofttekBack.Models.Entities;
using BilleteraVirtualSofttekBack.Models.HelperClasses;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BilleteraVirtualSofttekBack.Helpers
{
    /// <summary>
    /// Helper class for generating JWT security tokens.
    /// </summary>
    public class TokenJwtHelper
    {

        private readonly JwtSettings _jwtSettings;

        /// <summary>
        /// A initializer for instantiating TokenJwtHelper classes.
        /// </summary>
        /// <param name="jwtSettings">A IOptions configuration file with JwtSettings data.</param>
        public TokenJwtHelper(IOptions<JwtSettings> jwtSettings)
        {
            _jwtSettings = jwtSettings.Value;
        }

        /// <summary>
        /// Generates a JWT Security Token as a response to the correct login of an user.
        /// </summary>
        /// <param name="client">A client.</param>
        /// <returns>a JWT Token serialized in a string.</returns>
        public string GenerateToken(Client client)
        {
            //An array of claims is created, with the information we need in our JWT
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, _jwtSettings.Subject),
                new Claim("NameIdentifier", client.Id.ToString()),
                new Claim(ClaimTypes.Actor, $"{client.Id}"),
                new Claim(ClaimTypes.Name, client.Name),
                new Claim(ClaimTypes.Email, $"{client.Email}")
            };


            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            //An instance of JwtSecurityToken is created, using claims, expiration time, credentials, audience and issuer
            var securityToken = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddMinutes(_jwtSettings.ExpirationMinutes),
                signingCredentials: credentials
                );

            //Serialize the token to a string
            return new JwtSecurityTokenHandler().WriteToken(securityToken);
        }

    }
}
