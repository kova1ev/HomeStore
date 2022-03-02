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

        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
            Cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost()
        {
            return null;
        }
    }
}
