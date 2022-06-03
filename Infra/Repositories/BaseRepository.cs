using Domain.Interfaces.Repositories;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infra.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ShopDbContext _context;
        protected readonly DbSet<T> _dbset;

        public BaseRepository(ShopDbContext context)
        {
            _context = context;
            _dbset = context.Set<T>();
        }

        public async Task<T> Create(T entity)
        {
            try
            {
                _dbset.Add(entity);
                await _context.SaveChangesAsync();

                return entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public async Task Delete(long id)
        {
            var entity = await _dbset.FindAsync(id);

            if (entity == null) {
                throw new Exception("Error! Entity not found!");
            }

            try
            {
                _context.Remove<T>(entity);
                await _context.SaveChangesAsync();

                return;
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbset.AsNoTracking().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public virtual async Task<T> GetById(long id)
        {
            try
            {
                return await _dbset.FindAsync(id);
            }
            catch (Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public async Task<T> Update(T entity)
        {
            try
            {
                _context.Entry(entity).State = EntityState.Modified;
                await _context.SaveChangesAsync();

                return entity;
            }
            catch(Exception e)
            {
                throw new Exception($"{e}");
            }
        }

        public async Task<T> Find(long id)
        {
            return await _dbset.FirstOrDefaultAsync(x=>x.Id == id);
        }
    }
}
