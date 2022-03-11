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
            compras.disponible = true;

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
                        product.Precio =(double)item.Precio;
                        product.Descripcion = item.Descripcion;
                        product.FechaEntrada = compras.Fecha;
                        product.ITBIS = 0.18;
                        product.Ganancia = 0.5;
                        product.Costo = product.Precio + ((product.Precio * product.Ganancia) + (product.Precio * product.ITBIS));

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
        public static bool Eliminar(Compras compra)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                if (compra != null)
                {
                    compra.disponible = true;
                    contexto.Entry(compra).State = EntityState.Modified;
                    paso = contexto.SaveChanges() > 0;
                }
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

        public static List<Compras> GetCompra()
        {
            List<Compras> ListaCompras = new List<Compras>();
            Contexto contexto = new Contexto();

            try
            {
               //esta for es para solo retonar los clietne que estan visibles
                foreach (var compra in contexto.Compras.ToList())
                {
                    if (compra.disponible == true)
                    {
                        ListaCompras.Add(compra);
                    }
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
            return ListaCompras;
        }
        public static int SiguienteIdCompra()
        {
            Contexto contexto = new Contexto();
            int idnuevo = 0;
            try
            {
                idnuevo = contexto.Compras.Max(c => c.CompraId) + 1;
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
