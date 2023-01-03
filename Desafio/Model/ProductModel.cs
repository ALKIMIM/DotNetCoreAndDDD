using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.ComponentModel.DataAnnotations;

namespace Application.Model
{
    public class ProductModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe a descrição do produto")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Informe o estado do produto")]
        public bool ProductState { get; set; }

        [Required(ErrorMessage = "Informe a data de fabricação do produto")]
        public DateTime ManufacturingDate { get; set; }

        [Required(ErrorMessage = "Informe a data de validade do produto")]
        public DateTime ExpirationDate { get; set; }

        public ProviderModel Provider { get; set; }
    }
}
