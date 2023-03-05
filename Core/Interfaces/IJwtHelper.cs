using FitNote_API.Common.Jwt;
using FitNote_API.Core.Dtos.User;
using System;

namespace FitNote_API.Core.Interfaces
{

    public interface IJwtHelper
    {
        public JwtToken GenerateJwtToken(UserDto user);
        public Guid GetUserId();
    }
}
