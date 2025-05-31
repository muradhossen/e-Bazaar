namespace e_Bazaar.Client.ViewModels
{
    public class Cart
    {
        public IList<ProductContainer> Items { get; set; } = new List<ProductContainer>();

        public double TotalPrice => Items?.Sum(item => item.GetTotalPrice()) ?? 0;
        public double TotalDiscountPrice => Items?.Sum(item => item.GetTotalDiscountPrice()) ?? 0;

        public int TotalItems => Items?.Count() ?? 0;

        public void AddToCart(Product product)
        {
            var item = Items.FirstOrDefault(i => i.Key.Id == product.Id);

            if (item != null)
            {
                item.AddProduct(product);
            }
            else
            {
                var newItem = new ProductContainer
                {
                    Key = product,
                    Values = new List<Product> { product }
                };
                Items.Add(newItem);
            }
        }

        public void RemoveFromCart(Product product)
        {
            var item = Items.FirstOrDefault(i => i.Key.Id == product.Id);

            if (item == null)
            {
                return;
            }

            if (item.Quantity == 1)
            {
                Items.Remove(item);
                return;
            }

            item.RemoveProduct(product);
        }
    }
}
