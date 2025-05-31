namespace e_Bazaar.Client.ServiceModels
{ 
    public class ProductCreateModel
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DiscountCreateModel Discount { get; set; }

    }
    public class DiscountCreateModel
    {
        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
