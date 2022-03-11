using ProyectoAplicadoColegas.UI.Busqueda;
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
        Productos producto = new Productos();
        public rCompras()
        {
            InitializeComponent();
            compra.CompraId = ComprasBLL.SiguienteIdCompra();
            this.DataContext = compra;
            DescripcionTextBox.Text = "0";
            CantidadTextBox.Text = "0";
        }
        public void Limpiar()
        {
            compra = new Compras();
            producto = new Productos();
            compra.CompraId = ComprasBLL.SiguienteIdCompra();
            NCFSuplidorLabel.Content = "";
            NombreSuplidoraLabel.Content = "";
            CompaniaSuplidorLabel.Content = "";
            PrecioTextBox.Text = "0";
            DescripcionTextBox.Clear();
            CantidadTextBox.Clear();
            ProductoIdTextBox.Clear();
            Cargar();
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
            Suplidores suplidor = SuplidoresBLL.Buscar(compra.SuplidorId);
            if(suplidor != null)
                cargarSuplidor(suplidor);
        }

        private void ProductoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProductoIdTextBox.Text.Length == 0)
                return;
            else if (Convert.ToInt32(ProductoIdTextBox.Text) == 0)
                return;

            Productos producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            if (producto != null)
            {
                DescripcionTextBox.Text = producto.Descripcion;
                PrecioTextBox.Text = producto.Costo.ToString();
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
            BCompras bCompras = new BCompras();
            bCompras.ShowDialog();

            compra = BCompras.compras;

            if (compra != null)
                Cargar();
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            compra.CompraDetalle.Add(new ComprasDetalles(Convert.ToInt32(CompraIdLabel.Content),
                Convert.ToInt32(ProductoIdTextBox.Text), Convert.ToInt32(CantidadTextBox.Text),
                DescripcionTextBox.Text, Convert.ToDecimal(PrecioTextBox.Text)));
            Cargar();
            TotalLabel.Content = Convert.ToString(Convert.ToDecimal(TotalLabel.Content) + (Convert.ToDecimal(PrecioTextBox.Text) * Convert.ToDecimal(CantidadTextBox.Text)));

            LimpiarDetalle();

        }

        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (DetalleDataGrid.Items.Count >= 1 && DetalleDataGrid.SelectedIndex <= DetalleDataGrid.Items.Count - 1)
            {
                compra.CompraDetalle.RemoveAt(DetalleDataGrid.SelectedIndex);
                compra.Monto -= ((ComprasDetalles)DetalleDataGrid.SelectedItem).Total;
                Cargar();
            }
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private bool ExisteEnLaBaseDeDatos()
        {
            Compras esValido = ComprasBLL.Buscar(compra.CompraId);

            return (esValido != null);
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
           //compra.SuplidorId = Convert.ToInt32(SuplidorIdLabel.Content);
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

        private void BucarButtonProductoCompra_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = new BProducto();
            bProducto.ShowDialog();

            if (BProducto.producto == null)
                return;

            producto = BProducto.producto;
            ProductoIdTextBox.Text = producto.ProductoId.ToString();
            DescripcionTextBox.Text = producto.Descripcion;
            PrecioTextBox.Text = producto.Costo.ToString();
        }

        private void BucarButtonSuplidorCompra_Click(object sender, RoutedEventArgs e)
        {
            BSuplidor bSuplidor = new BSuplidor();
            bSuplidor.ShowDialog();

            if (bSuplidor.GetSuplidorIdEncotrado() == 0)
                return;

            compra.SuplidorId = bSuplidor.GetSuplidorIdEncotrado();
            Cargar();
        }

        private void cargarSuplidor(Suplidores suplidor)
        { 
            CompaniaSuplidorLabel.Content = suplidor.Compania;
            NombreSuplidoraLabel.Content = suplidor.NombreRepresentante;
            NCFSuplidorLabel.Content = suplidor.NCF;
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            //TotalLabel.Content = Convert.ToInt32(SuplidorIdComboBox.SelectedValue).ToString();
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
