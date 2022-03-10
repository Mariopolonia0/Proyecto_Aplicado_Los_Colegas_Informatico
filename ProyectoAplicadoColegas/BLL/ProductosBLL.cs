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

        public static int SiguienteIdProducto()
        {
            Contexto contexto = new Contexto();
            int idnuevo = 0;
            try
            {
                idnuevo = contexto.Productos.Max(c => c.ProductoId) + 1;
            }
            catch (Exception)
            {
                idnuevo = 100;
            }
            finally
            {
                contexto.Dispose();
            }
            return idnuevo;

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
                return Insertar(productos);
            else
                return Modificar(productos);
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
                    productos.disponible = false;
                    key = Modificar(productos);
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
                if (productos == null)
                    return null;
                if (productos.disponible == false)
                    return null;
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
        public static Productos BuscarDescripcion(String descripcion)
        {
            Contexto contexto = new Contexto();
            Productos productos;

            try
            {
                productos = contexto.Productos.Where(p => p.Descripcion.Contains(descripcion)).First();
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
        public static bool DuplicadoDescripcion(string descripcion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Productos.Any(c => c.Descripcion.Equals(descripcion));
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

        public static List<Productos> GetProductos() {

            Contexto contexto = new Contexto();
            List<Productos> productos = new List<Productos>();

            try
            {
                foreach (var C in contexto.Productos.ToList())
                {
                    if (C.disponible == true)
                        productos.Add(C);
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

            return productos;
        }


        public static List<Productos> BuscarListaDescripcion(string descripcion)
        {
            Contexto contexto = new Contexto();
            List<Productos> productoslista = new List<Productos>();

            try
            {
                foreach(var C in contexto.Productos.Where(p => p.Descripcion.Contains(descripcion)).ToList())
                {
                    if (C.disponible == true)
                        productoslista.Add(C);
                }
            }
            catch (Exception)
            {
                return null;// throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return productoslista;
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
