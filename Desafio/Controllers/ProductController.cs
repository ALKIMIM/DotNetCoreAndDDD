using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio.Domain.Entities;
using Desafio.Data;
using Application.Service.Interfaces;
using Application.Model;
using Domain.Enums;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IServiceApplicationProduct _serviceApplicationProduct;

        public ProductController(IServiceApplicationProduct serviceApplicationProduct)
        {
            _serviceApplicationProduct = serviceApplicationProduct;
        }

        // GET: api/Product
        [HttpGet(template: "productState{productStateEnum}/totalRows/{totalRows}/pageNumber/{pageNumber}/filter{filter}")]
        public ActionResult GetProductsWithPaginator(ProductStateEnum productStateEnum, int totalRows = 10, int pageNumber = 1, string filter = "")
        {
            return Ok(_serviceApplicationProduct.ListPaginateProducts(productStateEnum, totalRows, pageNumber, filter));
        }


        // GET: api/Product
        [HttpGet("{productStateEnum}")]
        public ActionResult GetProducts(ProductStateEnum productStateEnum)
        {
            return Ok(_serviceApplicationProduct.ListProduct(productStateEnum));
        }


        // GET: api/Product/5
        [HttpGet("{productStateEnum}/{id}")]
        public ActionResult GetProduct(ProductStateEnum productStateEnum, int id)
        {
            return Ok(_serviceApplicationProduct.GetProduct(productStateEnum, id));
        }

        // PUT: api/Product/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProduct(ProductModel productModel)
        {
            _serviceApplicationProduct.PutProduct(productModel);
            return Ok();
        }

        // POST: api/Product
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostProduct(ProductModel productModel)
        {
            _serviceApplicationProduct.PostProduct(productModel);

            return Ok();
        }

        // DELETE: api/Product/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            _serviceApplicationProduct.DeleteProduct(id);
            return Ok();
        }
    }
}
