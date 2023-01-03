using Application.Model;
using Application.Service.Interfaces;
using Desafio.Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Application.Service
{
    public class ServiceApplicationProduct : IServiceApplicationProduct
    {
        private readonly IProduct _product;

        public ServiceApplicationProduct(IProduct product)
        {
            _product = product;
        }

        public void DeleteProduct(int id)
        {
            _product.DeleteProduct(id);
        }

        public ProductModel GetProduct(int id)
        {
            var product = _product.GetProduct(id);

            if (product == null)
                return new ProductModel();

            ProductModel model = new ProductModel()
            {
                Id = product.Id,
                Description = product.Description,
                ExpirationDate = product.ExpirationDate,
                ManufacturingDate = product.ManufacturingDate,
                ProductState = product.ProductState,
                Provider = new ProviderModel
                {
                    Id = product.Provider.Id,
                    Description = product.Provider.Description,
                    CNPJ = product.Provider.CNPJ
                }
            };

            return model;
        }

        public IEnumerable<ProductModel> ListProduct()
        {
            var list = _product.GetProducts("");
            List<ProductModel> products = new List<ProductModel>();

            foreach (var item in list)
            {
                ProductModel productModel = new ProductModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    ExpirationDate = item.ExpirationDate,
                    ManufacturingDate = item.ManufacturingDate,
                    ProductState = item.ProductState,
                    Provider = new ProviderModel
                    {
                        Id = item.Provider.Id,
                        Description = item.Provider.Description,
                        CNPJ = item.Provider.CNPJ
                    }
                };
                products.Add(productModel);
            }
            return products;
        }

        public void PostProduct(ProductModel productModel)
        {
            Product product = new Product()
            {
                Id = productModel.Id,
                Description = productModel.Description,
                ExpirationDate = productModel.ExpirationDate,
                ManufacturingDate = productModel.ManufacturingDate,
                ProductState = productModel.ProductState,
                ProviderId = productModel.Provider.Id
            };
            _product.CreateProduct(product);
        }

        public void PutProduct(ProductModel productModel)
        {
            Product product = new Product()
            {
                Id = productModel.Id,
                Description = productModel.Description,
                ExpirationDate = productModel.ExpirationDate,
                ManufacturingDate = productModel.ManufacturingDate,
                ProductState = productModel.ProductState,
                ProviderId = productModel.Provider.Id
            };
            _product.CreateProduct(product);
        }
    }
}
