using FitNote_API.Core.Dtos.User;
using FitNote_API.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FitNote_API.Core.Interfaces
{
    public interface IUsers
    {
        Task<IEnumerable<UserDto>> GetById(Guid User_id);
        Task<User> Get(Guid User_id);
        Task Update(User user);

        Task Delete(Guid User_id);
        Task<IEnumerable<UserDto>> Get();
    }
}

