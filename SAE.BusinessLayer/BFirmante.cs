//--------------------------------------------------------------------------------
//
// Archivo     : BFirmante.cs
// Descripción : Lógica de negocio de Firmantes.
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
    public interface IBFirmante
    {
        void Constructor(string pstrStringConnection);


        DataTable ListarFirmantes(EFirmante objFirmante);

        DataTable ListarFirmantes_X_Proceso(Int32 pintIdProceso);
        DataTable ListarFirmantes_X_Proceso_Region_Partido(Int32 pintCodigoProceso, Int32 pintCodigoRegion, Int32 pintCodigoPartido);
        DataTable ListarFirmantes_X_Proceso_Encuesta_Pendiente(Int32 pintCodigoProceso);

        void InsertarFirmante(EFirmante objFirmantes);
        void ModificarFirmante(EFirmante pobjFirmante);
        void EliminarFirmante(int pintCodigo);

    }

    [Transaction(TransactionOption.Supported)]
    public class BFirmante : ServicedComponent, IBFirmante
 
    {
        private string gstrStringConnection;

        public BFirmante()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }



        #region Métodos No TranSAEcionales

        public DataTable ListarFirmantes_X_Proceso_Region_Partido(Int32 pintCodigoProceso, Int32 pintCodigoRegion, Int32 pintCodigoPartido)
        {

            IDFirmante objDFirmante = null;
            try
            {
                objDFirmante = new DFirmante();
                objDFirmante.Constructor(gstrStringConnection);
                return objDFirmante.ListarFirmantes_X_Proceso_Region_Partido(pintCodigoProceso, pintCodigoRegion, pintCodigoPartido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                // if (objDFirmante != null) ((IDisposable)objDFirmante).Dispose();
                objDFirmante = null;
            }

        }
        public DataTable ListarFirmantes_X_Proceso(Int32 pintIdProceso)
        {
            IDFirmante objDFirmante = null;
            try
            {
                objDFirmante = new DFirmante();
                objDFirmante.Constructor(gstrStringConnection);
                return objDFirmante.ListarFirmantes_X_Proceso(pintIdProceso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if (objDFirmante != null) ((IDisposable)objDFirmante).Dispose();
                objDFirmante = null;
            }
        }
        public DataTable ListarFirmantes_X_Proceso_Encuesta_Pendiente(Int32 pintCodigoProceso)
        {
            IDFirmante objDFirmante = null;
            try
            {
                objDFirmante = new DFirmante();
                objDFirmante.Constructor(gstrStringConnection);
                return objDFirmante.ListarFirmantes_X_Proceso_Encuesta_Pendiente(pintCodigoProceso);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if (objDFirmante != null) ((IDisposable)objDFirmante).Dispose();
                objDFirmante = null;
            }
        }

        public DataTable ListarFirmantes(EFirmante objFirmante)
        {
            IDFirmante objDFirmante = null;
            try
            {
                objDFirmante = new DFirmante();
                objDFirmante.Constructor(gstrStringConnection);
                return objDFirmante.ListarFirmantes(objFirmante);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               // if (objDFirmante != null) ((IDisposable)objDFirmante).Dispose();
                objDFirmante = null;
            }
        }



        #endregion

        #region Métodos Transaccionales

        public void InsertarFirmante(EFirmante objFirmante)
        {
            IPrimitiveTransaction objTx = null;
            IDFirmante objDFirmante = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDFirmante = new DFirmante();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDFirmante.InsertarFirmante(objTx.Transaction, objFirmante);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDFirmante != null) ((IDisposable)objDFirmante).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDFirmante = null;
                objTx = null;
            }
        }

        public void ModificarFirmante(EFirmante pobjFirmante)
        {
            IPrimitiveTransaction objTx = null;
            IDFirmante objDFirmante = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDFirmante = new DFirmante();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDFirmante.ModificarFirmante(objTx.Transaction, pobjFirmante);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDFirmante != null) ((IDisposable)objDFirmante).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDFirmante = null;
                objTx = null;
            }
        }

        public void EliminarFirmante(int pintCodigo)
        {
            IPrimitiveTransaction objTx = null;
            IDFirmante objDFirmante = null;
            string strResultado = string.Empty;
            try
            {

                objTx = new PrimitiveTransaction();
                objDFirmante = new DFirmante();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDFirmante.EliminarFirmante(objTx.Transaction, pintCodigo);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDFirmante != null)
                    ((IDisposable)objDFirmante).Dispose();
                if (objTx != null)
                    ((IDisposable)objTx).Dispose();
                objDFirmante = null;
                objTx = null;
            }
        }


        #endregion


    }
}
