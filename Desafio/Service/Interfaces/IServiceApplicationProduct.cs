using Application.Model;
using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Application.Service.Interfaces
{
    public interface IServiceApplicationProduct
    {
        IEnumerable<ProductModel> ListProduct();

        ProductModel GetProduct(int id);

        void PostProduct(ProductModel productModel);
        void PutProduct(ProductModel productModel);

        void DeleteProduct(int id);
    }
}
