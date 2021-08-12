﻿using FitnessBooking.Core.Interfaces.Singletons;
using FitnessBooking.Core.Models.Dto.User;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FitnessBooking.Core.Tools
{
    public class JwtTokenUtils : IJwtTokenUtils
    {
        private readonly IConfiguration _configuration;

        public JwtTokenUtils(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string GenerateJwtToken(AuthenticateUserDto authenticateUseruser)
        {
            var key = Encoding.ASCII.GetBytes(_configuration["Environment:ApplicationSecret"]);
            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, authenticateUseruser.Id.ToString()),
                    new Claim(JwtRegisteredClaimNames.Email, authenticateUseruser.Email.ToString()),
                    new Claim("grants", authenticateUseruser.Role.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
                };
            var token = new JwtSecurityToken
                (
                    issuer: string.Empty,
                    audience: string.Empty,
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(7),
                    signingCredentials: new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}