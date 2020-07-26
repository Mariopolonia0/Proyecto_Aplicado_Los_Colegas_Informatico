using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada1.DAL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProyectoFinalAplicada1.BLL
{
    public class ClientesBLL
    {
        public static bool Guardar(Clientes clientes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (contexto.Clientes.Add(clientes) != null)
                    paso = contexto.SaveChanges() > 0;
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


        public static Clientes Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Clientes clientes = new Clientes();
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

        internal static IEnumerable GetList(Clientes clientes)
        {
            throw new NotImplementedException();
        }

        public static bool Modificar(Clientes clientes)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                contexto.Entry(clientes).State = EntityState.Modified;
                paso = contexto.SaveChanges() > 0;
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

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();
            try
            {
                var eliminar = contexto.Clientes.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;
                paso = contexto.SaveChanges() > 0;
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

    }
}
