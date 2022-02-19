using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class Ventas
    {
        [Key]
        public int VentaId { get; set; }
        public DateTime Fecha { get; set; }
        public int ClienteId { get; set; }
        public int UsuarioId { get; set; }
        public int VendedorId { get; set; }
        public double PrecioTotal { get; set; }
        public double GananciaTotal { get; set; }
        public double ITBISTotal { get; set; }
        public double CostoTotal { get; set; }
       
        [ForeignKey("VentaId")]
        public virtual List<VentasDetalles> VentaDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            UsuarioId = 0;
            VendedorId = 0;
            PrecioTotal = 0;
            GananciaTotal = 0;
            ITBISTotal = 0;
            CostoTotal = 0;
            VentaDetalle = new List<VentasDetalles>();
        }
    }
}
