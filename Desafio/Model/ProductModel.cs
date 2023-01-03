using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;
using Desafio.Domain.Entities;
using Domain.Enums;

namespace Application.Model
{
    public class ProductModel
    {
        public ProductModel()
        {

        }

        public ProductModel(Product entity)
        {
            this.ImportData(entity);
        }

        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o estado do produto")]
        public ProductStateEnum ProductState { get; set; }

        [Required(ErrorMessage = "Informe a data de fabricação do produto")]
        public DateTime ManufacturingDate { get; set; }

        [Required(ErrorMessage = "Informe a data de validade do produto")]
        public DateTime ExpirationDate { get; set; }

        public ProviderModel Provider { get; set; }

        #region Methods

        public Product ExportData(bool exportAllFields = false)
        {
            if (this.ManufacturingDate >= this.ExpirationDate)
            {
                throw new InvalidOperationException("A data de fabricação não pode ser maior que a data de validade");
            }

            Product product = new Product()
            {
                Id = this.Id,
                Description = this.Description,
                ExpirationDate = this.ExpirationDate,
                ManufacturingDate = this.ManufacturingDate,
                ProductState = this.ProductState,
                ProviderId = this.Provider.Id
            };
            return product;
        }

        public void ImportData(Product entity)
        {
            if (entity == null)
            {
                return;
            }
            this.Id = entity.Id;
            this.Description = entity.Description;
            this.ExpirationDate = entity.ExpirationDate;
            this.ManufacturingDate = entity.ManufacturingDate;
            this.ProductState = entity.ProductState;
            this.Provider = new ProviderModel(entity.Provider ?? new Provider());
        }

        public Product GetEntity()
        {
            return this.ExportData(true);
        }
        #endregion
    }
}
