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
    /// Interaction logic for BSuplidor.xaml
    /// </summary>
    public partial class BSuplidor : Window
    {
        private Suplidores suplidor;
        public BSuplidor()
        {
            InitializeComponent();
            //BuscarProductoDataGrid = null;
            suplidor = new Suplidores();
            BuscarSuplidorDataGrid.ItemsSource = SuplidoresBLL.GetSuplidores();
        }

        private void BuscarSuplidores()
        {
            if (FiltroComboBoxBuscarSuplidor.SelectedIndex == -1)
            {
                MessageBox.Show("Seleccione un opcion en el filtro", "Error");
                return;
            }


            switch (FiltroComboBoxBuscarSuplidor.SelectedIndex)
            {
                case 0:
                    if (!ValidarCriterio())
                        return;
                    int id = Convert.ToInt32(FiltroComboBoxBuscarSuplidor.Text.ToString());
                    Suplidores suplidor = SuplidoresBLL.Buscar(id);
                    if (suplidor == null)
                    {
                        MessageBox.Show("No existe el suplidor", "Error");
                        return;
                    }

                    BuscarSuplidorDataGrid.ItemsSource = null;
                    BuscarSuplidorDataGrid.Items.Add(suplidor);
                    break;

                case 1:
                    BuscarSuplidorDataGrid.ItemsSource = ProductosBLL.BuscarListaDescripcion(FiltroComboBoxBuscarSuplidor.Text.ToString());
                    break;
            }
        }

        private bool ValidarCriterio()
        {
            if (CriterioTextBoxBuscarSuplidor.Text.Length == 0)
            {
                MessageBox.Show(" Criterio Esta vacio", "Error");
                return false;
            }
            if (!Regex.IsMatch(FiltroComboBoxBuscarSuplidor.Text, "^[0-9]+$"))
            {
                MessageBox.Show("Solo se permiten caracteres numericos.",
                    "Campo Criterio.", MessageBoxButton.OK, MessageBoxImage.Error);
                CriterioTextBoxBuscarSuplidor.Clear();
                return false;
            }
            return true;
        }
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            BuscarSuplidores();
        }

        private void BuscarSuplidorDataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            suplidor = (Suplidores)BuscarSuplidorDataGrid.SelectedItem;
            this.Close();
        }

        public Suplidores GetSuplidorEncotrado()
        {
            return suplidor;
        }
        public int GetSuplidorIdEncotrado()
        {
            if (suplidor == null)
                return 0;
            else
                return suplidor.SuplidorId;
        }
    }
}
