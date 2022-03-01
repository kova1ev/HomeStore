using HomeStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace HomeStore.Components
{
    public class NavigationMenuViewComponent : ViewComponent
    {
        private readonly IProductRepository productRepository;

        public NavigationMenuViewComponent(IProductRepository repository)
        {
            productRepository = repository;
        }

        public IViewComponentResult Invoke()
        {
            ViewBag.SelectedCategory = RouteData?.Values["category"];
            return View(productRepository.Products.Select(p => p.Category).Distinct().OrderBy(c => c));
        }

    }
}