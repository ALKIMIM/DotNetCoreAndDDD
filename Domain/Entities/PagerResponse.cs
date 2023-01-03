using Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Desafio.Domain.Entities
{
    public class PagerResponse<T>
    {
        public string Filter { get; set; }
        public int TotalRows { get; set; }
        public int PageNumber { get; set; }
        public List<T> Items { get; set; }
    }
}
