//--------------------------------------------------------------------------------
// SISTEMA DE GESTION CONSULAR - SAE
//
// Archivo     : BOpcion.cs
// Descripción : Lógica de negocio de Opcion.
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
    public interface IBOpcion
    {
        void Constructor(string pstrStringConnection);
        IEOpcionCollection ListarOpcionPerfil(NullInt32 pintCodPerfil, Int32 pintCodModulo, NullInt32 pintCodPerfilUsuarioOf);
        IEOpcion ObtenerOpcion(NullInt32 pintCodOpcion);
        int NumeroRegistrosListarOpcion(NullInt32 CodOpcion);
        void Insertar(IEOpcion pobjOpcion);
        void Actualizar(IEOpcion pobjOpcion);
        void Eliminar(Int32 pi_codigo);


    }

    [Transaction(TransactionOption.Supported)]
    public class BOpcion : ServicedComponent, IBOpcion
    {
        private string gstrStringConnection;

        public BOpcion()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales

        public int NumeroRegistrosListarOpcion(NullInt32 CodOpcion)
        {
            try
            {
                DOpcion objDOpcion = null;
                objDOpcion = new DOpcion();
                objDOpcion.Constructor(gstrStringConnection);

                return objDOpcion.FNC_ObtieneNumeroRegistros(CodOpcion);

                //return objDOpcion.ListarOpcion(pstrCodOpcion, pstrNombre, pstrPaterno, pstrMaterno, pstrSituacion,
                //                       pintNumeroPagina, pintNumeroRegistros, out pintRegistrosGenerados);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        public IEOpcionCollection ListarOpcionPerfil(NullInt32 pintCodPerfil, Int32 pintCodModulo, NullInt32 pintCodPerfilUsuarioOf)
        {
            IDOpcion objDOpcion = null;
            try
            {
                objDOpcion = new DOpcion();
                objDOpcion.Constructor(gstrStringConnection);

                return objDOpcion.ListarOpcionPerfil(pintCodPerfil, pintCodModulo, pintCodPerfilUsuarioOf);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDOpcion != null) ((IDisposable)objDOpcion).Dispose();
                objDOpcion = null;
            }
        }

        public IEOpcion ObtenerOpcion(NullInt32 pstrCodOpcion)
        {
            IDOpcion objDOpcion = null;
            IEOpcion objOpcion = null;

            try
            {
                objDOpcion = new DOpcion();
                objDOpcion.Constructor(gstrStringConnection);
                //objOpcion = objDOpcion.ObtenerOpcion(pstrCodOpcion)[pstrCodOpcion.UINullable];

                return objOpcion;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDOpcion != null) ((IDisposable)objDOpcion).Dispose();
                objDOpcion = null;
            }
        }


        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEOpcion pobjOpcion)
        {
            IDOpcion objDOpcion = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDOpcion = new DOpcion();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDOpcion.Insertar(objTx.Transaction, pobjOpcion);
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

                if (objDOpcion != null) ((IDisposable)objDOpcion).Dispose();
                objDOpcion = null;
            }
        }
        public void Actualizar(IEOpcion pobjOpcion)
        {
            IDOpcion objDOpcion = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDOpcion = new DOpcion();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDOpcion.Actualizar(objTx.Transaction, pobjOpcion);
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

                if (objDOpcion != null) ((IDisposable)objDOpcion).Dispose();
                objDOpcion = null;
            }
        }


        public void Eliminar(Int32 pi_codigo)
        {
            IDOpcion objDOpcion = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDOpcion = new DOpcion();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                objDOpcion.Eliminar(objTx.Transaction, pi_codigo);


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

                if (objDOpcion != null) ((IDisposable)objDOpcion).Dispose();
                objDOpcion = null;
            }
        }

        #endregion
    }
}
