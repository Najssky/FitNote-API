﻿using FitNote_API.Common.Helpers;
using FitNote_API.Common.Jwt;
using FitNote_API.Core.Dtos.User;
using FitNote_API.Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace FitNote_API.Core.Helpers
{
    public class JwtHelper : IJwtHelper
    {
        private readonly AppSettings _appSettings;
        private string _token;

        public JwtHelper(IOptions<AppSettings> appSettings, IHttpContextAccessor httpContextAccessor)
        {
            _appSettings = appSettings.Value;
            _token = httpContextAccessor.HttpContext.Request.Headers["Authorization"];
        }

        public JwtToken GenerateJwtToken(UserDto user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("User_id", user.User_id.ToString()),
                    new Claim("Email", user.Email ),
                    new Claim("Name", user.Name ),
                    new Claim("Lastname", user.Lastname ),
                    new Claim("Role", user.Role ),
                    new Claim("Phone_number", user.Phone_number)

                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            return new JwtToken()
            {
                AccessToken = tokenHandler.WriteToken(tokenHandler.CreateToken(tokenDescriptor)),
            };
        }

        public Guid GetUserId()
        {
            try
            {
                if (_token.StartsWith("Bearer "))
                {
                    _token = _token["Bearer ".Length..];
                }
                var handler = new JwtSecurityTokenHandler() { SetDefaultTimesOnTokenCreation = false };
                var payload = handler.ReadJwtToken(_token.Trim());
                var result = Guid.TryParse(payload.Payload.Values.First().ToString(), out var userId);
                return result ? userId : Guid.Empty;
            }
            catch (Exception)
            {
                return Guid.Empty;
            }
        }
    }
}
