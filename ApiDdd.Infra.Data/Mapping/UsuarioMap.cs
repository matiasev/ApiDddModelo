using ApiDdd.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace ApiDdd.Infra.Data.Mapping
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.HasKey(c => c.UsuarioID);

            builder.Property(c => c.Nome)
                .IsRequired()
                .HasColumnName("Nome");

            builder.Property(c => c.Email)
                .IsRequired()
                .HasColumnName("Email");

            builder.Property(c => c.Password)
                .IsRequired()
                .HasColumnName("Password");
        }
    }
}
