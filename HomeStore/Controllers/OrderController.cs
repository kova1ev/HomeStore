using HomeStore.Models;
using Microsoft.AspNetCore.Mvc;
using HomeStore.Data;

namespace HomeStore.Controllers
{
    public class OrderController : Controller
    {
        private readonly IOrderRepository orderRepository;
        private readonly Cart cart;

        public OrderController(IOrderRepository repository, Cart cart)
        {
            this.cart = cart;
            orderRepository = repository;
        }
        public ViewResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public IActionResult Checkout(Order order)
        {
            if (cart.Items.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста!");
            }
            if (ModelState.IsValid)
            {
                order.Items = cart.Items.ToArray();
                orderRepository.SaveOrder(order);
                cart.Clear();
                return RedirectToPage("/Completed", new { orderId = order.Id });
            }
            else
                return View();

        }
    }
}