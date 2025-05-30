using Domain.Models;
using System;

namespace Application.DTOs.Products;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public double Price { get; set; }
    public double? OriginalPrice { get; set; }
    public bool HasDiscount { get; set; }
    public string ImageUrl { get; set; }
    //public double? DiscountPrice
    //{
    //    get
    //    {
    //        if (Discount != null && Discount.StartDate <= DateTime.Now && Discount.EndDate >= DateTime.Now)
    //        {
    //            return Price - Discount.Amount;
    //        }
    //        return null;
    //    }
    //}
    public DiscountDto Discount { get; set; }
}
