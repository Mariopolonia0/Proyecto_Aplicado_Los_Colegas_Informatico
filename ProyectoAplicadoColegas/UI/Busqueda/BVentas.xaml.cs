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

namespace ProyectoAplicadoColegas.UI.Busqueda
{
    /// <summary>
    /// Interaction logic for BVentas.xaml
    /// </summary>
    public partial class BVentas : Window
    {

        public static Ventas venta = new Ventas();
        public BVentas()
        {
            InitializeComponent();
            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = VentasBLL.GetVentas();
        }

        private void Buscar(object sender, RoutedEventArgs e)
        {
            var listado = new List<Ventas>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //ProductoId
                        listado = VentasBLL.GetList(p => p.VentaId == Utilidades.ToInt(CriterioTextBox.Text));
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

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
        private void enter(object sender, MouseEventArgs e)
        {
            CriterioTextBox.Text = null;
            FiltroComboBox.SelectedItem = null;
        }

        private void limpiar(object sender, MouseEventArgs e)
        {
            CriterioTextBox.Text = null;
            FiltroComboBox.SelectedItem = null;
        }

        private void GetVentaSeleccionada(object sender, SelectionChangedEventArgs e)
        {
            int ventaid = ((Ventas)DatosDataGrid.SelectedItem).VentaId;
            venta = VentasBLL.Buscar(ventaid);
            this.Close();
        }
        public Ventas GetVentasSelect()
        {
            return venta;
        }
    }
}
