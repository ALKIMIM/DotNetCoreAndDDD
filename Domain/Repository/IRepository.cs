using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Create(TEntity Entity);
        TEntity Read(int id);
        void Delete(int id);
        IEnumerable<TEntity> Read();
    }
}
