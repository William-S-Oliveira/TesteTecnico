using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TesteTecnico.Models;

namespace TesteTecnico.Data
{
    public class TesteTecnicoContext : DbContext
    {
       public DbSet<Funcionario> Funcionario { get; set; }
       public DbSet<Ticket> Ticket { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=TesteTecninco.db");
            }
        }

        // Mapeamento e personalização das tabelas e relacionamentos do banco
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Funcionario>(entity =>
            {
                entity.ToTable("Funcionarios");

                entity.HasKey(f => f.Id);

                entity.Property(f => f.Nome)
                            .IsRequired()
                            .HasMaxLength(100);

                entity.Property(f => f.CPF)
                            .IsRequired()
                            .HasMaxLength(11);

                //index para o CPF ser unico dentro do banco 
                entity.HasIndex(f => f.CPF)
                            .IsUnique();

                entity.Property(f => f.Situacao)
                               .IsRequired()
                               .HasColumnType("text")
                               .HasMaxLength(1)
                               .HasConversion(
                                   v => v.ToString(),
                                   v => string.IsNullOrEmpty(v) ? 'A' : v[0]
                                   );

                entity.Property(f => f.DataModificacao)
                               .IsRequired();
            });

            

            modelBuilder.Entity<Ticket>(entity =>
            {
                entity.ToTable("Tickets");

                entity.HasKey(t => t.Id);

                entity.Property(t => t.Quantidade)
                      .IsRequired();

                entity.Property(t => t.Situacao)
                      .IsRequired()
                      .HasColumnType("TEXT")
                      .HasMaxLength(1)
                      .HasConversion(
                          v => v.ToString(),
                          v => string.IsNullOrEmpty(v) ? 'A' : v[0]);

                entity.Property(t => t.DataModificacao)
                      .IsRequired();

                entity.Property(t => t.DataCriacao)
                      .IsRequired();

                // Relacionamento 1:N
                // Um Funcionario tem muitos Tickets
                // Um Ticket pertence a um Funcionario (obrigatório)
                entity.HasOne(t => t.Funcionario)
                      .WithMany(f => f.Tickets)
                      .HasForeignKey(t => t.FuncionarioId)
                      .IsRequired()
                      .OnDelete(DeleteBehavior.Restrict);
            });

        }

    }
}
