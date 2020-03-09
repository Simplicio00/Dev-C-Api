using Microsoft.EntityFrameworkCore;
using Senai.CodeFirst.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.CodeFirst.WebApi.Contexts
{
    /// <summary>
    /// Classe responsável pelo contexto do projeto
    /// Faz a documentação entre a api e o banco de dados
    /// </summary>
    public class Context : DbContext
    {
        public DbSet<TiposUsuario> TiposUsuario { get; set; }
        public DbSet<Usuario> Usuario  { get; set; }
        public DbSet<Estudios> Estudio { get; set; }
        public DbSet<Jogo> Jogo { get; set; }

        /// <summary>
        /// Define as opções de construção do banco
        /// </summary>
        /// <param name="optionsBuilder"></param>
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DEV101\\SQLEXPRESS;Database=Inlock_codeFirst_Manha; user id=sa;pwd=sa@132");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TiposUsuario>().HasData(new TiposUsuario { IdTipoUsuario = 1, Titulo = "Administrador" }, new TiposUsuario { IdTipoUsuario = 2, Titulo = "Comum" });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { IdUsuario = 1, Email = "Adminim@admi.com", Senha = "admin", IdTipoUsuario = 1 });
            modelBuilder.Entity<Usuario>().HasData(new Usuario { IdUsuario = 1, Email = "Clientesm@admi.com", Senha = "Comum", IdTipoUsuario = 2 });

            modelBuilder.Entity<Estudios>().HasData(new Estudios { IdEstudio = 1, NomeEstudio = "Blzza" });
            
        }

       //Ferramentas gerenciador de pacotes do nugets
       // add-migration cria-banco
       // para atualizar 
       //update-database
    }
}
