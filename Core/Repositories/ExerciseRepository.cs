using AutoMapper;
using FitNote_API.Core.Dtos.Exercise;
using FitNote_API.Data.Database;
using FitNote_API.Data.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
using FitNote_API.Core.Interfaces;
using System.Linq;
using FitNote_API.Common.Requests.ExerciseRequests;
using Microsoft.AspNetCore.Mvc;

namespace FitNote_API.Core.Repositories
{
    public class ExerciseRepository: BaseRepository, IExercises 
    {
        public ExerciseRepository(AppDbContext context, IMapper mapper) : base(context, mapper)
        {
        }


        public async Task<ActionResult<ExerciseDto>> Create(ExerciseAddRequest exercise)
        {
            var exerciseDto = _mapper.Map<ExerciseAddRequest, Exercise>(exercise);
            exerciseDto.Exercise_id = Guid.NewGuid();
            _context.Exercises.Add(exerciseDto);
            await _context.SaveChangesAsync();
            return _mapper.Map<Exercise, ExerciseDto>(exerciseDto);
        }
        public async Task Delete(Guid Exercise_id)
        {
            var exerciseToDelete = await _context.Exercises.FindAsync(Exercise_id);
            _context.Exercises.Remove(exerciseToDelete);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExerciseDto>> Get()
        {
            return await _context.Exercises.Select(exercise => _mapper.Map<Exercise, ExerciseDto>(exercise)).ToListAsync();
        }

        public async Task<Exercise> Get(Guid Exercise_id)
        {
            return await _context.Exercises.FindAsync(Exercise_id);
        }
        public async Task<IEnumerable<ExerciseDto>> GetById(Guid Exercise_id)
        {
            return await _context.Exercises.Where(x => x.Exercise_id == Exercise_id).Select(exercise => _mapper.Map<Exercise, ExerciseDto>(exercise)).ToListAsync();
        }
        public async Task Update(Exercise exercise)
        {
            _context.Entry(exercise).State = EntityState.Modified;
            await _context.SaveChangesAsync();

        }

    }
}

