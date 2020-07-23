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
        //public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public decimal ITBIS { get; set; }

        public VentasDetalles()
        {
            Id = 0;
            VentaId = 0;
            ProductoId = 0;
            Cantidad = 0;
            //Descripcion = string.Empty;
            Precio = 0;
            ITBIS = 0;
        }

        public VentasDetalles(int ventaid, int productoid, int cantidad, string descripcion, decimal precio)
        {
            Id = 0;
            VentaId = ventaid;
            ProductoId = productoid;
            Cantidad = cantidad;
            //Descripcion = descripcion;
            Precio = precio;
            ITBIS = cantidad * precio;

        }

    }
}
