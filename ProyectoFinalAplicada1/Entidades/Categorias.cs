using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class Categorias
    {
        [Key]
        public int CategoriaId { get; set; }
        /*public string Nombre { get; set; }
        public string Estado { get; set; */
        public string Descripcion { get; set; }

        public Categorias()
        {
            CategoriaId = 0;
            /*Nombre = string.Empty;
            Estado = string.Empty;*/
            Descripcion = string.Empty;
        }
    }
}
