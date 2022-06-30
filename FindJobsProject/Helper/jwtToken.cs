using FindJobsProject.ViewModels;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FindJobsProject.Helpers
{
    public class jwtToken
    {
        private readonly AppSettings _app;
        public jwtToken(IOptionsMonitor<AppSettings> app)
        {
            _app = app.CurrentValue;
        }
        public string GenerateToken(VMUserLogin login)
        {
            var jwtTokenHandle = new JwtSecurityTokenHandler();
            var secrectKeyBytes = Encoding.ASCII.GetBytes(_app.SecretKey);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Jti , Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat , DateTime.UtcNow.ToString()),
                    new Claim(ClaimTypes.Email, login.Email),
                    
                    new Claim("IDToken" , Guid.NewGuid().ToString())
                }),
                Issuer = login.Email,
                Expires = DateTime.UtcNow.AddMonths(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey
                (secrectKeyBytes), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = jwtTokenHandle.CreateToken(tokenDescription);
            return jwtTokenHandle.WriteToken(token);
        }
        
        public JwtSecurityToken Verify(string jwt)
        {
            var tokenHandle = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_app.SecretKey);



            tokenHandle.ValidateToken(jwt, new TokenValidationParameters
            {
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuerSigningKey = true,

                RequireExpirationTime = true
                
               
            }, out SecurityToken validatedToken);

            return (JwtSecurityToken)validatedToken;
        }
    }
}
