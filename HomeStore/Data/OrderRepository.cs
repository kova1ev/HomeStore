using HomeStore.Models;
using Microsoft.EntityFrameworkCore;

namespace HomeStore.Data
{
    public class OrderRepository : IOrderRepository
    {
        private readonly AppDbContext context;
        public OrderRepository(AppDbContext context)
        {
            this.context = context;
        }
        public IQueryable<Order> Orders => context.Orders.Include(o => o.Items).ThenInclude(i => i.Product);

        public void SaveOrder(Order order)
        {
            context.AttachRange(order.Items.Select(i => i.Product));
            if (order.Id == 0)
            {
                context.Orders.Add(order);
            }
            context.SaveChanges();
        }
    }
}