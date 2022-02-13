using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada1.DAL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Windows.Automation.Peers;

namespace ProyectoFinalAplicada1.BLL
{
    public class ClientesBLL
    {

        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Clientes.Any(c => c.ClienteId == id);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return encontrado;
        }

        //Metodo Insertar.
        private static bool Insertar(Clientes clientes)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                
                contexto.Clientes.Add(clientes);
                key = contexto.SaveChanges() > 0;
                //contexto.Entry(Item.clientes).State = EntityState.Modified;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        //Metodo Modificar.
        private static bool Modificar(Clientes clientes)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(clientes).State = EntityState.Modified;
                key = contexto.SaveChanges() > 0;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }


        internal static IEnumerable GetList(Clientes clientes)
        {
            throw new NotImplementedException();
        }


        //Metodo Guardar.
        public static bool Guardar(Clientes clientes)
        {
            if (!Existe(clientes.ClienteId))
            {
                return Insertar(clientes);
            }
            else
            {
                return Modificar(clientes);
            }
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var clientes = contexto.Clientes.Find(id);

                if (clientes != null)
                {
                    contexto.Clientes.Remove(clientes);
                    key = contexto.SaveChanges() > 0;
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return key;
        }

        //Metodo Buscar.
        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes clientes;

            try
            {
                clientes = contexto.Clientes.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }

        //
        public static List<Clientes> GetList(Expression<Func<Clientes, bool>> clientes)
        {
            List<Clientes> lista = new List<Clientes>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Clientes.Where(clientes).ToList();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        //
        public static List<Clientes> GetClientes()
        {
            Contexto contexto = new Contexto();
            List<Clientes> clientes = new List<Clientes>();

            try
            {
                clientes = contexto.Clientes.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return clientes;
        }

        //Metodo Datos Duplicados.
        //Email
        public static bool DuplicadoEmail(string email)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Clientes.Any(c => c.Email.Equals(email));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //Telefono
        public static bool DuplicadoTelefono(string telefono)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Clientes.Any(u => u.Telefono.Equals(telefono));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //Telefono
        public static bool DuplicadoCedula(string cedula)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Clientes.Any(u => u.Cedula.Equals(cedula));
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

    }
}
