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
    /// Interaction logic for rVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        Ventas venta = new Ventas();
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = venta;
            VentaIdTextBox.Text = "0";
            venta.Monto = 0;
        }

        private void ProductoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProductoIdTextBox.Text.Length == 0)
                return;

            Productos producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            if (producto == null)
            {
                MessageBox.Show("producto no existe");
                DescripcionTextBox.Text = "";
            }
            else
            {
                DescripcionTextBox.Text = producto.Descripcion;
            }            
        }

        private void BucarButton_Click(object sender, RoutedEventArgs e)
        {
            var venta = VentasBLL.Buscar(Convert.ToInt32(VentaIdTextBox.Text));

            if (venta != null)
            {
                this.venta = venta;
            }
            else
            {
                this.venta = new Entidades.Ventas();
                MessageBox.Show("El Registro No Existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

            //Limpiar();
            this.DataContext = this.venta;
        }

        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
           // NombresTextBox.Text = string.Empty;
           // ApellidosTextBox.Text = string.Empty;
           // UsuarioIdTextBox.Text = 0;
        }
        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = venta;
        }


        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            Productos producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            venta.VentaDetalle.Add(new VentasDetalles(Convert.ToInt32(VentaIdTextBox.Text), Convert.ToInt32(ProductoIdTextBox.Text), Convert.ToInt32(CantidadTextBox.Text),producto.Descripcion,producto.Precio ));
            Cargar();
            venta.Monto = venta.Monto + producto.Precio;
            totalFacturaTextBox.Text = venta.Monto.ToString();

        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count > 1 && DetalleDataGrid.SelectedIndex < DetalleDataGrid.Items.Count - 1)
            {
                venta.VentaDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (ProductoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Producto Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ProductoIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (VentaIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Venta Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VentaIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (CantidadTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ClienteIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cliente Id está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ClienteIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }


            /* if (CategoriaIdComboBox.Text.Length == 0)
             {
                 esValido = false;
                 GuardarButton.IsEnabled = false;
                 MessageBox.Show("Categoria está vacia", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Warning);
                 CategoriaIdComboBox.Focus();
                 GuardarButton.IsEnabled = true;
             }
             */
            if (FechaDatePicker.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Fecha está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                FechaDatePicker.Focus();
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }  
    }
}
