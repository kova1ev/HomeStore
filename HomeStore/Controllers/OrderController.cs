using HomeStore.Models;
using Microsoft.AspNetCore.Mvc;

namespace HomeStore.Controllers
{
    public class OrderController : Controller
    {
        public ViewResult Checkout()
        {
            return View(new Order());
        }

    }
}