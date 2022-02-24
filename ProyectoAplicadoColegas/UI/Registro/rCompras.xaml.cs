using ProyectoFinalAplicada1.BLL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ProyectoFinalAplicada1.UI.Registro
{
    /// <summary>
    /// Interaction logic for rCompras.xaml
    /// </summary>
    public partial class rCompras : Window
    {
        Compras compra = new Compras();
        Productos productos = new Productos();
        public rCompras()
        {
            InitializeComponent();
            this.DataContext = compra;
            CompraIdTextBox.Text = "0";
            DescripcionTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            SuplidorIdComboBox.ItemsSource = SuplidoresBLL.GetSuplidores();
            SuplidorIdComboBox.SelectedValuePath = "SuplidorId";
            SuplidorIdComboBox.DisplayMemberPath = "SuplidorId";                      
        }

        private void SuplidorIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Suplidores suplidor = SuplidoresBLL.Buscar(Convert.ToInt32(SuplidorIdComboBox.SelectedValue));
            if (suplidor == null)
                return;
            NombreSuplidoraLabel.Content = suplidor.NombreRepresentante;
            CompaniaSuplidorLabel.Content = suplidor.Compania;
        }

        public void Limpiar()
        {
            CompraIdTextBox.Text = "0";
            //SuplidorIdComboBox.SelectedItem = null;
            CantidadTextBox.Clear();
            NCFTextBox.Clear();
            DescripcionTextBox.Clear();
            TransporteTextBox.Clear();
        }

        public void LimpiarDetalle()
        {
            ProductoIdTextBox.Text = "0";
            CantidadTextBox.Clear();
            DescripcionTextBox.Clear();
            PrecioTextBox.Clear();
        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = compra;
        }

        private void ProductoidTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProductoIdTextBox.Text.Length == 0)
                return;
            else if (Convert.ToInt32(ProductoIdTextBox.Text) == 0)
                return;
                
            Productos producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            if (producto == null)
            {
                MessageBox.Show("Producto No Existe,Se Agregara Un Producto Nuevo A Guardar La Compra","Informacion",MessageBoxButton.OK,MessageBoxImage.Information);
                DescripcionTextBox.Text = "";
            }
            else
            {
                DescripcionTextBox.Text = producto.Descripcion;
                PrecioTextBox.Text = producto.Precio.ToString();
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

            if (CantidadTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
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
            if (CantidadTextBox.Text.Length == 0 | Convert.ToInt32(CantidadTextBox.Text) == 0)
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

        private void BucarButton_Click(object sender, RoutedEventArgs e)
        {
            Compras encontrado = ComprasBLL.Buscar(compra.CompraId);

            if (encontrado != null)
            {
                compra = encontrado;
                Cargar();
            }
            else
            {
                Limpiar();
                MessageBox.Show("La Compra no Existe", "Fallo", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;
            
            compra.CompraDetalle.Add(new ComprasDetalles(Convert.ToInt32(CompraIdTextBox.Text), 
                Convert.ToInt32(ProductoIdTextBox.Text), Convert.ToInt32(CantidadTextBox.Text),
                DescripcionTextBox.Text,Convert.ToDecimal(PrecioTextBox.Text)));
            Cargar();

           /* venta.CostoTotal = venta.CostoTotal + (producto.Costo * Convert.ToInt32(CantidadTextBox.Text));
            TotalLabel.Content = venta.CostoTotal.ToString();
            */
            TotalLabel.Content = Convert.ToString(Convert.ToDecimal(TotalLabel.Content) + (Convert.ToDecimal(PrecioTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text)));

            LimpiarDetalle();

        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                compra.CompraDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
            /*if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                compra.CompraDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                Cargar();
            }*/
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Compras esValido = ComprasBLL.Buscar(compra.CompraId);

            return (esValido != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            // bool paso = false;

            compra.SuplidorId = Convert.ToInt32(SuplidorIdComboBox.SelectedValue);
            compra.Monto = Convert.ToDecimal(TotalLabel.Content.ToString());
            compra.ITBIS = 0.18;

            if (compra.CompraId == 0)
            {
                MessageBox.Show("Algo salio mal.", "Error.", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            else
            {
                ComprasBLL.Guardar(compra);
               // paso = ProductosBLL.Guardar(productos);
                Limpiar();
                MessageBox.Show("Guardado.", "Exito.", MessageBoxButton.OK, MessageBoxImage.Information);
                
            }
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            TotalLabel.Content = Convert.ToInt32(SuplidorIdComboBox.SelectedValue).ToString();
        }

        private void PrecioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }

        private void TransporteTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }

        private void ProductoIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }

        private void CantidadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }

        private void CompraIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }
    }
}
