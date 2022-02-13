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

        private void VentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rVentas ventas = new rVentas();
            ventas.Show();
        }

        private void CategoriasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCategorias categorias = new rCategorias();
            categorias.Show();
        }

        private void VendedoresMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVendedores vendedores = new cVendedores();
            vendedores.Show();
        }

        private void CategoriaMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cCategorias categorias = new cCategorias();
            categorias.Show();
        }

        private void ClientesMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cClientes clientes = new cClientes();
            clientes.Show();
        }

        private void ProductoMenuItem_Click_1(object sender, RoutedEventArgs e)
        {
            cProductos cproductos = new cProductos();
            cproductos.Show();
        }

        private void cVentasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            cVentas ventas = new cVentas();
            ventas.Show();
        }

        private void ComprasMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rCompras compras = new rCompras();
            compras.Show();
        }

        private void SuplidorMenuItem_Click(object sender, RoutedEventArgs e)
        {
            rSuplidor suplidor = new rSuplidor();
            suplidor.Show();
        }
    }
}
