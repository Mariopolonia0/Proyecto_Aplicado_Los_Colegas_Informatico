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
    /// Interaction logic for cVendedores.xaml
    /// </summary>
    public partial class cVendedores : Window
    {
        public cVendedores()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Vendedores>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //ProductoId
                        listado = VendedoresBLL.GetList(v => v.VendedorId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                    case 1: //Nombres                       
                        listado = VendedoresBLL.GetList(v => v.Nombres.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    case 2: //Apellidos                       
                        listado = VendedoresBLL.GetList(v => v.Apellidos.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;

                    /*case 3: //UsuarioId                       
                        listado = VendedoresBLL.GetList(v => v.UsuarioId.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                        break;*/
                }
            }
            else
            {
                listado = VendedoresBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
