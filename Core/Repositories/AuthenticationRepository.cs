using FitNote_API.Common.CustomExceptions;
using FitNote_API.Common.Jwt;
using FitNote_API.Core.Interfaces;
using FitNote_API.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Net;
using System;
using AutoMapper;
using FitNote_API.Core.Dtos.User;
using System.Threading.Tasks;
using FitNote_API.Data.Database;
using FitNote_API.Common.Requests.Authentication;

namespace FitNote_API.Core.Repositories
{
    public class AuthenticationRepository : BaseRepository, IAuthentication
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly PasswordHasher<User> _passwordHasher;
        public AuthenticationRepository(AppDbContext context, IMapper mapper, IJwtHelper jwtHelper) : base(context, mapper)
        {
            _jwtHelper = jwtHelper;
            _passwordHasher = new PasswordHasher<User>();
        }

        public async Task<bool> ChangePassword(ChangePasswordRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Token == request.Token).ConfigureAwait(false);
            if (user != null)
            {
                user.Password = _passwordHasher.HashPassword(user, request.NewPassword);
                user.Token = Guid.Empty;
                await _context.SaveChangesAsync().ConfigureAwait(false);
                return true;
            }
            throw new ServiceLayerException(HttpStatusCode.NotFound, "Token expired");
        }

        public async Task<JwtToken> Login(LoginRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Email == request.Email).ConfigureAwait(false);
            if (user == null)
                throw new ServiceLayerException(HttpStatusCode.NotFound, "User not found");

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, request.Password);
            if (result == PasswordVerificationResult.Success)
                return _jwtHelper.GenerateJwtToken(_mapper.Map<User, UserDto>(user));

            throw new ServiceLayerException(HttpStatusCode.Unauthorized, "The email or password is incorrect");
        }

        public async Task<Guid> Register(RegisterRequest request)
        {
            var user = await _context.Users.FirstOrDefaultAsync(i => i.Email == request.Email).ConfigureAwait(false);
            if (user == null)
            {
                var userResult = await _context.Users.AddAsync(new User()
                {
                    Email = request.Email,
                    Name = request.Name,
                    Lastname = request.Lastname,
                    Phone_number = request.Phone_number,
                    Token = Guid.Empty,
                }).ConfigureAwait(false);

                userResult.Entity.Password = _passwordHasher.HashPassword(userResult.Entity, request.Password);

                await _context.SaveChangesAsync().ConfigureAwait(false);
                return userResult.Entity.User_id;
            }
            throw new ServiceLayerException(HttpStatusCode.BadRequest, "Email is already used");
        }
    }
}
