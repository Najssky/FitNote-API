﻿using AutoMapper;
using FitNote_API.Data.Database;
using System;

namespace FitNote_API.Core.Repositories
{
    public class BaseRepository
    {
        protected readonly AppDbContext _context;
        protected readonly IMapper _mapper;
        public BaseRepository(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

            // public virtual async Task<List<TEntity>> GetByFilterAsync(Expression<Func<TEntity, bool>> predicate)
            {
                //return await Context.Set<TEntity>().Where(predicate).ToListAsync();
            }
        }
    }
}
