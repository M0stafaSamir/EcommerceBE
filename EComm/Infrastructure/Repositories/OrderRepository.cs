using EComm.Domain.Models;
using EComm.Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EComm.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private readonly ApplicationDbContext _context; 
        public OrderRepository(ApplicationDbContext context)
        {
            _context = context; 
        }
        public async Task deleteOrder(int id)
        {
            _context.Orders.Remove(await GetOrder(id));
            await _context.SaveChangesAsync(); 
        }

        public async Task<Order> GetOrder(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<IEnumerable<Order>> GetOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        public async Task setOrder(Order order)
        {
            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();  
        }

        public async Task updateOrder(Order order)
        {
           _context.Orders.Update(order);
            await _context.SaveChangesAsync();

        }
    }
}
