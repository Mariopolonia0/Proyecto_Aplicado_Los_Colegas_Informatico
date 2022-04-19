using ProyectoAplicadoColegas.UI.Busqueda;
using ProyectoFinalAplicada1.BLL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Windows;

namespace ProyectoFinalAplicada1.UI.Registro
{
    /// <summary>
    /// Interaction logic for rSuplidor.xaml
    /// </summary>
    public partial class rSuplidor : Window
    {
        Suplidores suplidor = new Suplidores();
        public rSuplidor()
        {
            InitializeComponent();
            suplidor.SuplidorId = SuplidoresBLL.SiguienteIdSuplidor();
            this.DataContext = suplidor;
        }

        private void Limpiar()
        {
            suplidor = new Suplidores();
            suplidor.SuplidorId = SuplidoresBLL.SiguienteIdSuplidor();
            Cargar();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = suplidor;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            BSuplidor bSuplidor = new BSuplidor();
            bSuplidor.ShowDialog();

            suplidor = bSuplidor.GetSuplidorEncotrado();

            if (suplidor == null)
                return;

            Cargar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = SuplidoresBLL.Guardar(suplidor);

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


        private bool Validar()
        {
            bool esValido = true;

            if (ConpaniaTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Compañia está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConpaniaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombresRepresentanteTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres Representante está vacio", "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresRepresentanteTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

             if (NCFTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Comprobante Fiscal (NCF) está vacio " , "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                SuplidorIdLabel.Focus();
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }

        private void NuevoButton_Click_1(object sender, RoutedEventArgs e)
        {
                Limpiar();
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuplidoresBLL.Eliminar(suplidor))
            {
                Limpiar();
                MessageBox.Show("Categoria eliminada!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar esta Categoria", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
