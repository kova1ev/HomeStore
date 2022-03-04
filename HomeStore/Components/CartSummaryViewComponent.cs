using HomeStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeStore.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private readonly Cart cart;

        public CartSummaryViewComponent(Cart cartServise)
        {
            cart = cartServise;
        }

        public IViewComponentResult Invoke()
        {
            return View(cart);
        }

    }
}