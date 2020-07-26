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

namespace ProyectoFinalAplicada1.UI.Registro
{
    /// <summary>
    /// Interaction logic for rCliente.xaml
    /// </summary>
    public partial class rCliente : Window
    {
        Clientes clientes = new Clientes();
        public rCliente()
        {
            InitializeComponent();
            this.DataContext = clientes;
            ClienteIdTextBox.Text = "0";
            this.clientes.UsuarioId = 1;
            SexoComboBox.ItemsSource = ClientesBLL.GetClientes();
            SexoComboBox.SelectedValuePath = "Clientes";
            SexoComboBox.DisplayMemberPath = "Sexo";

        }
        //
        private bool Existe()
        {
            Clientes clienteA = ClientesBLL.Buscar(clientes.ClienteId);
            return (clientes != null);
        }
        //
        private void Actualizar()
        {
            this.DataContext = null;
            this.DataContext = clientes;
        }
        //
        private void Limpiar()
        {
            ClienteIdTextBox.Text = "0";
            NombresTextBox.Text = string.Empty;
            EmailTextBox.Text = string.Empty;
            TelefonoTextBox.Text = string.Empty;
            CedulaTextBox.Text = string.Empty;
            DireccionTextBox.Text = string.Empty;
            SexoComboBox.SelectedItem = null;

            //UsuarioIdTextBox.Text = "0";
        }
        //
        private bool Validar()
        {
            bool esValido = true;

            if (NombresTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Nombres está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombresTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (ApellidosTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Apellidos está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                ApellidosTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (EmailTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Email está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                EmailTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (TelefonoTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Telefono está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                TelefonoTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (CedulaTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Cedula está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CedulaTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (DireccionTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Direccion está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DireccionTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (SexoComboBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Sexo está vacia", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                SexoComboBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }
        //
        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var clientes = ClientesBLL.Buscar(int.Parse(ClienteIdTextBox.Text));

            if (clientes != null)
            {
                this.clientes = clientes;
                /*SexoComboBox.SelectedValuePath = "Clientes";
                SexoComboBox.DisplayMemberPath = "Sexo";*/
            }
            else
            {
                this.clientes = new Entidades.Clientes();
                MessageBox.Show("El Usuario no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

            //Limpiar();
            this.DataContext = this.clientes;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = ClientesBLL.Guardar(clientes);

            if (paso)
            {
                Limpiar();
                MessageBox.Show("Transacción exitosa!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("Transacción Fallida", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }

        private void EliminarButton_Click(object sender, RoutedEventArgs e)
        {
            if (ClientesBLL.Eliminar(Convert.ToInt32(ClienteIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Registro eliminado!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar el registro", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
/*
 
  
 por si eladio no queda convesido de la 
 razon de por que quite el idusuario del registro de cliente
 


  <StackPanel Orientation="Horizontal" Grid.Row="8">
            <TextBlock Name="UsuarioIdLabel" Text="UsuarioId" Margin="80,5,5,5" Grid.Row="8" Width="72" />
            <TextBox Name="UsuarioIdTextBox"  Foreground="Blue" Grid.Row="8" Width="76">
                <TextBox.Text>
                    <Binding Path="UsuarioId" UpdateSourceTrigger="PropertyChanged" Mode="TwoWay">
                        <Binding.ValidationRules>
                            <ExceptionValidationRule/>
                        </Binding.ValidationRules>
                    </Binding>
                </TextBox.Text>
            </TextBox>
        </StackPanel>
     
     
     
     */
