using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using HomeStore.Data;
using HomeStore.Models;
using HomeStore.Models.ViewModels;

namespace HomeStore.Controllers
{

    public class HomeController : Controller
    {
        readonly int PageSize = 2;
        private readonly IProductRepository productRepository;

        public HomeController(IProductRepository repository)
        {
            productRepository = repository;
        }


        [Route("{category?}/{page:int?}")]
        [Route("/")]
       // [Route("/{page:int}")]
        public IActionResult Index(string category, int page = 1)
        {
            return View(new ProductListViewModel
            {
                Products = productRepository
                    .Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.Id)
                    .Skip(PageSize * (page - 1))
                    .Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurretnPage = page,
                    TotalItems = category == null
                    ? productRepository.Products.Count()
                    : productRepository.Products.Where(p => p.Category == category).Count(),
                    ItemPerPage = PageSize
                },
                Category = category
            });
        }
    }
}
