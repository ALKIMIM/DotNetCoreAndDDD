using Application.Model;
using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Application.Service.Interfaces
{
    public interface IServiceApplicationProvider
    {
        IEnumerable<ProviderModel> ListProvider();

        ProviderModel GetProvider(int id);

        void PostProvider(ProviderModel providerModel);
        void PutProvider(ProviderModel providerModel);

        void DeleteProvider(int id);
    }
}
