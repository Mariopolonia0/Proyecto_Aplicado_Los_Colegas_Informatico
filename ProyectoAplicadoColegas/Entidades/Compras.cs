using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
   public class Compras
    {
        [Key]
        public int CompraId { get; set; }
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }
        public decimal Monto { get; set; }
        public double ITBIS { get; set; }
        public int UsuarioId { get; set; }
        public double Transporte { get; set; }
        public bool disponible { get; set; }

        [ForeignKey("CompraId")]
        public virtual List<ComprasDetalles> CompraDetalle { get; set; }

        public Compras()
        {
            CompraId = 0;
            Fecha = DateTime.Now;
            SuplidorId = 0;
            Monto = 0;
            ITBIS = 0;
            UsuarioId = 0;
            Transporte = 0;

            CompraDetalle = new List<ComprasDetalles>();
        }
    }
}
