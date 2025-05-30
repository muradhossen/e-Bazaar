using Application.Common.Pagination;
using Application.RepositoryInterfaces;
using Domain.Models;
using Infrastructure.Persistances;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        this._dbContext = dbContext;
    }
    public async Task<bool> AddAsync(Product product)
    {
        await _dbContext.Products.AddAsync(product);
       return await _dbContext.SaveChangesAsync() > 0;
    }

    public async Task<IQueryable<Product>> GetAllAsync(PageParam pageParam)
    {
        var query =  _dbContext.Products.AsQueryable()
            .Include(c => c.Discount).AsNoTracking();

        if (!string.IsNullOrWhiteSpace(pageParam.SearchKey))
        {
            string searchKey = pageParam.SearchKey.ToLower().Trim();

            query = query
                .Where(c => c.Name.ToLower().Contains(searchKey));
        }

        query = query.OrderByDescending(c => c.Id);

        return  query;
    }
}
