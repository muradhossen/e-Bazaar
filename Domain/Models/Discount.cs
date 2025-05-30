using System;

namespace Domain.Models;

public class Discount : BaseEntity<int>
{ 
    public int Percentage { get; set; }
    public double Amount { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public int ProductId { get; set; }
}
