using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using WiProTest.Domain.Entities;

namespace WiProTest.Infra.Data.Mappings
{
    public class MoedaMap : IEntityTypeConfiguration<Moeda>
    {
        public void Configure(EntityTypeBuilder<Moeda> builder)
        {
            builder.HasKey(c => c.Id);

            builder.ToTable("moedas");

            builder.Property(c => c.NomeMoeda)
                .HasColumnName("moeda")
                .IsRequired();

            builder.Property(c => c.DataInicio)
                .HasColumnName("data_inicio")
                .HasColumnType("datetime")
                .IsRequired();

            builder.Property(c => c.DataFim)
                .HasColumnName("data_fim")
                .HasColumnType("datetime")
                .IsRequired();

            builder.HasOne(c => c.Lote)
                .WithMany(c => c.Moedas)
                .HasForeignKey(c => c.IdLote);
        }
    }
}
