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
    /// Interaction logic for cClientes.xaml
    /// </summary>
    public partial class cClientes : Window
    {
        public cClientes()
        {
            InitializeComponent();
            
            
            FiltroComboBox.Items.Add("Todos");
            FiltroComboBox.Items.Add("Nombre");
            FiltroComboBox.Items.Add("Comprobante Fiscal");
            FiltroComboBox.SelectedIndex = 0;
        }

       private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Clientes>();
            
            if (CriterioTextBox.Text.Trim().Length >= 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //ClienteId
                        listado = ClientesBLL.GetClientes();
                        break;

                    case 1: //Nombres
                            MessageBox.Show("No Esta Disponible", "Informacion",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                        // listado = ClientesBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        //break;

                    case 2: //Apellidos
                            MessageBox.Show("No Esta Disponible", "Informacion",
                             MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                        //istado = ClientesBLL.GetList(e => e.Apellidos.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                   
                }
            }
            
            ClienteDatosDataGrid.ItemsSource = null;
            ClienteDatosDataGrid.ItemsSource = listado;
        }
    }
}
