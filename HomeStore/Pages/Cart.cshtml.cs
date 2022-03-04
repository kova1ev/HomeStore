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

        public CartModel(IProductRepository repository, Cart cartService)
        {
            this.repository = repository;
            Cart = cartService;
        }

        public Cart Cart { get; set; }
        public string ReturnUrl { get; set; } = "/";
        public void OnGet(string returnUrl)
        {
            ReturnUrl = returnUrl ?? "/";
        }

        public IActionResult OnPost(int Id, string returnUrl)
        {
            Product? product = repository.Products.FirstOrDefault(p => p.Id == Id);
            if (product != null)
            {
                Cart.AddItem(product, 1);
            }
            return RedirectToPage(new { returnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int Id, string returnUrl)
        {
            Cart.RemoveItem(Cart.Items.First(c => c.Product.Id == Id).Product);
            return RedirectToPage(new { returnUrl = returnUrl });
        }
    }
}
