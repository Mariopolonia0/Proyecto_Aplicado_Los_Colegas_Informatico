using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada1.DAL;
using ProyectoFinalAplicada1.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace ProyectoFinalAplicada1.BLL
{
    public class VendedoresBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Vendedores.Any(v => v.VendedorId == id);
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

        private static bool Insertar(Vendedores vendedores)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Vendedores.Add(vendedores);
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

        private static bool Modificar(Vendedores vendedores)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(vendedores).State = EntityState.Modified;
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

        public static bool Guardar(Vendedores vendedores)
        {
            if (!Existe(vendedores.VendedorId))
            {
                return Insertar(vendedores);
            }
            else
            {
                return Modificar(vendedores);
            }
        }

        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var vendedores = contexto.Vendedores.Find(id);

                if (vendedores != null)
                {
                    contexto.Vendedores.Remove(vendedores);
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

        public static Vendedores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Vendedores vendedores;

            try
            {
                vendedores = contexto.Vendedores.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return vendedores;
        }

        public static List<Vendedores> GetList(Expression<Func<Vendedores, bool>> criterio)
        {
            List<Vendedores> lista = new List<Vendedores>();
            Contexto contexto = new Contexto();

            try
            {
                lista = contexto.Vendedores.Where(criterio).ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return lista;
        }

        public static List<Vendedores> GetVendedores()
        {
            Contexto contexto = new Contexto();
            List<Vendedores> vendedor = new List<Vendedores>();

            try
            {
                vendedor = contexto.Vendedores.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return vendedor;
        }
        public static bool DuplicadoVendedorId(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Vendedores.Any(u => u.VendedorId.Equals(id));
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
