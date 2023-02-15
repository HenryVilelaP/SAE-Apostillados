//--------------------------------------------------------------------------------
// SISTEMA DE GESTION CONSULAR - SAE
//
// Archivo     : BModulo.cs
// Descripción : Lógica de negocio de Modulo.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : N/A
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
    public interface IBModulo
    {
        void Constructor(string pstrStringConnection);
        IEModuloCollection ListarModuloXUsuario(Int32 pintCodigoUsuario, string pstrSituacion);
        IEModuloCollection ListarModulo(NullInt32 pintCodSist, string pstrSituacion);
        IEModulo ObtenerModulo(NullInt32 pintCodModulo);


        void Insertar(IEModulo pobjModulo);
        void Actualizar(IEModulo pobjModulo);
        void Eliminar(Int32 pi_codigo);

    }

    [Transaction(TransactionOption.Supported)]
    public class BModulo : ServicedComponent, IBModulo
    {
        private string gstrStringConnection;

        public BModulo()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales


        public IEModuloCollection ListarModulo(NullInt32 pintCodsist, string pstrSituacion)
        {
            IDModulo objDModulo = null;
            try
            {
                objDModulo = new DModulo();
                objDModulo.Constructor(gstrStringConnection);

                return objDModulo.ListarModulo(pintCodsist, pstrSituacion);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDModulo != null) ((IDisposable)objDModulo).Dispose();
                objDModulo = null;
            }
        }

        public IEModuloCollection ListarModuloXUsuario(Int32 pintCodigoUsuario, string pstrSituacion)
        {
            IDModulo objDModulo = null;
            try
            {
                objDModulo = new DModulo();
                objDModulo.Constructor(gstrStringConnection);

                return objDModulo.ListarModuloXUsuario(pintCodigoUsuario, pstrSituacion);

              
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDModulo != null) ((IDisposable)objDModulo).Dispose();
                objDModulo = null;
            }
        }

        public IEModulo ObtenerModulo(NullInt32 pstrCodModulo)
        {
            IDModulo objDModulo = null;
            IEModulo objModulo = null;
           
            try
            {
                objDModulo = new DModulo();
                objDModulo.Constructor(gstrStringConnection);
                //objModulo = objDModulo.ObtenerModulo(pstrCodModulo)[pstrCodModulo.UINullable];

                return objModulo;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDModulo != null) ((IDisposable)objDModulo).Dispose();
                objDModulo = null;
            }
        }


        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEModulo pobjModulo)
        {
            IDModulo objDModulo = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDModulo = new DModulo();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDModulo.Insertar(objTx.Transaction, pobjModulo);
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

                if (objDModulo != null) ((IDisposable)objDModulo).Dispose();
                objDModulo = null;
            }
        }
        public void Actualizar(IEModulo pobjModulo)
        {
            IDModulo objDModulo = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDModulo = new DModulo();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDModulo.Actualizar(objTx.Transaction, pobjModulo);
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

                if (objDModulo != null) ((IDisposable)objDModulo).Dispose();
                objDModulo = null;
            }
        }


        public void Eliminar(Int32 pi_codigo)
        {
            IDModulo objDModulo = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDModulo = new DModulo();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                objDModulo.Eliminar(objTx.Transaction, pi_codigo);
                

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

                if (objDModulo != null) ((IDisposable)objDModulo).Dispose();
                objDModulo = null;
            }
        }

        #endregion
    }
}
