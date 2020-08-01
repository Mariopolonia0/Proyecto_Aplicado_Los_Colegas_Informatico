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
    public class ProductosBLL
    {

        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Productos.Any(c => c.ProductoId == id);
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
        private static bool Insertar(Productos productos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Productos.Add(productos);
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

        //Metodo Modificar.
        private static bool Modificar(Productos productos)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {

                contexto.Entry(productos).State = EntityState.Modified;
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

        //Metodo Guardar.
        public static bool Guardar(Productos productos)
        {
            if (!Existe(productos.ProductoId))
            {
                return Insertar(productos);
            }
            else
            {
                return Modificar(productos);
            }
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var productos = contexto.Productos.Find(id);

                if (productos != null)
                {
                    contexto.Productos.Remove(productos);
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
        public static Productos Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Productos productos;

            try
            {
                productos = contexto.Productos.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return productos;
        }


        public static List<Productos> GetList(Expression<Func<Productos, bool>> productos)
        {
            List<Productos> lista = new List<Productos>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Productos.Where(productos).ToList();
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

    }
}
