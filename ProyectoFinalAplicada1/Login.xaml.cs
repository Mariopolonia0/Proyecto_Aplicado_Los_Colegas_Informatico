using ProyectoFinalAplicada1.BLL;
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

namespace ProyectoFinalAplicada1
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        

        public Login()
        {
            InitializeComponent();
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = UsuariosBLL.Autorizar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

            if (paso)
            {
                MainWindow Principal = new MainWindow();
                this.Close();
                Principal.Show();
            }
            else
            {
                MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                ContrasenaPasswordBox.Clear();
                NombreUsuarioTextBox.Focus();
            }
        }

        private void CancelarButton_Click(object sender, RoutedEventArgs e)
        {
            base.OnClosed(e);
            Application.Current.Shutdown();
        }

        private void NombreUsuarioTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ContrasenaPasswordBox.Focus();
            }
        }

        private bool Validar()
        {
            bool esValido = true;

            if (NombreUsuarioTextBox.Text.Length == 0)
            {
                esValido = false;
                MessageBox.Show("Usuario está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                NombreUsuarioTextBox.Focus();
            }

            return esValido;
        }

        private void ContrasenaPasswordBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (!Validar())
                return;

            if (e.Key == Key.Enter)
            {
                bool paso = UsuariosBLL.Autorizar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);
                if (paso)
                {
                    
                    MainWindow Principal = new MainWindow();
                    this.Close();
                    Principal.Show();
                }
                else
                {
                    MessageBox.Show("Error Nombre Usuario o Contraseña incorrecta!", "Error!");
                    ContrasenaPasswordBox.Clear();
                    NombreUsuarioTextBox.Focus();
                }
            }
        }
        //
        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta Luego");
            this.Close();
        }
    }
}
