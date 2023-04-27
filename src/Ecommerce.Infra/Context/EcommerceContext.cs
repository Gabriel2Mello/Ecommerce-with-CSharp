using Ecommerce.Domain.Entities;
using Ecommerce.Domain.Log;
using Ecommerce.Infra.Mappings;
using Ecommerce.Infra.Mappings.Log;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Infra.Context
{
    public class EcommerceContext : DbContext
    {
        public EcommerceContext(DbContextOptions<EcommerceContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new PessoaMap());
            modelBuilder.ApplyConfiguration(new PessoaLogMap());
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Pessoa> Pessoas { get; set; }
        public DbSet<PessoaLog> PessoaLogs { get; set; }
    }
}
