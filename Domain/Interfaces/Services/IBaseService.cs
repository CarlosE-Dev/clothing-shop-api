using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IBaseService<T> where T : BaseEntity
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetById(long id);
        Task<T> Create(T entity);
        Task<T> Update(T entity);
        Task Delete(long id);
    }
}
