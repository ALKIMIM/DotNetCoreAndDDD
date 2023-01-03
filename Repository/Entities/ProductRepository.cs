using Desafio.Domain.Entities;
using Domain.Enums;
using Domain.Repository;
using Microsoft.EntityFrameworkCore;
using Repository.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Entities
{
    public class ProductRepository : Repository<Product>, IRepositoryProduct
    {
        public ProductRepository(ApplicationDbContext dbContext) : base(dbContext) { }

        public override IEnumerable<Product> Read()
        {
            return _dbSet.Include(x => x.Provider).AsNoTracking().ToList();
        }
        public override Product Read(int id)
        {
            return _dbSet.Include(x => x.Provider).Where(w => w.Id == id).FirstOrDefault();
        }
        public PagerResponse<Product> Read(ProductStateEnum productStateEnum, int totalRows = 10, int pageNumber = 1, string filter = "")
        {
            var query = _dbSet.Include(x => x.Provider).Where(w => w.ProductState == productStateEnum);

            if (!string.IsNullOrEmpty(filter))
                query.Where(w => filter.Contains(w.Description));

            var pageResponse = new PagerResponse<Product>
            {
                Filter = filter,
                TotalRows = query.Count(),
                PageNumber = pageNumber,
                Items = query.Skip(pageNumber - 1).Take(totalRows).ToList()
            };

            return pageResponse;
        }
    }
}
