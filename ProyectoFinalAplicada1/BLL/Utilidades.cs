using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Controls;

namespace ProyectoFinalAplicada1.BLL
{
    public class Utilidades
    {
        public static int ToInt(string valor)
        {
            int retorno = 0;
            int.TryParse(valor, out retorno);
            return retorno;
        }

        public static void ValidarSoloLetras(KeyEventArgs v)
        {
            if (Char.IsDigit(Convert.ToChar(v.Key)))
            {
                v.Handled = false;
            }
            else if (Char.IsSeparator(Convert.ToChar(v.Key)))
            {
                v.Handled = false;
            }
            else if (Char.IsControl(Convert.ToChar(v.Key)))
            {
                v.Handled = false;
            }
            else
            {
                v.Handled = true;
                MessageBox.Show("Solo Puede Digitar Letras", "Informacion Importante", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }


             public static bool ValidarSoloNumeros(KeyEventArgs v)
             {
                 
                 if (Char.IsLetter(Convert.ToChar(v.Key)))
                 {
                     v.Handled = false;
                 }
                 else if (Char.IsSeparator(Convert.ToChar(v.Key)))
                 {
                     v.Handled = false;
                 }
                 else if (Char.IsControl(Convert.ToChar(v.Key)))
                 {
                     v.Handled = false;
                 }
                 else
                 {
                     v.Handled = true;
                     MessageBox.Show("Solo Puede Digitar Numero","Informacion Importante",MessageBoxButton.OK,MessageBoxImage.Information);
                 }
                 return v.Handled;
             }
             
        }

    }
    



