using Desafio.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.Model
{
    public class ProviderModel
    {
        public ProviderModel()
        {

        }

        public ProviderModel(Provider entity)
        {
            this.ImportData(entity);
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a descrição do fornecedor")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ do fornecedor")]
        public string CNPJ { get; set; }


        #region Methods

        public Provider ExportData(bool exportAllFields = false)
        {
            Provider provider = new Provider()
            {
                Id = this.Id,
                Description = this.Description,
                CNPJ = this.CNPJ
            };
            return provider;
        }

        public void ImportData(Provider entity)
        {
            if (entity == null)
            {
                return;
            }
            this.Id = entity.Id;
            this.Description = entity.Description;
            this.CNPJ = entity.CNPJ;
        }

        public Provider GetEntity()
        {
            return this.ExportData(true);
        }
        #endregion
    }
}
