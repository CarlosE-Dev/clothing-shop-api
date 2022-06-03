using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class BaseService<T> : IBaseService<T> where T : BaseEntity
    {
        private readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<T> Create(T entity)
        {
            return await _repository.Create(entity);
        }

        public async Task Delete(long id)
        {
            await _repository.Delete(id);
            return;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<T> GetById(long id)
        {
            return await _repository.GetById(id);
        }

        public async Task<T> Update(T entity)
        {
            return await _repository.Update(entity);
        }
    }
}
