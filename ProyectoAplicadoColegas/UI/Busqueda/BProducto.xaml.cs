using ProyectoFinalAplicada1.BLL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ProyectoAplicadoColegas.UI.Busqueda
{
    /// <summary>
    /// Interaction logic for BProducto.xaml
    /// </summary>
    public partial class BProducto : Window
    {
        public static Productos producto ;
        public BProducto()
        {
            InitializeComponent();
            producto = new Productos();
            BuscarProductoDataGrid.ItemsSource = ProductosBLL.GetProductos();
        }

        private void BuscarProductoDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            producto = (Productos)BuscarProductoDataGrid.SelectedItem;
            this.Close();
        }

        private void BuscarProductos()
        {
            if (FiltroComboBoxBuscarProducto.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un opcion en el filtro", "Error");
                return;
            }
              
            switch (FiltroComboBoxBuscarProducto.SelectedIndex)
            {
                case 0:
                    if (!ValidarCriterio())
                        return;
                    int id = Convert.ToInt32(CriterioTextBoxBuscarProducto.Text.ToString());
                    producto = ProductosBLL.Buscar(id);
                    if (producto == null)
                    {
                        MessageBox.Show("No existe el producto", "Error");
                        return;
                    }
                        
                    BuscarProductoDataGrid.ItemsSource = null;
                    BuscarProductoDataGrid.Items.Add(producto);
                    break;

                case 1:
                    BuscarProductoDataGrid.ItemsSource = ProductosBLL.BuscarListaDescripcion(CriterioTextBoxBuscarProducto.Text.ToString());
                    break;
            }
        }

        private bool ValidarCriterio()
        {
            if (CriterioTextBoxBuscarProducto.Text.Length == 0)
            {
                MessageBox.Show(" Criterio Esta vacio", "Error");
                return false;
            }
            if (!Regex.IsMatch(CriterioTextBoxBuscarProducto.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.",
                    "Campo Criterio.", MessageBoxButton.OK, MessageBoxImage.Error);
                CriterioTextBoxBuscarProducto.Clear();
                return false;
            }
            return true;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            BuscarProductos();
        }
    }
}
