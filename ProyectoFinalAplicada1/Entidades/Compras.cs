using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    class Compras
    {
        [Key]
        public int ComprasId { get; set; }
        public DateTime Fecha { get; set; }
        public int SuplidorId { get; set; }
        public double Monto { get; set; }
        public int UsuarioId { get; set; }
        public string NCF { get; set; }
        public double ITBS  { get; set; }
    }
}
