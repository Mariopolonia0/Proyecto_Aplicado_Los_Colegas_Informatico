using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string descripcion { get; set; }
        public double Precio { get; set; }
        public double ITBIS { get; set; }
        public DateTime FechaEntrada { get; set; }
        public double Costo { get; set; }
        public double Ganancia { get; set; }
        public int UsuarioId { get; set; }
    }
}
