using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Dashboard.Utility
{
    /// <summary>
    /// Jwt class with primary constructor y
    /// </summary>
    /// <param name="configuration"></param>
    public class Jwt(IConfiguration configuration)
    {
        private readonly string _secret = configuration["Jwt:Secret"]?? throw new InvalidOperationException("JWT 'Secret' not found.");


        /// <summary>
        /// Generate JWT token with claim idenetity 
        /// </summary>
        /// <param name="identity"></param>
        /// <returns></returns>
        public string GenerateJwtToken( ClaimsIdentity identity )
        {
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_secret));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                claims:identity.Claims,
                expires: DateTime.Now.AddMinutes(Convert.ToDouble(configuration["Jwt:ExpirationTime"])),
                signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        /// <summary>
        /// Validate and return token principal
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        /// <exception cref="SecurityTokenException"></exception>
        public ClaimsPrincipal? ValidateJwtToken(string token)
        {
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_secret);

                var validationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false, 
                    ValidateAudience = false, 
                    ClockSkew = TimeSpan.Zero 
                };

                var principal = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                if (validatedToken is JwtSecurityToken jwtToken &&
                    jwtToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                {
                    return principal;
                }

                throw new SecurityTokenException("Invalid token");
            }
            catch (Exception ex)
            {
                ex.LogException();
                Console.WriteLine(ex.ToString());
                return null;
            }
        }

    }
}
