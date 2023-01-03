using System.ComponentModel.DataAnnotations;

namespace Application.Model
{
    public class ProviderModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Informe a descrição do fornecedor")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Informe o CNPJ do fornecedor")]
        public string CNPJ { get; set; }
    }
}
