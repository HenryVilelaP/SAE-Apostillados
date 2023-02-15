//--------------------------------------------------------------------------------
// MRE
// Sistema  Gestion Comercial
//
// Archivo     : BPerfil.cs
// Descripción : Lógica de negocio de Perfil.
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
    public interface IBPerfil
    {
        void Constructor(string pstrStringConnection);
        IEPerfilCollection ListarPerfil(NullInt32 pintCodigoPerfil  );
        IEPerfilCollection ListarPerfilPorUbicacion(NullInt32 pintCodigoUbicacion, NullInt32 pintCodigoUnidad, NullString pstrSituacionRegistro);
        IEPerfilCollection ListarPerfilPorUbicacionModulo(NullInt32 pintCodigoUbicacion, NullInt32 pintCodigoUnidad, NullString pstrSituacionRegistro, NullInt32 pintCodigoModulo);
        IEPerfil GetPerfil(NullInt32 pintCodigoPerfil);
        void Insertar(IEPerfil pobjPerfil);
        void Actualizar(IEPerfil pobjPerfil);
        void Eliminar(Int32 pi_codigo);


    }

    [Transaction(TransactionOption.Supported)]
    public class BPerfil : ServicedComponent, IBPerfil
    {
        private string gstrStringConnection;

        public BPerfil()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales

        public IEPerfil GetPerfil(NullInt32 pintCodigoPerfil)
        {
            IDPerfil objDPerfil = null;
            try
            {
                objDPerfil = new DPerfil();
                objDPerfil.Constructor(gstrStringConnection);

                return objDPerfil.ListarPerfil(pintCodigoPerfil)[pintCodigoPerfil.UINullable];


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }
        }


        public IEPerfilCollection ListarPerfil(NullInt32 pintCodigoPerfil)
        {
            IDPerfil objDPerfil = null;
            try
            {
                objDPerfil = new DPerfil();
                objDPerfil.Constructor(gstrStringConnection);

                return objDPerfil.ListarPerfil(pintCodigoPerfil);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }
        }
        public  IEPerfilCollection ListarPerfilPorUbicacion(NullInt32 pintCodigoUbicacion, NullInt32 pintCodigoUnidad, NullString pstrSituacionRegistro)
        {
            IDPerfil objDPerfil = null;
            try
            {
                objDPerfil = new DPerfil();
                objDPerfil.Constructor(gstrStringConnection);
                return objDPerfil.ListarPerfil(pintCodigoUbicacion, pintCodigoUnidad, pstrSituacionRegistro,NullInt32.Empty);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }
        }
        public IEPerfilCollection ListarPerfilPorUbicacionModulo(NullInt32 pintCodigoUbicacion, NullInt32 pintCodigoUnidad, NullString pstrSituacionRegistro, NullInt32 pintCodigoModulo)
        {
            IDPerfil objDPerfil = null;
            try
            {
                objDPerfil = new DPerfil();
                objDPerfil.Constructor(gstrStringConnection);
                return objDPerfil.ListarPerfil(pintCodigoUbicacion, pintCodigoUnidad, pstrSituacionRegistro,  pintCodigoModulo);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }
        }

        

        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEPerfil pobjPerfil)
        {
            IDPerfil objDPerfil = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPerfil = new DPerfil();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDPerfil.Insertar(objTx.Transaction, pobjPerfil);
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

                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }
        }
        public void Actualizar(IEPerfil pobjPerfil)
        {
            IDPerfil objDPerfil = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPerfil = new DPerfil();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDPerfil.Actualizar(objTx.Transaction, pobjPerfil);
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

                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }
        }


        public void Eliminar(Int32 pi_codigo)
        {
            IDPerfil objDPerfil = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPerfil = new DPerfil();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                objDPerfil.Eliminar(objTx.Transaction, pi_codigo);


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

                if (objDPerfil != null) ((IDisposable)objDPerfil).Dispose();
                objDPerfil = null;
            }
        }

        #endregion
    }
}
