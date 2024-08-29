﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CestaFeira.Data.Context
{
    public class ApsContext : DbContext
    {
        public DbSet<UsuarioEntity> Usuarios { get; set; }
        public DbSet<ListaEntity> Listas { get; set; }

        public DbSet<ListaTarefasEntity> ListaTarefas { get; set; }

        private CryptographyHelper _cryptografyHelper = new CryptographyHelper();

        public ApsContext(DbContextOptions<ApsContext> options) : base(options) { }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // This method should be empty to apply migrations correctly (commented to skip sonarqube code smells)
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            string salt = _cryptografyHelper.GenerateSalt();
            var senha = _cryptografyHelper.Encrypt("TesteTecsystem", salt);
            base.OnModelCreating(modelBuilder);


            //Configurando Mapeamentos de bancos de dados.
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            //Configurando para armazenar todos dados em UpCase.
            var converter = new ValueConverter<string, string>(
                v => v.ToUpper(), //Input
                v => v.ToUpper() //Output
            );

            modelBuilder.Entity<ListaEntity>()
                .HasMany(l => l.ListaTarefas)
                .WithOne(t => t.Listas)
                .HasForeignKey(t => t.ListaId)
                .OnDelete(DeleteBehavior.Cascade);

            //Inserindo usuário padrão.
            modelBuilder.Entity<UsuarioEntity>().HasData(
                new UsuarioEntity
                {
                    Id = new Guid("4ab52682-7f30-4f2a-abfc-313261d73761"),
                    Email = "administrador@gmail.com",
                    Senha = senha,
                    Nome = "Administrador",
                    Ativo = true,
                    Token = ""
                }
            );


        }
    }
}
}
