using e_Bazaar.Client.ViewModels;

namespace e_Bazaar.Client.Services
{
    public interface IProductService
    {
        Task<ProductModel> CreateProductAsync(ProductModel product);
    }
}
