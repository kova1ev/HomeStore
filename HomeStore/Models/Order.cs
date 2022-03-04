using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace HomeStore.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        [BindNever]
        public ICollection<CartItem> Items { get; set; } = new List<CartItem>();

        [Required(ErrorMessage = "Введите Имя")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Введите Адрес")]
        public string? Line1 { get; set; }
        public string? Line2 { get; set; }
        public string? Line3 { get; set; }

        [Required(ErrorMessage = "Введите город")]
        public string? City { get; set; }

        [Required(ErrorMessage = "Введите регион")]
        public string? Region { get; set; }
        public string? Zip { get; set; }

        [Required(ErrorMessage = "Введите Страну")]
        public string? Country { get; set; }

        public bool GiftWrap { get; set; }

        [BindNever]
        public bool Shipped { get; set; }
    }
}