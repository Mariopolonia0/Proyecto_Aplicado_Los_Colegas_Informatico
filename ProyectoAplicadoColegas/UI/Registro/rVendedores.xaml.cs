using ProyectoFinalAplicada1.BLL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Windows;

namespace ProyectoFinalAplicada1.UI.Registro
{
    /// <summary>
    /// Interaction logic for Vendedores.xaml
    /// </summary>
    public partial class rVendedores : Window
    {
        Vendedores vendedores = new Vendedores();
        public rVendedores()
        {
            InitializeComponent();
            vendedores.VendedorId = VendedoresBLL.SiguienteIdVendedor();
            this.DataContext = vendedores;
        }

        private void Limpiar()
        {
            vendedores = new Vendedores();
            vendedores.VendedorId = VendedoresBLL.SiguienteIdVendedor();
            this.DataContext = vendedores;
        }

        private bool Validar()
        {
            bool esValido = true;

            if (Convert.ToInt32(VendedorIdLabel.Content) <= 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("VendedorId está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VendedorIdLabel.Focus();
                GuardarButton.IsEnabled = true;
            }

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

            return esValido;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var vendedores = VendedoresBLL.Buscar(int.Parse(VendedorIdLabel.Content.ToString()));

            if (vendedores != null)
            {
                this.vendedores = vendedores;
            }
            else
            {
                this.vendedores = new Vendedores();
                MessageBox.Show("El Vendedor no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            this.DataContext = this.vendedores;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = VendedoresBLL.Guardar(vendedores);

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

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
           /* if(VendedoresBLL.Eliminar(Convert.ToInt32(VendedorIdLabel.Text.ToString)))
            {
                Limpiar();
                MessageBox.Show("Vendedor eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else*/
                MessageBox.Show("No fue posible eliminar al Vendedor", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
