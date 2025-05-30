using System;

namespace Application.DTOs.Products
{
    public class ProductCreateDto
    {
        public string Name { get; set; }
        public string Slug { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public DiscountCreateDto Discount { get; set; }

    }
    public class DiscountCreateDto
    { 
        public int Percentage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; } 
    }
}
