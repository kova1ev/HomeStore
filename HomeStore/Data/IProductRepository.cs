using HomeStore.Models;
using System.Linq;

namespace HomeStore.Data
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product product);
        void DeleteProduct(Product product);
        void CreateProduct(Product product);
    }
}