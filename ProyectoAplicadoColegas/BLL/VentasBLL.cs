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
    public class VentasBLL
    {
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Ventas.Any(e => e.VentaId == id);
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
        private static bool Insertar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Ventas.Add(ventas);
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
        public static bool Guardar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in ventas.VentaDetalle)
                {
                    var producto = contexto.Productos.Find(item.ProductoId);
                    if (producto != null)
                    {
                        producto.Existencia -= item.Cantidad;
                        contexto.Entry(producto).State = EntityState.Modified;
                    }
                }

                if (!Existe(ventas.VentaId))
                    paso = Insertar(ventas);
                else
                    paso = Modificar(ventas);

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
        public static bool Modificar(Ventas ventas)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //contexto.Database.ExecuteSqlRaw($"DELETE FROM VentasDetalles Where VentaId = {ventas.VentaId}");
                foreach (var anterior in ventas.VentaDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }

                contexto.Entry(ventas).State = EntityState.Modified;
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
        public static Ventas Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Ventas ventas = new Ventas();

            try
            {
                ventas = contexto.Ventas.Include(x => x.VentaDetalle)
                    .Where(p => p.VentaId == id)
                    .SingleOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return ventas;
        }
        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Ventas.Find(id);
                contexto.Entry(eliminar).State = EntityState.Modified;

                paso = (contexto.SaveChanges() > 0);
            }
            catch
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }

            return paso;
        }

        //
        public static List<Ventas> GetVentas()
        {
            List<Ventas> ListaVentas = new List<Ventas>();
            Contexto contexto = new Contexto();

            try
            {
                //obtener la lista y filtrarla según el criterio recibido por parametro.
                ListaVentas = contexto.Ventas.ToList();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                contexto.Dispose();
            }
            return ListaVentas;
        }
        public static int SiguienteIdVenta()
        {
            Contexto contexto = new Contexto();
            int idnuevo = 0;
            try
            {
                idnuevo = contexto.Ventas.Max(c => c.VentaId) + 1;
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
        public static List<Ventas> GetList(Expression<Func<Ventas, bool>> ventas)
        {
            List<Ventas> lista = new List<Ventas>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Ventas.Where(ventas).ToList();
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

    }
}
