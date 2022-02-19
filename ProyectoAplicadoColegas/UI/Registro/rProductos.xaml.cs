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
    /// Interaction logic for rProductos.xaml
    /// </summary>
    public partial class rProductos : Window
    {
        Productos productos = new Productos();
        public rProductos()
        {
            InitializeComponent();
            this.DataContext = productos;
            ProductoIdTextBox.Text = "0"; 
            productos.FechaEntrada = DateTime.Now;
            CategoriaIdComboBox.ItemsSource = CategoriasBLL.GetCategorias();
            CategoriaIdComboBox.SelectedValuePath = "Categoria";
            CategoriaIdComboBox.DisplayMemberPath = "Descripcion";
            productos.CategoriaId = 1;
            productos.Costo = 0;
            productos.UsuarioId = 1;
        }

        private void Limpiar()
        {
            ITBISComboBox.SelectedIndex = 0;
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            GananciaTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            productos.FechaEntrada = DateTime.Now;
            CategoriaIdComboBox.SelectedItem = null;
            CostoLabel.Content = "0";

        }

        private bool Existe()
        {
            Productos productoA = ProductosBLL.Buscar(productos.ProductoId);
            return (productos != null);
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

            if (PrecioTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Precio está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                PrecioTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ProductoIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("UsuarioId está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ProductoIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ITBISComboBox.SelectedIndex == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("ITBIS está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ITBISComboBox.Focus();
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

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var productos = ProductosBLL.Buscar(int.Parse(ProductoIdTextBox.Text));
          
            if (productos != null)
            {
                this.productos = productos;
            }
            else
            {
                this.productos = new Entidades.Productos();
                MessageBox.Show("El Producto no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }
            this.DataContext = this.productos;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ProductosBLL.Guardar(productos);

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
            if (ProductosBLL.Eliminar(Convert.ToInt32(ProductoIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Producto eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el producto", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        public void calcularITBIS()
        {
                switch (ITBISComboBox.SelectedIndex)
                {
                    case 1:
                            productos.ITBIS = 1.18;
                            productos.Costo = Convert.ToDouble(Convert.ToDouble(PrecioTextBox.Text) + Convert.ToDouble(GananciaTextBox.Text) * 1.18) ;
                            CostoLabel.Content = productos.Costo.ToString("0.00");
                            productos.Costo = Convert.ToDouble(CostoLabel.Content);
                    break;

                    case 2:
                            productos.ITBIS = 1.10;
                            productos.Costo = Convert.ToDouble((Convert.ToDouble(PrecioTextBox.Text) + Convert.ToDouble(GananciaTextBox.Text))) * 1.10;
                            CostoLabel.Content = productos.Costo.ToString("0.00");
                            productos.Costo = Convert.ToDouble(CostoLabel.Content);
                    break;

                    case 3:
                            productos.ITBIS = 0.00;
                            productos.Costo = Convert.ToDouble(Convert.ToDouble(PrecioTextBox.Text) + Convert.ToDouble(GananciaTextBox.Text));
                            CostoLabel.Content = productos.Costo.ToString("0.00");
                            productos.Costo = Convert.ToDouble(CostoLabel.Content);
                    break;
            }
        }


        private void GananciaTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.ValidarSoloNumeros(e))
                return;

            if (PrecioTextBox.Text.Length == 0 | GananciaTextBox.Text.Length == 0)
            {
                return;
            }
            else if (Convert.ToDecimal(PrecioTextBox.Text) == 0)
            {
                return;
            }
            ITBISComboBox.SelectedItem = 1;
            productos.Costo = Convert.ToDouble(PrecioTextBox.Text) + Convert.ToDouble(GananciaTextBox.Text);
            CostoLabel.Content = productos.Costo.ToString();
        }

        private void ITBISComboBox_DropDownClosed(object sender, EventArgs e)
        {
            if (PrecioTextBox.Text.Length == 0)
            {
                return;
            }
            else if (Convert.ToDecimal(PrecioTextBox.Text) == 0)
            {
                ITBISComboBox.SelectedIndex = 0;
                MessageBox.Show("Precio Esta Vacio Introduzca Precio Por Favor", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            calcularITBIS(); 
        }

       
    }


}

