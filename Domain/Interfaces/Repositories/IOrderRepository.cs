using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<IEnumerable<OrderDTO>> GetAllDTOAsync();
        Task<OrderDTO> GetDTOById(long id);
    }
}
