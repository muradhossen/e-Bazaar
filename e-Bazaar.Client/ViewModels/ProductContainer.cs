namespace e_Bazaar.Client.ViewModels
{
    public class ProductContainer
    {
        public Product Key { get; set; }
        public IList<Product> Values { get; set; } = new List<Product>();
        public int Quantity { get => Values?.Count() ?? 0; }

        public double GetDiscountPrice()
        {
            if (Key.HasDiscount && Key.Discount != null)
            {
                return (Key.Price * Key.Discount.Percentage / 100);
            }
            return 0;
        }

 

        public double GetTotalPrice()
        {
            if (Values == null || !Values.Any())
            {
                return 0;
            }
            return Values.Sum(v => v.Price);
        }
        public double GetTotalDiscountPrice()
        {
            if (Values == null || !Values.Any())
            {
                return 0;
            }
            return Values.Sum(v => v.GetDiscountPrice());
        }

        public void AddProduct(Product product)
        {
            Key = product;
            Values.Add(product);
        }

        public void RemoveProduct(Product product)
        {
            Values.Remove(product);            
        }
    }
}
