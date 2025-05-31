namespace e_Bazaar.Client.ViewModels
{
    public class Product
    {

        public int Id { get; set; }
        public string Name { get; set; } = "";
        public double Price { get; set; }
        public double? OriginalPrice { get; set; }
        public string ImageUrl { get; set; } = "";
        public bool HasDiscount { get; set; }
        public Discount Discount { get; set; }

        public double GetDiscountPrice()
        {
            if (HasDiscount && Discount != null)
            {
                return (Price * Discount.Percentage / 100);
            }
            return 0;
        }
    }
}
