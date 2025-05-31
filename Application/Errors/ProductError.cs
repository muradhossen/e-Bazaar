using Application.Common;

namespace Application.Errors;

public class ProductError
{
    public static readonly Error NotFound = new Error(
   "Products.ProductNotFound", "The requested product was not found!");

    public static Error UpdateFailed(string id) => new Error(
        "Products.UpdateFailed", $"Failed to update product with id {id}");

    public static readonly Error CreateFailed = new Error(
        "Products.CreateFailed", "Failed to create product");
     
}
