﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProyectoFinalAplicada1.DAL;

namespace ProyectoAplicadoColegas.Migrations
{
    [DbContext(typeof(Contexto))]
    [Migration("20220311210436_Inicial")]
    partial class Inicial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.6");

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Categorias", b =>
                {
                    b.Property<int>("CategoriaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("CategoriaId");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Clientes", b =>
                {
                    b.Property<int>("ClienteId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Cedula")
                        .HasColumnType("TEXT");

                    b.Property<string>("Direccion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<string>("Sexo")
                        .HasColumnType("TEXT");

                    b.Property<string>("Telefono")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("comprobanteFiscal")
                        .HasColumnType("TEXT");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClienteId");

                    b.ToTable("Clientes");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Compras", b =>
                {
                    b.Property<int>("CompraId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("ITBIS")
                        .HasColumnType("REAL");

                    b.Property<decimal>("Monto")
                        .HasColumnType("TEXT");

                    b.Property<int>("SuplidorId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Transporte")
                        .HasColumnType("REAL");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompraId");

                    b.ToTable("Compras");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.ComprasDetalles", b =>
                {
                    b.Property<int>("CompraDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<int>("CompraId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Precio")
                        .HasColumnType("TEXT");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<decimal>("Total")
                        .HasColumnType("TEXT");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("CompraDetalleId");

                    b.HasIndex("CompraId");

                    b.ToTable("ComprasDetalles");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Productos", b =>
                {
                    b.Property<int>("ProductoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("CategoriaId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<int>("Existencia")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("FechaEntrada")
                        .HasColumnType("TEXT");

                    b.Property<double>("Ganancia")
                        .HasColumnType("REAL");

                    b.Property<double>("ITBIS")
                        .HasColumnType("REAL");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("ProductoId");

                    b.ToTable("Productos");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Suplidores", b =>
                {
                    b.Property<int>("SuplidorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Compania")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("NCF")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreRepresentante")
                        .HasColumnType("TEXT");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("SuplidorId");

                    b.ToTable("Suplidores");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Usuarios", b =>
                {
                    b.Property<int>("UsuarioId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Contrasena")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreUsuario")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("UsuarioId");

                    b.ToTable("Usuarios");

                    b.HasData(
                        new
                        {
                            UsuarioId = 1,
                            Apellidos = "Admin",
                            Contrasena = "8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918",
                            NombreUsuario = "admin",
                            Nombres = "Admin",
                            disponible = false
                        });
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Vendedores", b =>
                {
                    b.Property<int>("VendedorId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("FechaRegistro")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombres")
                        .HasColumnType("TEXT");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("VendedorId");

                    b.ToTable("Vendedores");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.Ventas", b =>
                {
                    b.Property<int>("VentaId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("ClienteId")
                        .HasColumnType("INTEGER");

                    b.Property<double>("CostoTotal")
                        .HasColumnType("REAL");

                    b.Property<DateTime>("Fecha")
                        .HasColumnType("TEXT");

                    b.Property<double>("GananciaTotal")
                        .HasColumnType("REAL");

                    b.Property<double>("ITBISTotal")
                        .HasColumnType("REAL");

                    b.Property<double>("PrecioTotal")
                        .HasColumnType("REAL");

                    b.Property<int>("UsuarioId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VendedorId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("VentaId");

                    b.ToTable("Ventas");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.VentasDetalles", b =>
                {
                    b.Property<int>("VentaDetalleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Cantidad")
                        .HasColumnType("INTEGER");

                    b.Property<double>("Costo")
                        .HasColumnType("REAL");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<double>("Precio")
                        .HasColumnType("REAL");

                    b.Property<int>("ProductoId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("VentaId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("disponible")
                        .HasColumnType("INTEGER");

                    b.HasKey("VentaDetalleId");

                    b.HasIndex("VentaId");

                    b.ToTable("VentasDetalles");
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.ComprasDetalles", b =>
                {
                    b.HasOne("ProyectoFinalAplicada1.Entidades.Compras", null)
                        .WithMany("CompraDetalle")
                        .HasForeignKey("CompraId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("ProyectoFinalAplicada1.Entidades.VentasDetalles", b =>
                {
                    b.HasOne("ProyectoFinalAplicada1.Entidades.Ventas", null)
                        .WithMany("VentaDetalle")
                        .HasForeignKey("VentaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}