namespace HomeStore.Models
{
    public class Cart
    {
        public List<CartItem> Items { get; set; } = new List<CartItem>();

        public void AddItem(Product product, int quantity)
        {
            CartItem? line = Items
                .Where(p => p.Product.Id == product.Id)
                .FirstOrDefault();

            if (line == null)
            {
                Items.Add(new CartItem
                {
                    Product = product,
                    Quantity = quantity
                });
            }
            else
            {
                line.Quantity += quantity;
            }
        }

        public void RemoveLine(Product product) =>
            Items.RemoveAll(l => l.Product.Id == product.Id);

        public decimal ComputeTotalValue() =>
            Items.Sum(e => e.Product.Price * e.Quantity);

        public void Clear() => Items.Clear();
    }
}