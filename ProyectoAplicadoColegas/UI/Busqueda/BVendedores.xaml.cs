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
    /// Interaction logic for BVendedores.xaml
    /// </summary>
    public partial class BVendedores : Window
    {
        public int vendedorid = 0;
        public BVendedores()
        {
            InitializeComponent();
            //BuscarProductoDataGrid = null;
            BuscarVendedorDataGrid.ItemsSource = VendedoresBLL.GetVendedores();
        }

        private void BuscarSuplidores()
        {
            var listado = new List<Ventas>();

            if (CriterioTextBoxBuscarVendedor.Text.Trim().Length > 0)
            {
                switch (FiltroComboBoxBuscarVendedor.SelectedIndex)
                {
                    case 0: //ProductoId
                        listado = VentasBLL.GetList(p => p.VentaId == Utilidades.ToInt(CriterioTextBoxBuscarVendedor.Text));
                        DesdeDataPicker.SelectedDate = null;
                        HastaDatePicker.SelectedDate = null;
                        break;

                }
            }
            else
            {
                listado = VentasBLL.GetList(c => true);
            }
            if (listado == null)
            {
                if (DesdeDataPicker.SelectedDate != null)
                    listado = VentasBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

                if (HastaDatePicker.SelectedDate != null)
                    listado = VentasBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            BuscarVendedorDataGrid.ItemsSource = null;
            BuscarVendedorDataGrid.ItemsSource = listado;
        }

        private void enter(object sender, MouseEventArgs e)
        {
            CriterioTextBoxBuscarVendedor.Text = null;
            FiltroComboBoxBuscarVendedor.SelectedItem = null;
        }

        private void limpiar(object sender, MouseEventArgs e)
        {
            CriterioTextBoxBuscarVendedor.Text = null;
            FiltroComboBoxBuscarVendedor.SelectedItem = null;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            BuscarSuplidores();
        }

        private void BuscarSuplidorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            vendedorid = ((Vendedores)BuscarVendedorDataGrid.SelectedItem).VendedorId;
            this.Close();
        }

        public int GetSuplidorIdEncotrado()
        {
            return vendedorid;
        }
    }
}
