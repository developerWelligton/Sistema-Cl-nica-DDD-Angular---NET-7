﻿using Entities;
using Entities.Entidades;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Configuracao
{
    public class ContextBase : IdentityDbContext<ApplicationUser>
    {
        public ContextBase(DbContextOptions options) : base(options) {
        
        }

        public DbSet<UsuarioSistemaClinica> UsuarioSistemaClinicas { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Secretaria> Secretarias { get; set; }
        public DbSet<Veterinario> Veterinarios { get; set; }
        public DbSet<Especie> Especies { get; set; }
        public DbSet<Animal> Animais { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Exame> Exames { get; set; }
        public DbSet<Consulta_Exame> Consulta_Exames { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(ObterStringConexao());
                base.OnConfiguring(optionsBuilder);
            }
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ApplicationUser>().ToTable("AspNetUsers").HasKey(t => t.Id);
            builder.Entity<Consulta_Exame>()
                .HasKey(c => new { c.ID_Consulta, c.ID_Exame });

            // Aqui é onde você configura a precisão e a escala para a propriedade 'Custo'
            builder.Entity<Exame>()
                .Property(e => e.Custo)
            .HasPrecision(8, 2);

            builder.Entity<Consulta>()
                .HasOne(c => c.Veterinario)
                .WithMany()
                .HasForeignKey(c => c.ID_Veterinario)
                .OnDelete(DeleteBehavior.NoAction); // Modificar para NoAction

            builder.Entity<Consulta>()
                .HasOne(c => c.Animal)
                .WithMany()
                .HasForeignKey(c => c.ID_Animal)
                .OnDelete(DeleteBehavior.NoAction);


            base.OnModelCreating(builder);
        }

        public string ObterStringConexao()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=db_identity_clinica;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False";
        }

    }
}
