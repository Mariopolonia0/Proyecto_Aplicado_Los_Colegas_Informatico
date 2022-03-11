﻿using ProyectoAplicadoColegas.UI.Busqueda;
using ProyectoFinalAplicada1.BLL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;


namespace ProyectoFinalAplicada1.UI.Registro
{
    /// <summary>
    /// Interaction logic for rVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        Ventas venta = new Ventas();
        Productos producto = new Productos();
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = venta;
            //VentaIdLabel.Content = "0";
            venta.VentaId = VentasBLL.SiguienteIdVenta();
            venta.CostoTotal = 0;
            venta.GananciaTotal = 0;
            venta.ITBISTotal = 0;
            venta.PrecioTotal = 0;
            VendedorIdComboBox.ItemsSource = VendedoresBLL.GetVendedores();
            VendedorIdComboBox.SelectedValuePath = "VendedorId";
            VendedorIdComboBox.DisplayMemberPath = "VendedorId";
        }

        private void Limpiar()
        {
            venta = new Ventas();
            producto = new Productos();
            Cargar();
           /* VentaIdTextBox.Text = "0";
           // ClienteIdTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
            // venta.VentaDetalle = null;
            PrecioTotalLabel.Content = "0";*/
            //VentasDetalleDataGrid.ItemsSource = null;

        }

        private void BucarButton_Click(object sender, RoutedEventArgs e)
        {
            BVentas bVenta = new BVentas();
            bVenta.ShowDialog();

            venta = BVentas.venta;

             //if(bVenta.GetVentasSelect == null)
             //  return;

            if (venta == null)
                return;

            Cargar();
          
            VendedorIdComboBox.SelectedIndex = venta.VendedorId;
            
            var cliente = ClientesBLL.Buscar(venta.ClienteId);
            if (cliente == null)
                return;
            
            NombreClienteTextBox.Text = cliente.Nombres;
            NumeroClienteTextBox.Text = cliente.Telefono;
            ComprobanteFiscalClienteTextBox.Text = cliente.comprobanteFiscal;

        }

        private void Cargar()
        {
            this.DataContext = null;
            this.DataContext = this.venta; 
            
        }

        private void AgregarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            venta.VentaDetalle.Add(new VentasDetalles(Convert.ToInt32(VentaIdLabel.Content), Convert.ToInt32(ProductoIdTextBox.Text), 
                Convert.ToInt32(CantidadTextBox.Text), DescripcionTextBox.Text, producto.Costo));
            
            Cargar();

            venta.CostoTotal = venta.CostoTotal + (producto.Costo * Convert.ToInt32(CantidadTextBox.Text));
            PrecioTotalLabel.Content = venta.CostoTotal.ToString();

            
            venta.ITBISTotal += producto.ITBIS;
            venta.GananciaTotal += producto.Ganancia;
            venta.PrecioTotal += producto.Precio;

            CantidadTextBox.Text = "0";
            ProductoIdTextBox.Text = "0";
            CantidadTextBox.Text = "0";
            DescripcionTextBox.Text = "";
        }
        private void RemoverButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasDetalleDataGrid.SelectedIndex < 0)
                return;

            VentasDetalles ventasDetalles = (VentasDetalles)VentasDetalleDataGrid.SelectedItem;
            venta.CostoTotal -= ventasDetalles.Costo;
            venta.VentaDetalle.RemoveAt(VentasDetalleDataGrid.SelectedIndex);
            PrecioTotalLabel.Content = venta.CostoTotal.ToString();
            Cargar();
            CantidadTextBox.Clear();
        }
        private bool Validar()
        {
          /*  if (VentaIdLabel.Content == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("VentaId está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VentaIdLabel.Focus();
                GuardarButton.IsEnabled = true;
            }*/

            if (DescripcionTextBox.Text.Length == 0)
            {
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
                GuardarButton.IsEnabled = true;
                return false;
            }
            if (CantidadTextBox.Text.Length == 0)
            {
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                GuardarButton.IsEnabled = true;
                return false;
            }

            if (FechaDatePicker.Text.Length == 0)
            {
                
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Fecha está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                FechaDatePicker.Focus();
                GuardarButton.IsEnabled = true;
                return false;
            }
            if (CantidadTextBox.Text.Length == 0 | Convert.ToInt32( CantidadTextBox.Text)==0)
            {
                
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cantidad está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CantidadTextBox.Focus();
                GuardarButton.IsEnabled = true;
                return false;
            }
            return true;
        }

        private bool Validarguardar()
        {
            bool esValido = true;

            /*if (VentaIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Venta Id está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VentaIdTextBox.Focus();
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

            if (NombreClienteTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombre Cliente está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreClienteTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ComprobanteFiscalClienteTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Comprobante Fiscal está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ComprobanteFiscalClienteTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (NumeroClienteTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Numero Cliente está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NumeroClienteTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if(Convert.ToInt32(VendedorIdComboBox.SelectedValue) <= 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("VendedorId está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                VendedorIdComboBox.Focus();
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

            Clientes cliente = new Clientes();
            cliente.Nombres = NombreClienteTextBox.Text;
            cliente.comprobanteFiscal = ComprobanteFiscalClienteTextBox.Text;
            cliente.Telefono = NumeroClienteTextBox.Text;
            cliente.ClienteId = 0;

            venta.ClienteId = ClientesBLL.Insertar(cliente);
            venta.VendedorId = Convert.ToInt32(VendedorIdComboBox.SelectedValue.ToString());
            venta.CostoTotal = Convert.ToDouble(PrecioTotalLabel.Content.ToString());
            venta.VendedorId = VendedorIdComboBox.SelectedIndex;
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

        private void ProductoIdTextBox_Buscar()
        {
           if (ProductoIdTextBox.Text.Length == 0)
                return;

            producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            if (producto != null)
            {
                DescripcionTextBox.Text = producto.Descripcion;
            }
        }

        private void VendedorIdComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vendedores vendedor= VendedoresBLL.Buscar(Convert.ToInt32(VendedorIdComboBox.SelectedValue));
            NombreVendedorLabel.Content = vendedor.Nombres;
            ApellidovendedorLabel.Content = vendedor.Apellidos;
        }

        private void VentaIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }

        private void ClienteIdTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }

        private void ProductoIdTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (Utilidades.ValidarSoloNumeros(e))
                return;
            
            ProductoIdTextBox_Buscar();
        }

        private void CantidadTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            Utilidades.ValidarSoloNumeros(e);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (VentasBLL.Eliminar(venta))
            {
                Limpiar();
                MessageBox.Show("La venta ha sido eliminada!", "Nitido",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar la Venta", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void BucarButtonProductoVenta_Click(object sender, RoutedEventArgs e)
        {
            BProducto bProducto = new BProducto();
            bProducto.ShowDialog();

            if (BProducto.producto == null)
                return;

            producto = BProducto.producto;
            ProductoIdTextBox.Text = producto.ProductoId.ToString();
            DescripcionTextBox.Text = producto.Descripcion;
        }
    }
}
