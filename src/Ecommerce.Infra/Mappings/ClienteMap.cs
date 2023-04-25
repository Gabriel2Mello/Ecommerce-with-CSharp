using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce.Infra.Mappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Guid)
                .HasColumnType("guid")
                .HasColumnName("Guid")
                .IsRequired();

            builder.Property(p => p.IdPessoa)
                .HasColumnType("int")
                .IsRequired();

            builder.Property(p => p.NumeroIdentidade)
                .HasColumnType("varchar")
                .HasColumnName("NumeroIdentidade")
                .HasMaxLength(18)
                .IsRequired();

            builder.Property(p => p.Nome)
                .HasColumnType("varchar")
                .HasColumnName("Nome")
                .HasMaxLength(255)
                .IsRequired();

            builder.HasIndex(p => p.Id)
                .HasDatabaseName("IX_Cliente_Id");          
        }
    }
}
