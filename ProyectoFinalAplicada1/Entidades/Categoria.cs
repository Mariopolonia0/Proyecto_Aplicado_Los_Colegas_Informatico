using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }
        public string  Nombre { get; set; }
        public char Estado { get; set; }
        public string Descripcion { get; set; }

    }
}
