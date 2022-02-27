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
    }
}