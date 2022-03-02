namespace HomeStore.Models
{
    public class Cart
    {
        public List<CartItem> itemCollection = new List<CartItem>();
        public virtual void AddItem(Product product, int quantity)
        {
            CartItem? item = itemCollection.Where(p => p.Product.Id == product.Id).FirstOrDefault();
            if (item == null)
            {
                itemCollection.Add(new CartItem { Product = product, Quantity = quantity });
            }
            else
            {
                item.Quantity += quantity;
            }
        }

        public virtual void RemoveItem(Product product)
        {
            itemCollection.RemoveAll(i => i.Product.Id == product.Id);
        }

        public virtual decimal ComputeTotalValue()
        {
            return itemCollection.Sum(e => e.Product.Price * e.Quantity);
        }

        public virtual void Clear()
        {
            itemCollection.Clear();
        }

        public virtual IEnumerable<CartItem> Items => itemCollection;

    }
}