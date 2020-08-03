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
    /// Interaction logic for rCategorias.xaml
    /// </summary>
    public partial class rCategorias : Window
    {
        Categorias categorias = new Categorias();

        public rCategorias()
        {
            InitializeComponent();
            this.DataContext = categorias;
            CategoriaIdTextBox.Text = "0";
        }

        private void Limpiar()
        {
            CategoriaIdTextBox.Text = "0";
            DescripcionTextBox.Text = string.Empty;
        }

        private bool Existe()
        {
            Categorias vendedor = CategoriasBLL.Buscar(categorias.CategoriaId);
            return (categorias != null);
        }

        private bool Validar()
        {
            bool esValido = true;

            if (CategoriaIdTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("CategoriaId está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                CategoriaIdTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (DescripcionTextBox.Text.Length == 0)
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Descripcion está vacio", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            if (CategoriasBLL.DuplicadoDescripcion(DescripcionTextBox.Text))
            {
                esValido = false;
                GuardarButton.IsEnabled = false;
                MessageBox.Show("Esta Descripcion ya existe!", "Error!",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
                DescripcionTextBox.Clear();
                DescripcionTextBox.Focus();
                GuardarButton.IsEnabled = true;
            }

            return esValido;
        }


        private void BuscarButton_Click(object sender, RoutedEventArgs e)
        {
            var categorias = CategoriasBLL.Buscar(int.Parse(CategoriaIdTextBox.Text));

            if (categorias != null)
            {
                this.categorias = categorias;
            }
            else
            {
                this.categorias = new Entidades.Categorias();
                MessageBox.Show("La Categoria no existe", "Fallo",
                     MessageBoxButton.OK, MessageBoxImage.Information);
                Limpiar();
            }

            //Limpiar();
            this.DataContext = this.categorias;
        }

        private void NuevoButton_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }

        private void GuardarButton_Click(object sender, RoutedEventArgs e)
        {
            if (!Validar())
                return;

            var paso = CategoriasBLL.Guardar(categorias);

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
            if (CategoriasBLL.Eliminar(Convert.ToInt32(CategoriaIdTextBox.Text)))
            {
                Limpiar();
                MessageBox.Show("Categoria eliminada!", "Exito",
                    MessageBoxButton.OK, MessageBoxImage.Information);
            }
            else
                MessageBox.Show("No fue posible eliminar esta Categoria", "Fallo",
                    MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }
}
