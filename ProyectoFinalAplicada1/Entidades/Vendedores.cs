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

        public Vendedores()
        {
            VendedorId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            UsuarioId = 0;
        }
    }
}
