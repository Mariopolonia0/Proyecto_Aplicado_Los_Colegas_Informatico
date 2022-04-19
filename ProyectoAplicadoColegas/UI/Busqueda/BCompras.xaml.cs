using ProyectoFinalAplicada1.BLL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ProyectoAplicadoColegas.UI.Busqueda
{
    /// <summary>
    /// Interaction logic for BCompras.xaml
    /// </summary>
    public partial class BCompras : Window
    {
        public static Compras compras;// = new Compras();
      
        public BCompras()
        {
            InitializeComponent();
            compras = new Compras();
            DatosDataGridBuscarCompras.ItemsSource = null;
            DatosDataGridBuscarCompras.ItemsSource = ComprasBLL.GetCompra();
        }
        private void Buscar()
        {
            var listado = new List<Compras>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //CompraId
                        listado = ComprasBLL.GetList(p => p.CompraId == Utilidades.ToInt(CriterioTextBox.Text));
                        DesdeDataPicker.SelectedDate = null;
                        HastaDatePicker.SelectedDate = null;
                        break;

                    case 1: //Suplidor ID
                        listado = ComprasBLL.GetList(p => p.SuplidorId == Utilidades.ToInt(CriterioTextBox.Text));
                        DesdeDataPicker.SelectedDate = null;
                        HastaDatePicker.SelectedDate = null;
                        break;
                        

                    case 2: //Monto
                        listado = ComprasBLL.GetList(p => p.Monto == Convert.ToDecimal(CriterioTextBox.Text.ToString()));
                        DesdeDataPicker.SelectedDate = null;
                        HastaDatePicker.SelectedDate = null;
                        break;
                }
            }
            else
            {
                listado = ComprasBLL.GetList(c => true);
            }
            if (listado == null)
            {
                if (DesdeDataPicker.SelectedDate != null)
                    listado = ComprasBLL.GetList(c => c.Fecha.Date >= DesdeDataPicker.SelectedDate);

                if (HastaDatePicker.SelectedDate != null)
                    listado = ComprasBLL.GetList(c => c.Fecha.Date <= HastaDatePicker.SelectedDate);
            }

            DatosDataGridBuscarCompras.ItemsSource = null;
            DatosDataGridBuscarCompras.ItemsSource = listado;
        }
        private void enterBComprar(object sender, MouseEventArgs e)
        {
            CriterioTextBox.Text = null;
            FiltroComboBox.SelectedItem = null;
        }

        private void limpiarBComprar(object sender, MouseEventArgs e)
        {
            CriterioTextBox.Text = null;
            FiltroComboBox.SelectedItem = null;
        }

        private void GetComprasSeleccionada(object sender, SelectionChangedEventArgs e)
        {
            int compraid = ((Compras)DatosDataGridBuscarCompras.SelectedItem).CompraId;
            compras = ComprasBLL.Buscar(compraid);
            this.Close();
        }
        public Compras GetVentasSelect()
        {
            return compras;
        }

        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            Buscar();
        }
    }
}
