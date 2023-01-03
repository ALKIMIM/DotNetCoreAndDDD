using Application.Model;
using Desafio.Domain.Entities;
using Domain.Enums;
using System.Collections.Generic;

namespace Application.Service.Interfaces
{
    public interface IServiceApplicationProduct
    {
        IEnumerable<ProductModel> ListProduct(ProductStateEnum productStateEnum);
        PagerResponse<ProductModel> ListPaginateProducts(ProductStateEnum productStateEnum, int totalRows, int pageNumber, string filter = "");

        ProductModel GetProduct(ProductStateEnum productStateEnum, int id);

        void PostProduct(ProductModel productModel);
        void PutProduct(ProductModel productModel);

        void DeleteProduct(int id);
    }
}
