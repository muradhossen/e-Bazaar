using Application.DTOs.Products;
using Domain.Models;
using System.Collections.Generic;
using System.Linq;


namespace Application.Common.Mapper
{
    public static class ProductMapper
    {
        #region Product

        public static Product ToEntity(this ProductDto dto)
        {
            if (dto == null) return null;
            return new Domain.Models.Product
            {
                Id = dto.Id,
                Name = dto.Name,
                Slug = dto.Slug,
                Price = dto.Price,
                Discount = dto.Discount?.ToEntity()
            };
        }
        public static ProductDto ToDto(this Product model)
        {
            if (model == null) return null;
            return new ProductDto
            {
                Id = model.Id,
                Name = model.Name,
                Slug = model.Slug,
                OriginalPrice = model.Price,
                Price = model.Discount != null ? model.Price - model.Discount.Amount : model.Price,
                Discount = model.Discount?.ToDto(),
                HasDiscount = model.Discount != null,
                ImageUrl = model.ImageUrl
            };
        }
        public static Product ToEntity(this ProductCreateDto dto)
        {
            if (dto == null) return null;

            Discount discount = null;

            if (dto?.Discount is not null)
            {
                discount = dto.Discount?.ToEntity();
                discount.Amount = dto.Price * (discount.Percentage / 100.0);
            }

            return new Product
            {
                Name = dto.Name,
                Slug = dto.Slug,
                Price = dto.Price,
                Discount = discount,
                ImageUrl = dto.ImageUrl
            };
        }
        public static IEnumerable<ProductDto> ToDto(this IEnumerable<Product> models)
        {
            return models?.Select(m => m.ToDto()) ?? Enumerable.Empty<ProductDto>();
        }

        #endregion


        #region Discount

        public static Discount ToEntity(this DiscountDto dto)
        {
            if (dto == null) return null;
            return new Discount
            {
                Id = dto.Id,
                Percentage = dto.Percentage,
                Amount = dto.Amount,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
                ProductId = dto.ProductId
            };
        }
        public static DiscountDto ToDto(this Discount model)
        {
            if (model == null) return null;
            return new DiscountDto
            {
                Id = model.Id,
                Percentage = model.Percentage,
                Amount = model.Amount,
                EndDate = model.EndDate,
                StartDate = model.StartDate,
                ProductId = model.ProductId
            };
        }
        public static Discount ToEntity(this DiscountCreateDto dto)
        {
            if (dto == null) return null;
            return new Discount
            {
                Percentage = dto.Percentage,
                //Amount = dto.Amount,
                EndDate = dto.EndDate,
                StartDate = dto.StartDate,
            };
        }

        #endregion


    }
}
