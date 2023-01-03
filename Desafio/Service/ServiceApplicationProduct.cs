using Application.Model;
using Application.Service.Interfaces;
using Desafio.Domain.Entities;
using Domain.Enums;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Application.Service
{
    public class ServiceApplicationProduct : IServiceApplicationProduct
    {
        private readonly IProductService _product;

        public ServiceApplicationProduct(IProductService product)
        {
            _product = product;
        }

        public void DeleteProduct(int id)
        {
            _product.DeleteProduct(id);
        }

        public ProductModel GetProduct(ProductStateEnum productStateEnum, int id)
        {
            var product = _product.GetProduct(productStateEnum, id);

            if (product == null)
                return new ProductModel();

            var model = new ProductModel(product);
            return model;
        }

        public PagerResponse<ProductModel> ListPaginateProducts(ProductStateEnum productStateEnum, int totalRows, int pageNumber, string filter = "")
        {
            var resultModel = new PagerResponse<ProductModel>();
            var paginationList = _product.GetPaginateProducts(productStateEnum, totalRows, pageNumber, filter);
            resultModel.TotalRows = paginationList.TotalRows;
            resultModel.PageNumber = paginationList.PageNumber;
            resultModel.Filter = paginationList.Filter;
            resultModel.Items = paginationList.Items.Select(x => new ProductModel(x)).ToList();
            return resultModel;
        }

        public IEnumerable<ProductModel> ListProduct(ProductStateEnum productStateEnum)
        {
            var list = _product.GetProducts(productStateEnum).ToList();
            List<ProductModel> products = list.Select(x => new ProductModel(x)).ToList();
            return products;
        }

        public void PostProduct(ProductModel productModel)
        {
            _product.CreateProduct(productModel.ExportData());
        }

        public void PutProduct(ProductModel productModel)
        {
            _product.CreateProduct(productModel.ExportData());
        }
    }
}
