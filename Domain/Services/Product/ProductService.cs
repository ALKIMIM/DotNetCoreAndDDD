using Desafio.Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProductService
    {
        IRepositoryProduct _repositoryProduct;
        public ProductService(IRepositoryProduct repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public void DeleteProduct(int id)
        {
            var product = _repositoryProduct.Read(id);
            product.ProductState = Enums.ProductStateEnum.Inactive;
            _repositoryProduct.Create(product);
        }

        public Product GetProduct(ProductStateEnum productStateEnum, int id)
        {
            return _repositoryProduct.Read(id);
        }

        public IEnumerable<Product> GetProducts(ProductStateEnum productStateEnum)
        {
            return _repositoryProduct.Read().Where(w => w.ProductState == productStateEnum).ToList();
        }

        public void CreateProduct(Product product)
        {
            _repositoryProduct.Create(product);
        }

        public PagerResponse<Product> GetPaginateProducts(ProductStateEnum productStateEnum, int totalRows = 10, int pageNumber = 1, string filter = "")
        {
            return _repositoryProduct.Read(productStateEnum, totalRows, pageNumber, filter);
        }
    }
}
