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
        public DbSet<Ventas> Ventas { get; set; }
        public DbSet<Productos> Productos { get; set; }
        public DbSet<Compras> Compras { get; set; }
        public DbSet<Clientes> Clientes { get; set; }
        public DbSet<Vendedores> Vendedores { get; set; }
        public DbSet<Categorias> Categorias { get; set; }
        public DbSet<Suplidores> Suplidores { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging().UseSqlite(@"Data Source= DATA\BDProyectoFinal.db");
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
         //   modelBuilder.Entity<Clientes>().HasData(new Clientes {  Sexo = "Masculino", ClienteId =-1 });
           // modelBuilder.Entity<Clientes>().HasData(new Clientes {  Sexo = "Femenino" ,ClienteId =-2});

            
            modelBuilder.Entity<Usuarios>().HasData(new Usuarios
            {
                UsuarioId = 1,
                Nombres = "Admin",
                Apellidos = "Admin",
                NombreUsuario = "admin",
                Contrasena = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918"
            });
            
        }
    }
}
