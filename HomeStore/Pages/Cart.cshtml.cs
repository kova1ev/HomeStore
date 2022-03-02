using Microsoft.AspNetCore.Mvc.RazorPages;
using HomeStore.Models;
using HomeStore.Infrastructure;
using HomeStore.Data;
using Microsoft.AspNetCore.Mvc;

namespace HomeStore.Pages
{
    public class CartModel : PageModel
    {
        private readonly IProductRepository repository;

        public CartModel(IProductRepository repository)
        {
            this.repository = repository;
        }

        public Cart? Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl) {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int Id, string returnUrl)
        {
            Product? product = repository.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
                Cart.AddItem(product, 1);
                HttpContext.Session.SetJson("cart", Cart);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
