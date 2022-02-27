using HomeStore.Models;
using System.Linq;

namespace HomeStore.Data
{
    public interface IProductRepository
    {
        IQueryable<Product> Products {get;}
    }
}