using Desafio.Domain.Entities;
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
    }
}
