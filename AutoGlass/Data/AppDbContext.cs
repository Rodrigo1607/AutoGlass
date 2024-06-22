using AutoGlass.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace AutoGlass.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Produto> Produtos { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>(entity =>
            {
                // Chave primária
                entity.HasKey(e => e.Id);

                // Propriedades adicionais
                entity.Property(e => e.Codigo)
                      .IsRequired()
                      .HasMaxLength(25)
                      .HasColumnType("varchar(25)");

                entity.Property(e => e.DescricaoFornecedor)
                      .IsRequired();

                entity.HasCheckConstraint("CK_Produto_DataValidade_MaiorQue_DataFabricacao",
                    "([DataValidade] >= [DataFabricacao])");
            });

            base.OnModelCreating(modelBuilder);
        }

    }
}
