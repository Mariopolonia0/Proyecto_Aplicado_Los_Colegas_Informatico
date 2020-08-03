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
    public class CategoriasBLL
    {
        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Categorias.Any(c => c.CategoriaId == id);
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
        private static bool Insertar(Categorias categorias)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Categorias.Add(categorias);
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
        private static bool Modificar(Categorias categorias)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Entry(categorias).State = EntityState.Modified;
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
        public static bool Guardar(Categorias categorias)
        {
            if (!Existe(categorias.CategoriaId))
            {
                return Insertar(categorias);
            }
            else
            {
                return Modificar(categorias);
            }
        }

        //Metodo Eliminar.
        public static bool Eliminar(int id)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                var categorias = contexto.Categorias.Find(id);

                if (categorias != null)
                {
                    contexto.Categorias.Remove(categorias);
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
        public static Categorias Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Categorias categorias;

            try
            {
                categorias = contexto.Categorias.Find(id);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return categorias;
        }

        public static List<Categorias> GetCategorias()
        {
            Contexto contexto = new Contexto();
            List<Categorias> categorias = new List<Categorias>();

            try
            {
                categorias = contexto.Categorias.ToList();
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return categorias;
        }

        public static List<Categorias> GetList(Expression<Func<Categorias, bool>> categorias)
        {
            List<Categorias> lista = new List<Categorias>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Categorias.Where(categorias).ToList();
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

        //Datos duplicado
        public static bool DuplicadoDescripcion(string descripcion)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Categorias.Any(u => u.Descripcion.Equals(descripcion));
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
