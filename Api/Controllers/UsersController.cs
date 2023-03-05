using FitNote_API.Core.Dtos.User;
using FitNote_API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitNote_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {

        private readonly IUsers _userRepository;

        public UsersController(IUsers UserRepository)
        {
            _userRepository = UserRepository;
        }
        [HttpGet]
        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            return await _userRepository.Get();
        }

        [HttpGet("{User_id}")]
        public async Task<IEnumerable<UserDto>> Get(Guid User_id)
        {
            return await _userRepository.GetById(User_id);
        }
        [HttpDelete("{User_id}")]
        public async Task<bool> Delete(Guid User_id)
        {
            var userToDelete = await _userRepository.Get(User_id);
            if (userToDelete == null)
                return false;

            await _userRepository.Delete(userToDelete.User_id);
            return true;
        }
    }
}
