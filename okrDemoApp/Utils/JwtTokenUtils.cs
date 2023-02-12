using System;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using okrDemoApp.Models;

namespace okrDemoApp.Utils
{
	public class JwtTokenUtils : IJwtTokenUtils
    {
        private readonly IConfiguration _configuration;

        public JwtTokenUtils(IConfiguration configuration)
		{
            _configuration = configuration;
		}

        public string CreateToken(User user)
        {
            try
            {
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Email,user.email),
                    new Claim(ClaimTypes.Name,user.id.ToString())
                };

                var tokenKey = _configuration.GetValue<string>("Token:Key");

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(tokenKey));

                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: cred
                    );

                var Jwt = new JwtSecurityTokenHandler().WriteToken(token);

                return Jwt;
            }

            catch
            {
                throw;
            }

        }
    }
}

