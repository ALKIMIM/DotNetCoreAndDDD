using Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Desafio.Domain.Entities
{
    public class Provider : EntityBase
    {
        public string Description { get; set; }
        public string CNPJ { get; set; }
    }
}
