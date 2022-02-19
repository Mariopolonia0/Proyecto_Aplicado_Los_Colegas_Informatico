using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class VentasDetalles
    {
        [Key]
        public int VentaDetalleId { get; set; }
        public int VentaId { get; set; }
        public int ProductoId { get; set; }
        public int Cantidad { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double Costo { get; set; }

        public VentasDetalles()
        {
            VentaDetalleId = 0;
            VentaId = 0;
            ProductoId = 0;
            Cantidad = 0;
            Descripcion = string.Empty;
            Costo = 0;
        }
        public VentasDetalles(int ventaid, int productoid, int cantidad, string descripcion,double precio )
        {
            VentaDetalleId = 0;
            VentaId = ventaid;
            ProductoId = productoid;
            Cantidad = cantidad;
            Descripcion = descripcion;
            Precio = precio;
            Costo =  precio * cantidad; 
        }
    }
}