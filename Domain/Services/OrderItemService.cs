using Domain.Interfaces.Repositories;
using Domain.Interfaces.Services;
using Domain.Models;

namespace Domain.Services
{

    public class OrderItemService : BaseService<OrderItem>, IOrderItemService
    {
        public OrderItemService(IOrderItemRepository repository) : base(repository)
        {
        }
    }
}
