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
        [HttpGet]
        public ActionResult GetProducts()
        {
            return Ok(_serviceApplicationProduct.ListProduct());
        }


        // GET: api/Product/5
        [HttpGet("{id}")]
        public ActionResult GetProduct(int id)
        {
            return Ok(_serviceApplicationProduct.GetProduct(id));
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
