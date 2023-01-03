using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProduct
    {
        IEnumerable<Product> GetProducts(string filter);
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void DeleteProduct(int id);
    }
}
