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

namespace ProyectoFinalAplicada1.UI.Consultas
{
    /// <summary>
    /// Interaction logic for cSuplidores.xaml
    /// </summary>
    public partial class cSuplidores : Window
    {
        public cSuplidores()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Suplidores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //SuplidorId
                        listado = SuplidoresBLL.GetList(p => p.SuplidorId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //NombreRepresentante                       
                        listado = SuplidoresBLL.GetList(p => p.NombreRepresentante.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    case 2: //Compañia                       
                        listado = SuplidoresBLL.GetList(p => p.Compania.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                         break;
                }
            }
            else
            {
                listado = SuplidoresBLL.GetList(c => true);
            }

            if (EntradaDatePicker.SelectedDate != null)
                listado = SuplidoresBLL.GetList(c => c.Fecha.Date >= EntradaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
