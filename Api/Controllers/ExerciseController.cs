using FitNote_API.Core.Dtos.Exercise;
using FitNote_API.Core.Interfaces;
using FitNote_API.Data.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FitNote_API.Common.Requests.ExerciseRequests;

namespace FitNote_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExerciseController : ControllerBase
    {

        private readonly IExercises _exerciseRepository;

        public ExerciseController(IExercises ExerciseRepository)
        {
            _exerciseRepository = ExerciseRepository;
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseDto>> PostExercises([FromBody] ExerciseAddRequest exercise)
        {
            return await _exerciseRepository.Create(exercise);
        }

        [HttpPut]
        public async Task<ActionResult> PutExercises(Guid Exercise_id, [FromBody] Exercise exercise)
        {
            if (Exercise_id != exercise.Exercise_id)
            {
                return BadRequest();
            }

            await _exerciseRepository.Update(exercise);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<ExerciseDto>> GetExercises()
        {
            return await _exerciseRepository.Get();
        }

        [HttpGet("{Exercise_id}")]
        public async Task<IEnumerable<ExerciseDto>> Get(Guid Exercise_id)
        {
            return await _exerciseRepository.GetById(Exercise_id);
        }

        [HttpDelete("{Exercise_id}")]
        public async Task<bool> Delete(Guid Exercise_id)
        {
            var exerciseToDelete = await _exerciseRepository.Get(Exercise_id);
            if (exerciseToDelete == null)
                return false;

            await _exerciseRepository.Delete(exerciseToDelete.Exercise_id);
            return true;
        }
    }
}
