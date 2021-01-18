using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WiProTest.Domain.Entities;

namespace WiProTest.Infra.Data.Context
{
    public class WiProTestContext : DbContext
    {
        public WiProTestContext(DbContextOptions<WiProTestContext> options) : base(options)
        {

        }

        public DbSet<Moeda> Moedas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(255)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(WiProTestContext).Assembly);

            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e =>
                e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
