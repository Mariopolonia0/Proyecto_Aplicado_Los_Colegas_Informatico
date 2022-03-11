using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class Vendedores
    {
        [Key]
        public int VendedorId { get; set; }
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public int UsuarioId { get; set; }
        public DateTime FechaRegistro { get; set; }
        public bool disponible { get; set; }

        public Vendedores()
        {
            VendedorId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            FechaRegistro = DateTime.Now;
            UsuarioId = 0;
        }
    }
}
