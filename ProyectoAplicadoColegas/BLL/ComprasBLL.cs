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
    public class ComprasBLL
    {

        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Compras.Any(e => e.CompraId == id);
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

        private static bool Insertar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //Agregar la entidad que se desea insertar al contexto
                contexto.Compras.Add(compras);
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

        public static bool Guardar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                foreach (var item in compras.CompraDetalle)
                {
                    var producto = contexto.Productos.Find(item.ProductoId);
                    if (producto != null)
                    {
                        producto.Existencia += item.Cantidad;
                        contexto.Entry(producto).State = EntityState.Modified;
                        contexto.SaveChanges() ;
                    }
                    else
                    {
                        Productos product = new Productos();
                        product.ProductoId = item.ProductoId;
                        product.Existencia = item.Cantidad;
                        product.Costo = (double)item.Precio;
                        product.Descripcion = item.Descripcion;
                        product.FechaEntrada = compras.Fecha;
                        product.ITBIS = 0.18;
                        product.Ganancia = 0.20;

                        ProductosBLL.Guardar(product);
                        contexto.SaveChanges();
                    }
 
                }
                if (!Existe(compras.CompraId))//si no existe insertamos
                    paso = Insertar(compras);
                else
                    paso = Modificar(compras);

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
        public static bool Modificar(Compras compras)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                //contexto.Database.ExecuteSqlRaw($"Delete FROM ComprasDetalles Where CompraId={compras.CompraId}");
                foreach (var anterior in compras.CompraDetalle)
                {
                    contexto.Entry(anterior).State = EntityState.Added;
                }
                contexto.Entry(compras).State = EntityState.Modified;
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

        public static Compras Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Compras compras = new Compras();

            try
            {
                compras = contexto.Compras.Include(x => x.CompraDetalle)
                    .Where(p => p.CompraId == id)
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

            return compras;
        }
        

        public static bool Eliminar(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                var eliminar = contexto.Compras.Find(id);
                contexto.Entry(eliminar).State = EntityState.Deleted;

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

        public static List<Compras> GetList(Expression<Func<Compras, bool>> compras)
        {
            List<Compras> lista = new List<Compras>();
            Contexto contexto = new Contexto();
            try
            {
                lista = contexto.Compras.Where(compras).ToList();
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
