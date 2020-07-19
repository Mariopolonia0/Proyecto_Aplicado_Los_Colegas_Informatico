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
        private Usuarios usuarios = new Usuarios();
        
        public cUsuarios()
        {
            InitializeComponent();
            this.DataContext = usuarios;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {

            switch (SeleccionComboBox.SelectedIndex)
            {

                case 0:
                    {
                        MessageBox.Show("EN LA PROXIMA ACTULIZACION PODRA TODOS LOS USUARIOS", "AVISO", MessageBoxButton.OK, MessageBoxImage.Information);
                        return;
                        /*
                        var listado = new List<Usuarios>();
                    
                        DetalleDataGrid.ItemsSource = null;
                        DetalleDataGrid.ItemsSource = listado;


                        break;
                        */
                    }

                case 1:
                    { 
                        if (BusquedaTextBox.Text.Length == 0)
                        {
                            MessageBox.Show("Falta Id Para Buscar","ERROR DATO",MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            var listado = new List<Usuarios>();

                            listado = UsuariosBLL.GetList(e => e.UsuarioId == Utilidades.ToInt(BusquedaTextBox.Text));
                    
                            DetalleDataGrid.ItemsSource = null;
                            DetalleDataGrid.ItemsSource = listado;

                        }
                        break;
                    }

                case 2:
                    { 
                        if (BusquedaTextBox.Text.Length == 0)
                        {
                            MessageBox.Show("Falta Nombre Para Buscar","ERROR DATO", MessageBoxButton.OK, MessageBoxImage.Error);
                            return;
                        }
                        else
                        {
                            MessageBox.Show("EN LA PROXIMA ACTULIZACION PODRA BUSCAR POR NOMBRE", "AVISO", MessageBoxButton.OK, MessageBoxImage.Information);
                            return;
                            /*
                            var listado = new List<Usuarios>();
                            listado = UsuariosBLL.GetList(e => e.Nombres.Contains(BusquedaTextBox.Text, StringComparison.OrdinalIgnoreCase));

                            DetalleDataGrid.ItemsSource = null;
                            DetalleDataGrid.ItemsSource = listado;
                            */
                        }

                        break;
                    }
            }

            

              

            
            

            /*
            else (SeleccionComboBox.SelectedIndex == 2) 
                busquedaTextBox.Text = "Nombre";
            




            /*  var listado = new List<Usuarios>();

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
              */
            /* if (DesdeDataPicker.SelectedDate != null)
                 listado = UsuariosBLL.GetList(c => c.UsuarioId.int >= DesdeDataPicker.SelectedDate);

             if (HastaDatePicker.SelectedDate != null)
                 listado = UsuariosBLL.GetList(c => c.UsuarioId.Date <= HastaDatePicker.SelectedDate);*/

            //DatosDataGrid.ItemsSource = null;
           // DatosDataGrid.ItemsSource = listado;

        }

        
    }
}
