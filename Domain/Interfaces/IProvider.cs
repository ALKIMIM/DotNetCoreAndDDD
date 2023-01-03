using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IProvider
    {
        IEnumerable<Provider> GetProvider(string filter);
        Provider GetProvider(int id);
        void CreateProvider(Provider provider);
        void DeleteProvider(int id);
    }
}
