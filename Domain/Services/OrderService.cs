using Domain.Dtos;
using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class OrderService : BaseService<Order>, IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository repository) : base(repository)
        {
            _orderRepository = repository;
        }

        public async Task<IEnumerable<OrderDTO>> GetAllDTOAsync()
        {
            return await _orderRepository.GetAllDTOAsync();
        }

        public async Task<OrderDTO> GetDTOById(long id)
        {
            return await _orderRepository.GetDTOById(id);
        }
    }
}
