using e_Bazaar.Client.ServiceModels;
using e_Bazaar.Client.ViewModels;
using System.Net.Http.Json;
using System.Text.Json;

namespace e_Bazaar.Client.Services
{
    public class ProductService : IProductService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProductService(HttpClient httpClient)
        {
            _httpClient = httpClient;
            _jsonOptions = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };
        }

        public async Task<ProductModel> CreateProductAsync(ProductModel product)
        {

            var request = new ProductCreateModel
            {
                Price = product.Price,
                Slug = product.Slug,
                Name = product.Name,
                ImageUrl = "https://images.unsplash.com/photo-1505740420928-5e560c06d30e?q=80&w=2070&auto=format&fit=crop&ixlib=rb-4.1.0&ixid=M3wxMjA3fDB8MHxwaG90by1wYWdlfHx8fGVufDB8fHx8fA%3D%3D",
                Discount = new DiscountCreateModel
                {
                    Percentage = product.Percentage,
                    StartDate = product.DiscountStart ?? DateTime.UtcNow,
                    EndDate = product.DiscountEnd ?? DateTime.UtcNow.AddDays(30)
                }
            };

            var response = await _httpClient.PostAsJsonAsync("api/Products", request, _jsonOptions);
            response.EnsureSuccessStatusCode();

            var createdProduct = await response.Content.ReadFromJsonAsync<ProductModel>(_jsonOptions);
            return createdProduct ?? product;
        }
    }
}
