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
        public rCliente()
        {
            InitializeComponent();
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
