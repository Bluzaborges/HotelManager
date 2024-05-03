using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;

namespace HotelManager.Security.Authentication
{
    public static class Token
    {
        public readonly static string SECRET_KEY = "2&w7oeCJY#iAw6%Xkp&MC@k4vGLp$y^8";

        public static string GetJwtToken(Guid idUser, string name, string email, int role)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim("UserId", idUser.ToString()),
                new Claim(ClaimTypes.Name, name),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, role.ToString())
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(SECRET_KEY)),
                                                                              SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                NotBefore = DateTime.Now,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);

            return jwtTokenHandler.WriteToken(token);
        }
    }
}