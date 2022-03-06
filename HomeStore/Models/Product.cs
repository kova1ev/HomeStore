using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HomeStore.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Введите имя продукта")]
        public string Name { get; set; } = string.Empty;
        [Required(ErrorMessage = "Введите описсание")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Column(TypeName = "decimal(8,2)")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Введите категорию")]
        public string Category { get; set; } = string.Empty;
    }
}
