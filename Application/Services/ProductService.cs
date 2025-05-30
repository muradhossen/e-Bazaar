using Application.Common.Mapper;
using Application.Common.Pagination;
using Application.DTOs.Products;
using Application.RepositoryInterfaces;
using Application.ServiceInterfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            this._repository = repository;
        }
        public Task<bool> AddAsync(ProductCreateDto product)
        {

            return _repository.AddAsync(product.ToEntity());
        }

        public async Task<PagedList<ProductDto>> GetAllAsync(PageParam pageParam)
        {
            var query = await _repository.GetAllAsync(pageParam);

             

            return await PagedList<ProductDto>.CreateAsync(query.Select(c => c.ToDto()), pageParam.PageSize, pageParam.PageNumber);
             
        }
    }
}
