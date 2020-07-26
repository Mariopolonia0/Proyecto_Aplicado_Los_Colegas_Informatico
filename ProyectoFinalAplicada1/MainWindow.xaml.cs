using ProyectoFinalAplicada1.Entidades;
using ProyectoFinalAplicada1.UI.Consultas;
using ProyectoFinalAplicada1.UI.Registro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProyectoFinalAplicada1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        
        public MainWindow()
        {

            InitializeComponent();
           
        }

        private void UsuariosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rUsuarios usuarios = new rUsuarios();
            usuarios.Show()  ;
        }

        private void UsuarioMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cUsuarios usuarios = new cUsuarios();
            usuarios.Show();
        }

        private void ClienteMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCliente cliente = new rCliente();
            cliente.Show();
        }

        private void VendedorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rVendedores vendedores = new rVendedores();
            vendedores.Show();
        }

        private void ProductosMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rProductos productos = new rProductos();
            productos.Show();
        }

        private void FacturasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rFacturas facturas = new rFacturas();
            facturas.Show();
        }
    }
}
