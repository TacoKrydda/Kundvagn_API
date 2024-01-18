using Kundvagn_API.Context;
using Kundvagn_API.Interfaces;
using Kundvagn_API.Models;
using Microsoft.EntityFrameworkCore;

namespace Kundvagn_API.Services
{
    public class OrderService : IOrderService
    {
        private readonly KundvagnContext _context;

        public OrderService(KundvagnContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }
        public async Task<Order> AddOrder(Order order)
        {
            if (order == null)
            {
                throw new ArgumentNullException(nameof(order));
            }
            _context.Orders.Add(order);
            await _context.SaveChangesAsync();
            return order;
        }
    }
}
