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

namespace ProyectoFinalAplicada1.UI
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        MainWindow Principal = new MainWindow();
        
        public Login()
        {
            InitializeComponent();
        }

        private void IngresarButton_Click(object sender, RoutedEventArgs e)
        {
            bool paso = UsuariosBLL.Autorizar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);
            
            if (paso)
            {
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

        private void StackPanel_KeyDown(object sender, KeyEventArgs e)
        {
           // NombreUsuarioTextBox.Focus
        }

        private void ContrasenaPasswordBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                bool paso = UsuariosBLL.Autorizar(NombreUsuarioTextBox.Text, ContrasenaPasswordBox.Password);

                if (paso)
                {
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

        private void Window_Closed(object sender, EventArgs e)
        {
            MessageBox.Show("Hasta Luego");
            this.Close();
        }
    }
}
