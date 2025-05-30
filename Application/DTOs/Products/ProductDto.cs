using Domain.Models;

namespace Application.DTOs.Products;

public record ProductDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
    public double Price { get; set; }
    public DiscountDto Discount { get; set; }
}
