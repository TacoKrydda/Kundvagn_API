using Kundvagn_API.Models;

namespace Kundvagn_API.Interfaces
{
    public interface IOrderService
    {
        Task<Order> AddOrder(Order order);
        Task<IEnumerable<Order>> GetOrders();
    }
}