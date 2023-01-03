using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Domain.Entities
{
    public class Product : EntityBase
    {
        public string Description { get; set; }
        public bool ProductState { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        [ForeignKey("Provider")]
        public int ProviderId { get; set; }
        public Provider Provider { get; set; }
    }
}
