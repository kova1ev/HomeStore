using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using HomeStore.Data;
using HomeStore.Models;

namespace HomeStore.Controllers
{
    public class HomeController : Controller
    {
        readonly int PageSize = 4;
        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository repository)
        {
            productRepository = repository;
        }

        public IActionResult Index(int page = 1)
        {
            return View(productRepository.Products.OrderBy(p=>p.Id).Skip(PageSize*(page-1)).Take(PageSize));
        }
    }
}
