using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;
using WiProTest.Domain.Entities;

namespace WiProTest.Infra.Data.Mappings
{
    public class LoteMap : IEntityTypeConfiguration<Lote>
    {
        public void Configure(EntityTypeBuilder<Lote> builder)
        {
            builder.ToTable("lotes");

            builder.Property(c => c.Id)
                .ValueGeneratedOnAdd()
                .IsRequired();

            builder.Property(c => c.DataCadastro)
                .HasColumnName("data_cadastro")
                .HasColumnType("datetime")
                .IsRequired();


        }
    }
}
