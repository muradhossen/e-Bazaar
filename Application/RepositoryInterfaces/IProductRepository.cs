using Application.Common.Pagination;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces;

public interface IProductRepository
{
    Task<IQueryable<Product>> GetAllAsync(PageParam pageParam);
    Task<bool> AddAsync(Product product);
}
