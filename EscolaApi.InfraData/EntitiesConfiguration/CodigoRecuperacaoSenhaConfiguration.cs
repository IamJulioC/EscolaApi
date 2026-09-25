using EscolaApi.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EscolaApi.Infra.Data.EntitiesConfiguration
{
    public class CodigoRecuperacaoSenhaConfiguration : IEntityTypeConfiguration<CodigoRecuperacaoSenha>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<CodigoRecuperacaoSenha> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.CodigoHash).IsRequired();
            builder.Property(x => x.CodigoSalt).IsRequired();
            builder.Property(x => x.CriadoEm).IsRequired();
            builder.Property(x => x.ExpiraEm).IsRequired();

            builder.HasOne(x => x.Usuario)
                   .WithMany()
                   .HasForeignKey(x => x.UsuarioId)
                   .OnDelete(DeleteBehavior.NoAction);

            builder.HasIndex(x => x.UsuarioId);
        }
    }
}
