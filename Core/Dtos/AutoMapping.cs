using FitNote_API.Core.Dtos.User;
using System;

namespace FitNote_API.Core.Dtos
{
    public class AutoMapping : AutoMapper.Profile
    {
        public AutoMapping()
        {
            CreateMap<Data.Models.User, UserDto>();
            CreateMap<string, Guid>();
        }
    }
}
