namespace Domain.Models;

public class Product : BaseEntity<int>
{ 
    public string Name { get; set; }
    public string Slug { get; set; }
    public double Price { get; set; }
    public Discount Discount { get; set; } 
}
