using System.Collections.Generic;

namespace HomeStore.Models.ViewModels
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}
