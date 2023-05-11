using FitNote_API.Core.Dtos.Exercise;
using FitNote_API.Data.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FitNote_API.Common.Requests.ExerciseRequests;
using Microsoft.AspNetCore.Mvc;

namespace FitNote_API.Core.Interfaces
{
    public interface IExercises
    {
        Task<IEnumerable<ExerciseDto>> GetById(Guid Exercise_id);
        Task<Exercise> Get(Guid Exercise_id);
        Task Update(Exercise exercise);

        Task Delete(Guid Exercise_id);
        Task<IEnumerable<ExerciseDto>> Get();
        Task<ActionResult<ExerciseDto>> Create(ExerciseAddRequest exercise);
    }
}
