using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ProyectoFinalAplicada1.DAL;
using ProyectoFinalAplicada1.Entidades;
using System.Linq;
using System.Linq.Expressions;

namespace ProyectoFinalAplicada1.BLL
{
    class SuplidoresBLL
    {
        //Metodo Existe.
        public static bool Existe(int id)
        {
            Contexto contexto = new Contexto();
            bool encontrado = false;

            try
            {
                encontrado = contexto.Suplidores.Any(c => c.SuplidorId == id);
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
       private static bool Insertar(Suplidores suplidor)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                contexto.Suplidores.Add(suplidor);
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
       private static bool Modificar(Suplidores suplidor)
       {
           bool key = false;
           Contexto contexto = new Contexto();

           try
           {

               contexto.Entry(suplidor).State = EntityState.Modified;
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
       public static bool Guardar(Suplidores suplidor)
       {
           if (!Existe(suplidor.SuplidorId))
           {
               return Insertar(suplidor);
           }
           else
           {
               return Modificar(suplidor);
           }
       }

        public static int SiguienteIdSuplidor()
        {
            Contexto contexto = new Contexto();
            int idnuevo = 0;
            try
            {
                idnuevo = contexto.Suplidores.Max(c => c.SuplidorId) + 1;
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

        //Metodo Eliminar.
        public static bool Eliminar(Suplidores suplidor)
        {
            bool key = false;
            Contexto contexto = new Contexto();

            try
            {
                if (suplidor != null)
                {
                    suplidor.disponible = false;
                    contexto.Entry(suplidor).State = EntityState.Modified;
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
        public static Suplidores Buscar(int id)
        {
            Contexto contexto = new Contexto();
            Suplidores suplidor;
            
            try
            {
                suplidor = contexto.Suplidores.Find(id);
                if (suplidor == null)
                    return null;
                if (suplidor.disponible == false)
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

            return suplidor;
        }


        public static List<Suplidores> GetList(Expression<Func<Suplidores, bool>> suplidores)
        {
            List<Suplidores> lista = new List<Suplidores>();
            Contexto contexto = new Contexto();
            try
            {
                foreach(var suplidor in contexto.Suplidores.Where(suplidores).ToList())
                {
                    if (suplidor.disponible == true)
                        lista.Add(suplidor);
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
            return lista;
        }

        public static List<Suplidores> GetSuplidores()
        {
            Contexto contexto = new Contexto();
            List<Suplidores> suplidores = new List<Suplidores>();

            try
            {
                foreach (var suplidor in contexto.Suplidores.ToList())
                {
                    if (suplidor.disponible == true)
                        suplidores.Add(suplidor);
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

            return suplidores;
        }

        public static bool DuplicadoSuplidorId(int id)
        {
            bool paso = false;
            Contexto contexto = new Contexto();

            try
            {
                paso = contexto.Suplidores.Any(u => u.SuplidorId.Equals(id));
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


  
