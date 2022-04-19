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
        public string NCF { get; set; }
        public  DateTime FechaRegistro { get; set; }
        public bool disponible { get; set; }

        public Suplidores()
        {
            SuplidorId = 0;
            Compania = string.Empty;
            NombreRepresentante = string.Empty;
            FechaRegistro = DateTime.Now;
            disponible = true;
        }
    } 
}
