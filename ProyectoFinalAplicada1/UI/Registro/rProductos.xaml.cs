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
            CategoriaIdComboBox.ItemsSource = CategoriasBLL.GetCategorias();
            CategoriaIdComboBox.SelectedValuePath = "Categoria";
            CategoriaIdComboBox.DisplayMemberPath = "Nombre";
            productos.CategoriaId = 1;
            productos.Costo = 0;
            


        }

        private void Limpiar()
        {
            ProductoIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            CantidadTextBox.Text = "0";
            PrecioTextBox.Text = "0";
            //CostoTextBox.Text = "0";
            CategoriaIdComboBox.SelectedItem = null;
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

            

           /* if (//CostoTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Costo está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CostoTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }
            */
            if (GananciaComboBox.SelectedIndex == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Ganancia está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                GananciaComboBox.Focus();
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

            if (CantidadTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
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

            //Limpiar();
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

        

        private void ITBISComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double Costo = 0;
            if (PrecioTextBox.Text.Length == 0)
                return;

            switch (ITBISComboBox.SelectedIndex)
            {
                
                case 1:
                    productos.ITBIS = 0.18;
                    Costo = Convert.ToDouble(PrecioTextBox.Text) * 0.18;
                    productos.Costo = Costo + productos.Precio;
                    CostoLabel.Content = productos.Costo.ToString();
                    break;

                case 2:
                    productos.ITBIS = 0.10;
                    Costo = Convert.ToDouble(PrecioTextBox.Text) * 0.10;
                    productos.Costo = Costo + productos.Precio;
                    CostoLabel.Content = productos.Costo.ToString();
                    break;

                case 3:
                    productos.ITBIS = 0.00;
                    productos.Costo = Convert.ToDouble(PrecioTextBox.Text);
                    CostoLabel.Content = PrecioTextBox.Text.ToString();
                    break;
            }
        }

        private void GananciaComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            double Costo = 0;

            switch (GananciaComboBox.SelectedIndex)
            {

                case 1:
                    productos.Ganancia = 0.75;
                    Costo = Convert.ToDouble(PrecioTextBox.Text) * 0.75;
                    productos.Costo = productos.Precio + Costo;
                    CostoLabel.Content = productos.Costo.ToString();
                    break;

                case 2:
                    productos.Ganancia = 0.50;
                    Costo = Convert.ToDouble(PrecioTextBox.Text) * 0.50;
                    productos.Costo = productos.Precio + Costo;
                    CostoLabel.Content = productos.Costo.ToString();
                    break;

                case 3:
                    productos.Ganancia = 0.30;
                    Costo = Convert.ToDouble(PrecioTextBox.Text) * 0.30;
                    productos.Costo = productos.Precio + Costo;
                    CostoLabel.Content = productos.Costo.ToString();
                    break;

                case 4:
                    productos.Ganancia = 0.00;
                    productos.Costo = productos.Precio;
                    CostoLabel.Content = productos.Costo.ToString();
                    break;
            }
        }
    }

}

