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
    /// Interaction logic for cUsuarios.xaml
    /// </summary>
    public partial class cUsuarios : Window
    {
        public cUsuarios()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Usuarios>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //EstudianteId
                        listado = UsuariosBLL.GetList(e => e.UsuarioId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Nombres                       
                        listado = UsuariosBLL.GetList(e => e.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;
                }
            }
            else
            {
                listado = UsuariosBLL.GetList(c => true);
            }

            /*if (DesdeDataPicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.FechaIngreso.Date >= DesdeDataPicker.SelectedDate);

            if (HastaDatePicker.SelectedDate != null)
                listado = UsuariosBLL.GetList(c => c.FechaIngreso.Date <= HastaDatePicker.SelectedDate);*/

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }



    }
}
