using Domain.Dtos;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Services
{
    public interface IOrderService : IBaseService<Order>
    {
        Task<IEnumerable<OrderDTO>> GetAllDTOAsync();
        Task<OrderDTO> GetDTOById(long id);
    }
}
