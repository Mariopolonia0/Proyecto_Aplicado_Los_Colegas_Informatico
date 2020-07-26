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
    /// Interaction logic for rVentas.xaml
    /// </summary>
    public partial class rVentas : Window
    {
        Ventas venta = new Ventas();
        public rVentas()
        {
            InitializeComponent();
            this.DataContext = venta;
            VentaIdTextBox.Text = "0";
        }

        private void ProductoIdTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (ProductoIdTextBox.Text.Length == 0)
                return;

            Productos producto = ProductosBLL.Buscar(Convert.ToInt32(ProductoIdTextBox.Text));
            if (producto == null)
            {
                MessageBox.Show("producto no existe");
                DescripcionTextBox.Text = "";
            }
            else
            {
                DescripcionTextBox.Text = producto.Descripcion;
            }            
        }

        private void BucarButton_Click(object sender, RoutedEventArgs e)
        {
            var venta = VentasBLL.Buscar(int.Parse(VentaIdTextBox.Text));

            if (venta != null)
            {
                this.venta = venta;
            }
            else
            {
                this.venta = new Entidades.Ventas();
                MessageBox.Show("El Usuario no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

            //Limpiar();
            this.DataContext = this.venta;
        }

        private void Limpiar()
        {
            VentaIdTextBox.Text = "0";
           // NombresTextBox.Text = string.Empty;
           // ApellidosTextBox.Text = string.Empty;
           // UsuarioIdTextBox.Text = 0;
        }


    }
}
