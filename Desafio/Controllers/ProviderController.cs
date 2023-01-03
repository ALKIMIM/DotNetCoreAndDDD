using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Desafio.Data;
using Desafio.Domain.Entities;
using Application.Model;
using Application.Service.Interfaces;

namespace Desafio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProviderController : ControllerBase
    {
        private IServiceApplicationProvider _serviceApplicationProvider;

        public ProviderController(IServiceApplicationProvider serviceApplicationProvider)
        {
            _serviceApplicationProvider = serviceApplicationProvider;
        }

        // GET: api/Provider
        [HttpGet]
        public ActionResult GetProvider()
        {
            return Ok(_serviceApplicationProvider.ListProvider());
        }


        // GET: api/Provider/5
        [HttpGet("{id}")]
        public ActionResult GetProvider(int id)
        {
            return Ok(_serviceApplicationProvider.GetProvider(id));
        }

        // PUT: api/Provider/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public ActionResult PutProvider(ProviderModel providerModel)
        {
            _serviceApplicationProvider.PutProvider(providerModel);
            return Ok();
        }

        // POST: api/Provider
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public ActionResult PostProvider(ProviderModel providerModel)
        {
            _serviceApplicationProvider.PostProvider(providerModel);

            return Ok();
        }

        // DELETE: api/Provider/5
        [HttpDelete("{id}")]
        public ActionResult DeleteProvider(int id)
        {
            _serviceApplicationProvider.DeleteProvider(id);
            return Ok();
        }
    }
}
