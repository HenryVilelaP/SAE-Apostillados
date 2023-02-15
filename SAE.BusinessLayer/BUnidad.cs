//--------------------------------------------------------------------------------
// MRE
// Sistema ......
//
// Archivo     : BUnidad.cs
// Descripción : Lógica de negocio de Unidad.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : 
//--------------------------------------------------------------------------------

using SAE.EntityLayer.Collections;
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
    public interface IBUnidad
    {
        void Constructor(string pstrStringConnection);
        IEUnidadCollection ListarUnidad(IEUnidad objUnidad);
        void Insertar(IEUnidad pobjUnidad);
        void Actualizar(IEUnidad pobjUnidad);
        void Eliminar(Int32 pi_codigo);


    }

    [Transaction(TransactionOption.Supported)]
    public class BUnidad : ServicedComponent, IBUnidad
    {
        private string gstrStringConnection;

        public BUnidad()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales



        public IEUnidadCollection ListarUnidad(IEUnidad objUnidad)
        {
            IDUnidad objDUnidad = null;
            try
            {
                objDUnidad = new DUnidad();
                objDUnidad.Constructor(gstrStringConnection);

                return objDUnidad.ListarUnidad(objUnidad);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDUnidad != null) ((IDisposable)objDUnidad).Dispose();
                objDUnidad = null;
            }
        }

        


        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEUnidad pobjUnidad)
        {
            IDUnidad objDUnidad = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDUnidad = new DUnidad();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDUnidad.Insertar(objTx.Transaction, pobjUnidad);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objTx = null;

                if (objDUnidad != null) ((IDisposable)objDUnidad).Dispose();
                objDUnidad = null;
            }
        }
        public void Actualizar(IEUnidad pobjUnidad)
        {
            IDUnidad objDUnidad = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDUnidad = new DUnidad();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDUnidad.Actualizar(objTx.Transaction, pobjUnidad);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw new Exception(ex.Message);
            }
            finally
            {
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objTx = null;

                if (objDUnidad != null) ((IDisposable)objDUnidad).Dispose();
                objDUnidad = null;
            }
        }


        public void Eliminar(Int32 pi_codigo)
        {
            IDUnidad objDUnidad = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDUnidad = new DUnidad();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                objDUnidad.Eliminar(objTx.Transaction, pi_codigo);


                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objTx = null;

                if (objDUnidad != null) ((IDisposable)objDUnidad).Dispose();
                objDUnidad = null;
            }
        }

        #endregion
    }
}
