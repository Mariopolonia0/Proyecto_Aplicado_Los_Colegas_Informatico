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
    /// Interaction logic for cCategorias.xaml
    /// </summary>
    public partial class cCategorias : Window
    {
        public cCategorias()
        {
            InitializeComponent();
        }

        private void ConsultarButton_Click(object sender, RoutedEventArgs e)
        {
            var listado = new List<Categorias>();

            if (CriterioTextBox.Text.Trim().Length > 0)
            {
                switch (FiltroComboBox.SelectedIndex)
                {
                    case 0: //ProductoId
                        listado = CategoriasBLL.GetList(v => v.CategoriaId == Utilidades.ToInt(CriterioTextBox.Text));
                        break;

                        case 2: //Descripcion                       
                            listado = CategoriasBLL.GetList(v => v.Descripcion.Contains(CriterioTextBox.Text, StringComparison.OrdinalIgnoreCase));
                            break;
                }
            }
            else
            {
                listado = CategoriasBLL.GetList(c => true);
            }

            DatosDataGrid.ItemsSource = null;
            DatosDataGrid.ItemsSource = listado;
        }
    }
}
