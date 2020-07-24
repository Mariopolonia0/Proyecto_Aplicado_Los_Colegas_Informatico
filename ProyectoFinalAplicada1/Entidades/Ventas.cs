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
        public decimal Monto { get; set; }
        public int UsuarioId { get; set; }


        [ForeignKey("VentaId")]
        public virtual List<VentasDetalles> VentaDetalle { get; set; }

        public Ventas()
        {
            VentaId = 0;
            Fecha = DateTime.Now;
            ClienteId = 0;
            Monto = 0;
            UsuarioId = 0;
            VentaDetalle = new List<VentasDetalles>();
        }

    }
}
