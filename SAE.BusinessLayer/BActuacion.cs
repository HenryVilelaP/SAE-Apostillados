//--------------------------------------------------------------------------------
//
// Archivo     : BActuacion.cs
// Descripción : Lógica de negocio de Actuacions.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : 
//--------------------------------------------------------------------------------

using SAE.EntityLayer;
using SAE.DataLayer;
using SAE.Nullables;

using System;
using System.Data;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
 

namespace SAE.BusinessLayer
{
    public interface IBActuacion
    {
        void Constructor(string pstrStringConnection);

        int NumeroRegistrosEncontrados(EActuacion objActuacion, NullInt32 pintCodigoUbicacion);
        DataTable ListarActuacionPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion, int intPaginaInicial, int pintNumRegistros);
        DataTable ListarActuaciones(EActuacion objActuacion, NullInt32 pintCodigoUbicacion);
        DataTable ObtieneCorrelativoSerie(EActuacion objActuacion);

        DataTable ListarActuacionConPDFPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion, int intPaginaInicial, int pintNumRegistros);
        int NumeroRegistrosEncontradosConPDF(EActuacion objActuacion, NullInt32 pintCodigoUbicacion);
        DataTable ListarSerieActuacionConPDF();
       
        string InsertarActuacion(EActuacion objActuacions);
        void ModificarActuacion(EActuacion pobjActuacion);
        void ModificarActuacion_X_NumApostilla(EActuacion pobjActuacion);
        void ActualizarNombreArchivoApostilla(string psrtNumeroApostilla, string pstrNombreArchivo, string pstrSituacion, string pstrSerie, string pstrNumeroSerie);
        void EliminarActuacion(int pintCodigo);
        void EliminarActuacionXnumeroApostilla(string pstrNumeroApostilla);
        void ActualizarSituacion(Int32 pintCodigoActuacion, string pstrEstado,Int32 pintCodigoAuditoria);

    }

     [Transaction(TransactionOption.Supported)]
     public class BActuacion : ServicedComponent, IBActuacion
   
    {
        private string gstrStringConnection;

        public BActuacion()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }



        #region Métodos No TranSAEcionales

           public DataTable ObtieneCorrelativoSerie(EActuacion objActuacion)
            {
                IDActuacion objDActuacion = null;
                try
                {
                    objDActuacion = new DActuacion();
                    objDActuacion.Constructor(gstrStringConnection);
                    return objDActuacion.ObtieneCorrelativoSerie(objActuacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                    objDActuacion = null;
                }
            }
           public DataTable ListarActuacionPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion,int intPaginaInicial,int pintNumRegistros)
            {
                IDActuacion objDActuacion = null;
                try
                {
                    objDActuacion = new DActuacion();
                    objDActuacion.Constructor(gstrStringConnection);
                    return objDActuacion.ListarActuacionPaginado(objActuacion, pintCodigoUbicacion,intPaginaInicial,pintNumRegistros);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                    objDActuacion = null;
                }
            }
           public DataTable ListarActuaciones(EActuacion objActuacion,NullInt32 pintCodigoUbicacion)
            {
                IDActuacion objDActuacion = null;
                try
                {
                    objDActuacion = new DActuacion();
                    objDActuacion.Constructor(gstrStringConnection);
                    return objDActuacion.ListarActuaciones(objActuacion, pintCodigoUbicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                    objDActuacion = null;
                }
            }
           public  int NumeroRegistrosEncontrados(EActuacion objActuacion, NullInt32 pintCodigoUbicacion)
            {
                IDActuacion objDActuacion = null;
                try
                {
                    objDActuacion = new DActuacion();
                    objDActuacion.Constructor(gstrStringConnection);
                    return objDActuacion.NumeroRegistrosEncontrados(objActuacion, pintCodigoUbicacion);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                    objDActuacion = null;
                }
            }


           public DataTable ListarActuacionConPDFPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion, int intPaginaInicial, int pintNumRegistros)
           {
               IDActuacion objDActuacion = null;
               try
               {
                   objDActuacion = new DActuacion();
                   objDActuacion.Constructor(gstrStringConnection);
                   return objDActuacion.ListarActuacionConPDFPaginado(objActuacion, pintCodigoUbicacion, intPaginaInicial, pintNumRegistros);
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               finally
               {
                   if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                   objDActuacion = null;
               }
           }
           public int NumeroRegistrosEncontradosConPDF(EActuacion objActuacion, NullInt32 pintCodigoUbicacion)
           {
               IDActuacion objDActuacion = null;
               try
               {
                   objDActuacion = new DActuacion();
                   objDActuacion.Constructor(gstrStringConnection);
                   return objDActuacion.NumeroRegistrosEncontradosConPDF(objActuacion, pintCodigoUbicacion);
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               finally
               {
                   if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                   objDActuacion = null;
               }
           }
           public DataTable ListarSerieActuacionConPDF()
           {
               IDActuacion objDActuacion = null;
               try
               {
                   objDActuacion = new DActuacion();
                   objDActuacion.Constructor(gstrStringConnection);
                   return objDActuacion.ListarSerieActuacionConPDF();
               }
               catch (Exception ex)
               {
                   throw ex;
               }
               finally
               {
                   if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                   objDActuacion = null;
               }
           }

         
        #endregion

        #region Métodos Transaccionales
       
        public string InsertarActuacion(EActuacion objActuacion)
        {
            IPrimitiveTransaction objTx = null;
            IDActuacion objDActuacion = null;
            string pstrNumeroApostilla="";
            try
            {
                objTx = new PrimitiveTransaction();
                objDActuacion = new DActuacion();
                objTx.BeginTransaction(this.gstrStringConnection);
                pstrNumeroApostilla=objDActuacion.InsertarActuacion(objTx.Transaction, objActuacion);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDActuacion = null;
                objTx = null;
            }
            return pstrNumeroApostilla;

        }



        public void ActualizarSituacion(Int32 pintCodigoActuacion, string pstrSituacion, Int32 pintAuditoria)
        {
            IPrimitiveTransaction objTx = null;
            IDActuacion objDActuacion = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDActuacion = new DActuacion();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDActuacion.ActualizarSituacion(objTx.Transaction, pintCodigoActuacion, pstrSituacion, pintAuditoria);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDActuacion = null;
                objTx = null;
            }
        }

        public void ActualizarNombreArchivoApostilla(string psrtNumeroApostilla, string pstrNombreArchivo, string pstrSituacion, string pstrSerie, string pstrNumeroSerie)
        {
            IPrimitiveTransaction objTx = null;
            IDActuacion objDActuacion = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDActuacion = new DActuacion();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDActuacion.ActualizarNombreArchivoApostilla(objTx.Transaction, psrtNumeroApostilla, pstrNombreArchivo, pstrSituacion, pstrSerie, pstrNumeroSerie);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDActuacion = null;
                objTx = null;
            }
        }
        public void ModificarActuacion(EActuacion pobjActuacion)
        {
            IPrimitiveTransaction objTx = null;
            IDActuacion objDActuacion = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDActuacion = new DActuacion();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDActuacion.ModificarActuacion(objTx.Transaction, pobjActuacion);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDActuacion = null;
                objTx = null;
            }
        }
        public void ModificarActuacion_X_NumApostilla(EActuacion pobjActuacion)
        {
            IPrimitiveTransaction objTx = null;
            IDActuacion objDActuacion = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDActuacion = new DActuacion();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDActuacion.ModificarActuacion_X_Apostilla(objTx.Transaction, pobjActuacion);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDActuacion != null) ((IDisposable)objDActuacion).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDActuacion = null;
                objTx = null;
            }
        }
        public void EliminarActuacion(int pintCodigo)
        {
            IPrimitiveTransaction objTx = null;
            IDActuacion objDActuacion = null;
            string strResultado = string.Empty;
            try
            {

                objTx = new PrimitiveTransaction();
                objDActuacion = new DActuacion();
                
                objTx.BeginTransaction(this.gstrStringConnection);
                objDActuacion.EliminarActuacion(objTx.Transaction, pintCodigo);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDActuacion != null)
                    ((IDisposable)objDActuacion).Dispose();
                if (objTx != null)
                    ((IDisposable)objTx).Dispose();
                objDActuacion = null;
                objTx = null;
            }
        }
        public void EliminarActuacionXnumeroApostilla(string pstrNumeroApostilla)
        {
            IPrimitiveTransaction objTx = null;
            IDActuacion objDActuacion = null;
            string strResultado = string.Empty;
            try
            {

                objTx = new PrimitiveTransaction();
                objDActuacion = new DActuacion();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDActuacion.EliminarActuacionXnumeroApostilla(objTx.Transaction, pstrNumeroApostilla);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDActuacion != null)
                    ((IDisposable)objDActuacion).Dispose();
                if (objTx != null)
                    ((IDisposable)objTx).Dispose();
                objDActuacion = null;
                objTx = null;
            }
        }

        #endregion


    }
}
