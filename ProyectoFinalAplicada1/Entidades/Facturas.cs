using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace ProyectoFinalAplicada1.Entidades
{
    public class Facturas
    {
        [Key]
        public int FacturaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteID { get; set; }
        public int VendedorId { get; set; }
        public double Tatal { get; set; }
        public int UsuarioID { get; set; }

    }

    public class FacturaDetalles
    {
        [Key]
        public int FacturaDetalleId { get; set; }
        public int ProductoId  { get; set; }
        public float Cantidad { get; set; }
        public double Precio { get; set; }
        public int facturaId { get; set; }

    }

}


