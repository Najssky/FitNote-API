using AutoMapper;
using FitNote_API.Core.Dtos.Training;
using FitNote_API.Data.Database;
using FitNote_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FitNote_API.Core.Interfaces;
using System.Linq;
using FitNote_API.Common.Requests.TrainingRequests;

namespace FitNote_API.Core.Repositories
{
    public class TrainingRepository : BaseRepository, ITrainings
    {

        public TrainingRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public async Task<TrainingDto> Create(TrainingAddRequest training)
        {
            var trainingDto = _mapper.Map<TrainingAddRequest, Training>(training);
            trainingDto.Training_id = Guid.NewGuid();
            _context.Trainings.Add(trainingDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<Training, TrainingDto>(trainingDto);
        }
        public async Task Delete(Guid Training_id)
        {
        var trainingToDelete = await _context.Trainings.FindAsync(Training_id);
        _context.Trainings.Remove(trainingToDelete);
        await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<TrainingDto>> Get()
        {
            return await _context.Trainings.Select(training => _mapper.Map<Training, TrainingDto>(training)).ToListAsync();
        }

        public async Task<Training> Get(Guid Training_id)
        {
            return await _context.Trainings.FindAsync(Training_id);
        }
        public async Task<IEnumerable<TrainingDto>> GetByUserId(Guid Training_user_id)
        {
            return await _context.Trainings.Where(x => x.Training_user_id == Training_user_id).Select(training => _mapper.Map<Training, TrainingDto>(training)).ToListAsync();
        }
            public async Task<IEnumerable<TrainingDto>> GetById(Guid Training_id)
        {
            return await _context.Trainings.Where(x => x.Training_id == Training_id).Select(training => _mapper.Map<Training, TrainingDto>(training)).ToListAsync();
        }
        public async Task Update(Training training)
        {
            _context.Entry(training).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

    }
}
