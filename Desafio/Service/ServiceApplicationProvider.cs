using Application.Model;
using Application.Service.Interfaces;
using Desafio.Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Application.Service
{
    public class ServiceApplicationProvider : IServiceApplicationProvider
    {
        private readonly IProvider _provider;

        public ServiceApplicationProvider(IProvider provider)
        {
            _provider = provider;
        }

        public void DeleteProvider(int id)
        {
            _provider.DeleteProvider(id);
        }

        public ProviderModel GetProvider(int id)
        {
            var provider = _provider.GetProvider(id);

            if (provider == null)
                return new ProviderModel();

            ProviderModel model = new ProviderModel()
            {
                Id = provider.Id,
                Description = provider.Description,
                CNPJ = provider.CNPJ
            };

            return model;
        }

        public IEnumerable<ProviderModel> ListProvider()
        {
            var list = _provider.GetProvider("");
            List<ProviderModel> providers = new List<ProviderModel>();

            foreach (var item in list)
            {
                ProviderModel productModel = new ProviderModel()
                {
                    Id = item.Id,
                    Description = item.Description,
                    CNPJ = item.CNPJ
                };
                providers.Add(productModel);
            }
            return providers;
        }

        public void PostProvider(ProviderModel providerModel)
        {
            Provider provider = new Provider()
            {
                Id = providerModel.Id,
                Description = providerModel.Description,
                CNPJ = providerModel.CNPJ
            };
            _provider.CreateProvider(provider);
        }

        public void PutProvider(ProviderModel providerModel)
        {
            Provider provider = new Provider()
            {
                Id = providerModel.Id,
                Description = providerModel.Description,
                CNPJ = providerModel.CNPJ
            };
            _provider.CreateProvider(provider);
        }
    }
}
