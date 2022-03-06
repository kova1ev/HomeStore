using System.Linq;
using HomeStore.Models;

namespace HomeStore.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext dbcontext;
        public ProductRepository(AppDbContext context)
        {
            dbcontext = context;
        }
        public IQueryable<Product> Products => dbcontext.Products;

        public void CreateProduct(Product product)
        {
            dbcontext.Add(product);
            dbcontext.SaveChanges();
        }

        public void DeleteProduct(Product product)
        {
            dbcontext.Remove(product);
            dbcontext.SaveChanges();
        }

        public void SaveProduct(Product product)
        {
            dbcontext.SaveChanges();
        }
    }
}