//--------------------------------------------------------------------------------
//
// Archivo     : BStickerApostillador.cs
// Descripción : Lógica de negocio de StickerApostilladors.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : 
//--------------------------------------------------------------------------------

using SAE.EntityLayer;
using SAE.EntityLayer.Collections;
using SAE.DataLayer;
using SAE.Nullables;

using System;
using System.Data;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
 

namespace SAE.BusinessLayer
{
    public interface IBStickerApostillador
    {
        void Constructor(string pstrStringConnection);


        IEStickerApostilladorCollection ListarStickerAsignados(EStickerApostillador objStickerApostillador);
        DataTable ListarSerie();
        string InsertarStickerApostillador(EStickerApostillador objStickerApostilladors);
        void ModificarStickerApostillador(EStickerApostillador pobjStickerApostillador);
        void ActualizarSituacion(Int32 pintCodigoStickerApostillador, string pstrEstado,Int32 pintCodigoAuditoria);

    }

     [Transaction(TransactionOption.Supported)]
     public class BStickerApostillador : ServicedComponent, IBStickerApostillador
   
    {
        private string gstrStringConnection;

        public BStickerApostillador()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }



        #region Métodos No TranSAEcionales


        public IEStickerApostilladorCollection ListarStickerAsignados(EStickerApostillador objStickerApostillador)
        {
            IDStickerApostillador objDStickerApostillador = null;
            try
            {
                objDStickerApostillador = new DStickerApostillador();
                objDStickerApostillador.Constructor(gstrStringConnection);
                return objDStickerApostillador.ListarStickerAsignados(objStickerApostillador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDStickerApostillador != null) ((IDisposable)objDStickerApostillador).Dispose();
                objDStickerApostillador = null;
            }
        }
        public DataTable ListarSerie()
        {
            IDStickerApostillador objDStickerApostillador = null;
            try
            {
                objDStickerApostillador = new DStickerApostillador();
                objDStickerApostillador.Constructor(gstrStringConnection);
                return objDStickerApostillador.ListarSerie();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDStickerApostillador != null) ((IDisposable)objDStickerApostillador).Dispose();
                objDStickerApostillador = null;
            }
        }



        #endregion

        #region Métodos Transaccionales

        public string InsertarStickerApostillador(EStickerApostillador objStickerApostillador)
        {
            IPrimitiveTransaction objTx = null;
            IDStickerApostillador objDStickerApostillador = null;
            string pstrNumeroApostilla = "";
            try
            {
                objTx = new PrimitiveTransaction();
                objDStickerApostillador = new DStickerApostillador();
                objTx.BeginTransaction(this.gstrStringConnection);
                pstrNumeroApostilla = objDStickerApostillador.InsertarStickerApostillador(objTx.Transaction, objStickerApostillador);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDStickerApostillador != null) ((IDisposable)objDStickerApostillador).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDStickerApostillador = null;
                objTx = null;
            }
            return pstrNumeroApostilla;

        }



        public void ActualizarSituacion(Int32 pintCodigoStickerApostillador, string pstrSituacion, Int32 pintAuditoria)
        {
            IPrimitiveTransaction objTx = null;
            IDStickerApostillador objDStickerApostillador = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDStickerApostillador = new DStickerApostillador();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDStickerApostillador.ActualizarSituacion(objTx.Transaction, pintCodigoStickerApostillador, pstrSituacion, pintAuditoria);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDStickerApostillador != null) ((IDisposable)objDStickerApostillador).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDStickerApostillador = null;
                objTx = null;
            }
        }

       
        public void ModificarStickerApostillador(EStickerApostillador pobjStickerApostillador)
        {
            IPrimitiveTransaction objTx = null;
            IDStickerApostillador objDStickerApostillador = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDStickerApostillador = new DStickerApostillador();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDStickerApostillador.ModificarStickerApostillador(objTx.Transaction, pobjStickerApostillador);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDStickerApostillador != null) ((IDisposable)objDStickerApostillador).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDStickerApostillador = null;
                objTx = null;
            }
        }
      
        //public void EliminarStickerApostillador(int pintCodigo,string psrtSituacion,int pintauditoria)
        //{
        //    IPrimitiveTransaction objTx = null;
        //    IDStickerApostillador objDStickerApostillador = null;
        //    string strResultado = string.Empty;
        //    try
        //    {

        //        objTx = new PrimitiveTransaction();
        //        objDStickerApostillador = new DStickerApostillador();

        //        objTx.BeginTransaction(this.gstrStringConnection);
        //        objDStickerApostillador.EliminarStickerApostillador(objTx.Transaction, pintCodigo);
        //        objTx.Commit();
        //    }
        //    catch (Exception ex)
        //    {
        //        objTx.Rollback();
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objDStickerApostillador != null)
        //            ((IDisposable)objDStickerApostillador).Dispose();
        //        if (objTx != null)
        //            ((IDisposable)objTx).Dispose();
        //        objDStickerApostillador = null;
        //        objTx = null;
        //    }
        //}
     
        #endregion


    }
}
