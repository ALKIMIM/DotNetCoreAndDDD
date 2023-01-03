using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public abstract class Repository<TEntity> : DbContext, IRepository<TEntity> where TEntity : EntityBase, new()
    {
        DbContext _dbContext;
        DbSet<TEntity> _dbSet;

        public Repository(DbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<TEntity>();
        }
        public void Create(TEntity Entity)
        {
            if (Entity.Id == 0)
            {
                _dbSet.Add(Entity);
            }
            else
            {
                _dbContext.Entry(Entity).State = EntityState.Modified;
            }
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var entityToDelete = new TEntity { Id = id };
            _dbSet.Attach(entityToDelete);
            _dbSet.Remove(entityToDelete);
            _dbContext.SaveChanges();
        }

        public IEnumerable<TEntity> Read(int id)
        {
            return _dbSet.Where(w => w.Id == id);
        }

        public IEnumerable<TEntity> Read()
        {
            return _dbSet.AsNoTracking();
        }
    }
}
