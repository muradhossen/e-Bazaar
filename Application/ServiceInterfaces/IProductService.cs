using Application.Common.Pagination;
using Application.DTOs.Products;
using System.Threading.Tasks;

namespace Application.ServiceInterfaces
{
    public interface IProductService
    {
        /// <summary>
        /// Retrieves all products with pagination.
        /// </summary>
        /// <param name="pageParam">The pagination parameters.</param>
        /// <returns>A task that represents the asynchronous operation, containing a paginated list of products.</returns>
        Task<PagedList<ProductDto>> GetAllAsync(PageParam pageParam);
        /// <summary>
        /// Adds a new product.
        /// </summary>
        /// <param name="product">The product to add.</param>
        /// <returns>A task that represents the asynchronous operation.</returns>
        Task<bool> AddAsync(ProductCreateDto product);
    }
}
