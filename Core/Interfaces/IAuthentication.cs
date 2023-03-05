using FitNote_API.Common.Jwt;
using FitNote_API.Common.Requests;
using System;
using System.Threading.Tasks;

namespace FitNote_API.Core.Interfaces
{
    public interface IAuthentication
    {
        Task<JwtToken> Login(LoginRequest request);
        Task<Guid> Register(RegisterRequest request);
        Task<bool> ChangePassword(ChangePasswordRequest request);
    }
}
