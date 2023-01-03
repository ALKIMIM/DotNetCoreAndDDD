﻿using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository
{
    public interface IRepositoryProduct : IRepository<Product>
    {
        new IEnumerable<Product> Read();
        new public Product Read(int id);
    }
}
