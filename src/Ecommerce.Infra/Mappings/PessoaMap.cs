using Ecommerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infra.Mappings
{
    public class PessoaMap : IEntityTypeConfiguration<Pessoa>
    {
        public void Configure(EntityTypeBuilder<Pessoa> builder)
        {
            builder.ToTable("Pessoa");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Guid)
                .HasColumnType("guid")
                .HasColumnName("Guid")
                .IsRequired();

            builder.Property(p => p.Celular)
                .HasColumnType("nvarchar")
                .HasColumnName("Celular")
                .HasMaxLength(14);

            builder.Property(p => p.Email)
                .HasColumnType("nvarchar")
                .HasColumnName("Email")
                .HasMaxLength(64);

            builder.Property(p => p.Senha)
                .HasColumnType("nvarchar")
                .HasColumnName("Senha")
                .HasMaxLength(32)
                .IsRequired();

            builder.Property(p => p.Tipo)
                .HasColumnType("nvarchar")
                .HasColumnName("Tipo")
                .HasMaxLength(40)
                .IsRequired();

            builder.HasIndex(p => p.Id)
                .HasDatabaseName("IX_Pessoa_Id");
        }
    }
}
