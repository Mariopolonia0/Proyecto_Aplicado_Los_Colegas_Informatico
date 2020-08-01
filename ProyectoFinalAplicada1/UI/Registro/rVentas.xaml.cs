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
            venta.CostoTotal = 0;
            venta.GananciaTotal = 0;
            venta.ITBISTotal = 0;
            venta.PrecioTotal = 0;
        }

        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
            ClienteIdTextBox.Text = string.Empty;
            ProductoIdTextBox.Text = string.Empty;
            CantidadTextBox.Text = string.Empty;
            DescripcionTextBox.Text = string.Empty;

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
            venta.VentaDetalle.Add(new VentasDetalles(Convert.ToInt32(VentaIdTextBox.Text), producto.ProductoId, Convert.ToInt32(CantidadTextBox.Text), producto.Descripcion, producto.Precio, producto.ITBIS, producto.Ganancia, producto.Costo));
            Cargar();

            venta.CostoTotal = venta.CostoTotal + producto.Costo;
            PrecioTotalLabel.Content = venta.CostoTotal.ToString();

            /* venta.PrecioTotal = venta.PrecioTotal + producto.Precio;
             PrecioTotalTextBox.Text = venta.PrecioTotal.ToString();

             venta.GananciaTotal = venta.GananciaTotal + producto.Ganancia;
             GananciaTotalTextBox.Text = venta.GananciaTotal.ToString();

             venta.ITBISTotal = venta.ITBISTotal + producto.ITBIS;
             ITBISTotalTextBox.Text = venta.ITBISTotal.ToString();
             */


            CantidadTextBox.Text = "0";
        }
        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {

            if (DetalleDataGrid.SelectedIndex < 0)
                return;

            venta.VentaDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
            Cargar();
            CantidadTextBox.Clear();
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

            if (FechaDatePicker.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Fecha está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                FechaDatePicker.Focus();
                GuardarButton.IsEnabled = true;
            }
            if (CantidadTextBox.Text.Length == 0 | Convert.ToInt32( CantidadTextBox.Text)==0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            return esValido;
        }

        private bool Validarguardar()
        {
            bool esValido = true;

            if (VentaIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Venta Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VentaIdTextBox.Focus();
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
        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
                Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validarguardar())
                return;

            var paso = VentasBLL.Guardar(venta);

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
    }
}
