using Desafio.Domain.Entities;
using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProductService
    {
        IEnumerable<Product> GetProducts(ProductStateEnum productStateEnum);
        Product GetProduct(ProductStateEnum productStateEnum, int id);
        PagerResponse<Product> GetPaginateProducts(ProductStateEnum productStateEnum, int totalRows = 10, int pageNumber = 1, string filter = "");
        void CreateProduct(Product product);
        void DeleteProduct(int id);
    }
}
