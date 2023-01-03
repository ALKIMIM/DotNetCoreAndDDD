using Desafio.Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProductService : IProduct
    {
        IRepositoryProduct _repositoryProduct;
        public ProductService(IRepositoryProduct repositoryProduct)
        {
            _repositoryProduct = repositoryProduct;
        }

        public void DeleteProduct(int id)
        {
            _repositoryProduct.Delete(id);
        }

        public Product GetProduct(int id)
        {
            return _repositoryProduct.Read(id);
        }

        public IEnumerable<Product> GetProducts(string filter)
        {
            return _repositoryProduct.Read().ToList();
        }

        public void CreateProduct(Product product)
        {
            _repositoryProduct.Create(product);
        }
    }
}
