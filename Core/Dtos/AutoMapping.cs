using FitNote_API.Common.Requests.ExerciseRequests;
using FitNote_API.Common.Requests.TrainingRequests;
using FitNote_API.Core.Dtos.Exercise;
using FitNote_API.Core.Dtos.Training;
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
            CreateMap<Data.Models.Training, TrainingDto>();
            CreateMap<TrainingDto, Data.Models.Training>();
            CreateMap<TrainingAddRequest, Data.Models.Training>();
            CreateMap<Data.Models.Exercise, ExerciseDto>();
            CreateMap<ExerciseAddRequest, Data.Models.Exercise>();
        }
    }
}
