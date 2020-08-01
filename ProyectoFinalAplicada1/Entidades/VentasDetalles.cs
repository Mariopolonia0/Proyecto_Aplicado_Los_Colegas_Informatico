using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class VentasDetalles
    {
        [Key]
        public int Id { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double ITBIS { get; set; }
        public double Ganancia { get; set; }
        

        public VentasDetalles()
        {
            Id = 0;
            VentaId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Descripcion = string.Empty;
            Precio = 0;
            ITBIS = 0;
        }
        public VentasDetalles(int ventaid, int productoid, int cantidad, string descripcion,double precio,double itbis,double ganancia, double costo)
        {
            Id = 0;
            VentaId = ventaid;
            ProductoId = productoid;
            Cantidad = cantidad;
            Descripcion = descripcion;
            Precio =  precio * cantidad;
            ITBIS = itbis;
            Ganancia = ganancia;
            
        }

    }
}