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
    /// Interaction logic for cProductos.xaml
    /// </summary>
    public partial class cProductos : Window
    {
        public cProductos()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Productos>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //ProductoId
                        listado = ProductosBLL.GetList(p => p.ProductoId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Descripcion                       
                        listado = ProductosBLL.GetList(p => p.Descripcion.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    /*case 2: //Categoria                       
                            listado = ProductosBLL.GetList(p => p.CategoriaId.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;*/
                }
            }
            else
            {
                listado = ProductosBLL.GetList(c => true);
            }

            if (EntradaDatePicker.SelectedDate != null)
                listado = ProductosBLL.GetList(c => c.FechaEntrada.Date >= EntradaDatePicker.SelectedDate);

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
    
}
