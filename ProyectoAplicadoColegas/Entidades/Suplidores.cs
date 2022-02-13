using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class Suplidores
    {
        [Key]
        public int SuplidorId  { get; set; }
        public string Compania { get; set; }
        public string NombreRepresentante { get; set; }
        public  DateTime Fecha { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Compania = string.Empty;
            NombreRepresentante = string.Empty;
            Fecha = DateTime.Now;
        }
    } 
}
