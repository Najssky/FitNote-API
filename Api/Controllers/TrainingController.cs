using FitNote_API.Core.Dtos.Training;
using FitNote_API.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FitNote_API.Data.Models;
using FitNote_API.Common.Requests.TrainingRequests;

namespace FitNote_API.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrainingController : ControllerBase
    {

        private readonly ITrainings _trainingRepository;

        public TrainingController(ITrainings TrainingRepository)
        {
            _trainingRepository = TrainingRepository;
        }

        [HttpPost]
        public async Task<ActionResult<TrainingDto>> PostTrainings([FromBody] TrainingAddRequest training)
        {
            return await _trainingRepository.Create(training);
        }

        [HttpPut]
        public async Task<ActionResult> PutTrainings(Guid Training_id, [FromBody] Training training)
        {
            if (Training_id != training.Training_id)
            {
                return BadRequest();
            }

            await _trainingRepository.Update(training);

            return NoContent();
        }

        [HttpGet]
        public async Task<IEnumerable<TrainingDto>> GetTrainings()
        {
            return await _trainingRepository.Get();
        }

        [HttpGet("{Training_id}")]
        public async Task<IEnumerable<TrainingDto>> Get(Guid Training_id)
        {
            return await _trainingRepository.GetById(Training_id);
        }
        [HttpGet("byUserId/{Training_user_id}")]
        public async Task<IEnumerable<TrainingDto>> GetByUserId(Guid Training_user_id)
        {
            return await _trainingRepository.GetByUserId(Training_user_id);
        }
        [HttpDelete("{Training_id}")]
        public async Task<bool> Delete(Guid Training_id)
        {
            var trainingToDelete = await _trainingRepository.Get(Training_id);
            if (trainingToDelete == null)
                return false;

            await _trainingRepository.Delete(trainingToDelete.Training_id);
            return true;
        }
    }
}
