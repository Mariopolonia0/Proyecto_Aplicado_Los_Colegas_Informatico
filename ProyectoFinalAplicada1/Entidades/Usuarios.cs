using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ProyectoFinalAplicada1.Entidades
{
    public class Usuarios
    {
        [Key]
        public int UsuarioId { get; set; }
        public String Nombres { get; set; }
        public String Apellidos { get; set; }
        public String NombreUsuario { get; set; }
        public String Contrasena { get; set; }

        public Usuarios()
        {
            UsuarioId = 0;
            Nombres = string.Empty;
            Apellidos = string.Empty;
            NombreUsuario = string.Empty;
            Contrasena = string.Empty;
        }

        [ForeignKey("UsuarioId")]
        public List<UsuarioDetalle> Detalle { get; set; } = new List<UsuarioDetalle>();
    }

    public class UsuarioDetalle
    {

        [Key]
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string NombreUsuario { get; set; }

        public UsuarioDetalle(int usuarioId, string nombre,string apellido)
        {
            UsuarioId = usuarioId;
            Nombre = nombre.ToString();
            Apellido = apellido.ToString();
           // NombreUsuario = nombreusuario.ToString();
        }
    }
}

