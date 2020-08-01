using ProyectoFinalAplicada1.BLL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoFinalAplicada1.UI.Registro
{
    /// <summary>
    /// Interaction logic for rUsuarios.xaml
    /// </summary>
    public partial class rUsuarios : Window
    {
        private Usuarios usuarios = new Usuarios();

        public rUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;

        }

        private void Limpiar()
        {
            this.usuarios = new Usuarios();
            ContrasenaPasswordBox.Password = string.Empty;
            ConfirmarContrasenaPasswordBox.Password = string.Empty;
            this.DataContext = usuarios;
        }

        //Verifica que no allá campos vacío.
        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ApellidosTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Apellidos está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ApellidosTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombre usuario está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreUsuarioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ContrasenaPasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ContrasenaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarContrasenaPasswordBox.Password.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Confirmar contraseña está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarContrasenaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConfirmarContrasenaPasswordBox.Password != ContrasenaPasswordBox.Password)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("La contraseña no coiciden", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConfirmarContrasenaPasswordBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }

        //Botón Nuevo.
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        //Botón Guardar.
        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = UsuariosBLL.Guardar(usuarios);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacción exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transacción Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Botón Eliminar.
        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (UsuariosBLL.Eliminar(Convert.ToInt32(UsuarioIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        //Botón Buscar.
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var usuarios = UsuariosBLL.Buscar(int.Parse(UsuarioIdTextBox.Text));

            if (usuarios != null)
            {
                this.usuarios = usuarios;
            }
            else
            {
                this.usuarios = new Entidades.Usuarios();
                MessageBox.Show("El Usuario no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
                
            //Limpiar();
            this.DataContext = this.usuarios;
        }

    }
}
