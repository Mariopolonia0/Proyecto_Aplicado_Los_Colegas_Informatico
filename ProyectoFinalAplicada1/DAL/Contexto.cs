using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoFinalAplicada1.DAL
{
    public class Contexto : DbContext
    {
        public DbSet<Usuarios> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source= DATA\Usuario.db");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

           /* modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Eladio.",
                Apellidos = "Jiménez L.",
                NombreUsuario = "user01",
                Contrasena = "03ac674216f3e15c761ee1a5e255f067953623c8b388b4459e13f978d7c846f4"
            });*/
        }

    }
}
