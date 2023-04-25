using Ecommerce.Domain.Log;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Ecommerce.Infra.Mappings
{
    public class LogPessoaMap : IEntityTypeConfiguration<LogPessoa>
    {
        public void Configure(EntityTypeBuilder<LogPessoa> builder)
        {
            builder.ToTable("LogPessoa");
            builder.HasKey(p => p.Id);

            builder.Property(p => p.Guid)
                .HasColumnType("guid")
                .HasColumnName("Guid")
                .IsRequired();

            builder.Property(p => p.IdPessoa)
                .HasColumnType("int")
                .HasColumnName("IdPessoa")
                .IsRequired();

            builder.Property(p => p.IdUsuario)
                .HasColumnType("int")
                .HasColumnName("IdUsuario")
                .IsRequired();

            builder.Property(p => p.Acao)
                .HasColumnType("varchar")
                .HasColumnName("Acao")
                .HasMaxLength(128);

            builder.Property(p => p.Campo)
                .HasColumnType("varchar")
                .HasColumnName("Campo")
                .HasMaxLength(64);

            builder.Property(p => p.DataAlteracao)
                .HasColumnType("datetime")
                .HasColumnName("DataAlteracao")
                .IsRequired();

            builder.Property(p => p.DataCadastro)
                .HasColumnType("datetime")
                .HasColumnName("DataCadastro")
                .IsRequired();
            
            builder.HasOne(p => p.Pessoa)
                .WithMany()
                .HasForeignKey(p => p.IdPessoa);

            builder.HasIndex(p => p.Id)
                .HasDatabaseName("IX_LogPessoa_Id");
        }
    }
}
