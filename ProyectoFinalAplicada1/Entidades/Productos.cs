using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class Productos
    {
        [Key]
        public int ProductoId { get; set; }
        public string Descripcion { get; set; }
        public double Precio { get; set; }
        public double ITBIS { get; set; }
        public DateTime FechaEntrada { get; set; }
        public double Costo { get; set; }
        public double Ganancia { get; set; }
        public int UsuarioId { get; set; }
        public int Existencia { get; set; }
        public int CategoriaId { get; set; }

        public Productos()
        {
            ProductoId = 0;
            Descripcion = string.Empty;
            Precio = 0;
            ITBIS = 0;
            FechaEntrada = DateTime.Now;
            Costo = 0;
            Ganancia = 0;
            Existencia = 0;
            UsuarioId = 0;
            CategoriaId = 0;
        }
    }
}
