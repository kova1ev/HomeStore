namespace HomeStore.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            CartItem? item = Items.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (item == null)
            {
                Items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                item.Quantity += quantity;
            }
        }
        public virtual void RemoveLine(Product product) =>
                    Items.RemoveAll(l => l.Product.Id == product.Id);

        public decimal ComputeTotalValue() =>
            Items.Sum(e => e.Product.Price * e.Quantity);

        public virtual void Clear() => Items.Clear();

    }
}