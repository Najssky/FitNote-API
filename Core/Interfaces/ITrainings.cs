using FitNote_API.Core.Dtos.Training;
using FitNote_API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Mvc;
using FitNote_API.Common.Requests.TrainingRequests;

namespace FitNote_API.Core.Interfaces
{
    public interface ITrainings
    {
        Task<IEnumerable<TrainingDto>> GetById(Guid Training_id);
        Task<Training> Get(Guid Training_id);
        Task<IEnumerable<TrainingDto>> GetByUserId(Guid Training_user_id);
        Task<IEnumerable<TrainingDto>> GetByUserIdAndDate(Guid Training_user_id, DateTime Training_date);
        Task Update(Training training);

        Task Delete(Guid Training_id);
        Task<IEnumerable<TrainingDto>> Get();
        Task<TrainingDto> Create(TrainingAddRequest training);
    }
}
