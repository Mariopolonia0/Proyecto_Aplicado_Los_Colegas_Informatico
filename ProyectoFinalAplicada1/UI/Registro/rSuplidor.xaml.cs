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
    /// Interaction logic for rSuplidor.xaml
    /// </summary>
    public partial class rSuplidor : Window
    {
        Suplidores suplidor = new Suplidores();
        public rSuplidor()
        {
            InitializeComponent();
            this.DataContext = suplidor;
            SuplidorIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            SuplidorIdTextBox.Text = "0";
            ConpaniaTextBox.Text= string.Empty;
            NombresRepresentanteTextBox.Text = string.Empty;
        }

        private bool Existe()
        {
            Suplidores suplidores = SuplidoresBLL.Buscar(suplidor.SuplidorId);
            return (suplidores != null);
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var suplidor = SuplidoresBLL.Buscar(int.Parse(SuplidorIdTextBox.Text));

            if (suplidor != null)
            {
                this.suplidor = suplidor;
            }
            else
            {
                this.suplidor = new Entidades.Suplidores();
                MessageBox.Show("La Categoria no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

            //Limpiar();
            this.DataContext = this.suplidor;
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

            if (SuplidoresBLL.DuplicadoSuplidorId(Convert.ToInt32(SuplidorIdTextBox.Text)))
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("CategoriaId está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                SuplidorIdTextBox.Clear();
                SuplidorIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ConpaniaTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ConpaniaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NombresRepresentanteTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Esta Descripcion ya existe!", "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresRepresentanteTextBox.Focus();
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
            if (SuplidoresBLL.Eliminar(Convert.ToInt32(SuplidorIdTextBox.Text)))
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
/*
 
     
     
     
     */
