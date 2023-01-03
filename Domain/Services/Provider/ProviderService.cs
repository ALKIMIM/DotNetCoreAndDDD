using Desafio.Domain.Entities;
using Domain.Interfaces;
using Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Services
{
    public class ProviderService : IProviderService
    {
        IRepositoryProvider _repositoryProvider;
        public ProviderService(IRepositoryProvider repositoryProvider)
        {
            _repositoryProvider = repositoryProvider;
        }

        public void DeleteProvider(int id)
        {
            _repositoryProvider.Delete(id);
        }

        public Provider GetProvider(int id)
        {
            return _repositoryProvider.Read(id);
        }

        public IEnumerable<Provider> GetProvider()
        {
            return _repositoryProvider.Read().ToList();
        }
        public void CreateProvider(Provider provider)
        {
            _repositoryProvider.Create(provider);
        }
    }
}
