using Desafio.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Desafio.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Product> Product { get; set; }
        public DbSet<Provider> Provider { get; set; }
    }
}
