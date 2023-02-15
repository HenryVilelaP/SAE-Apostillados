//--------------------------------------------------------------------------------
//
// Archivo     : BApostillador.cs
// Descripción : Lógica de negocio de Apostilladors.
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
    public interface IBApostillador
    {
        void Constructor(string pstrStringConnection);


        DataTable ListarApostilladores(EApostillador objApostillador, NullInt32 pintOficina);
        byte[] VerFirma(int pintCodigoApostillador);
        
        void InsertarApostillador(EApostillador objApostilladors);
        void ModificarApostillador(EApostillador pobjApostillador);
        void EliminarApostillador(int pintCodigo);

    }

     [Transaction(TransactionOption.Supported)]
     public class BApostillador : ServicedComponent, IBApostillador
   
    {
        private string gstrStringConnection;

        public BApostillador()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }



        #region Métodos No TranSAEcionales

        public byte[] VerFirma(int pintCodigoApostillador)
        {
            IDApostillador objDApostillador = null;
            try
            {
                objDApostillador = new DApostillador();
                objDApostillador.Constructor(gstrStringConnection);
                return objDApostillador.VerFirma(pintCodigoApostillador);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDApostillador != null) ((IDisposable)objDApostillador).Dispose();
                objDApostillador = null;
            }
        }

        public DataTable ListarApostilladores(EApostillador objApostillador, NullInt32 pintOficina)
        {
            IDApostillador objDApostillador = null;
            try
            {
                objDApostillador = new DApostillador();
                objDApostillador.Constructor(gstrStringConnection);
                return objDApostillador.ListarApostilladores(objApostillador, pintOficina);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDApostillador != null) ((IDisposable)objDApostillador).Dispose();
                objDApostillador = null;
            }
        }



        #endregion

        #region Métodos Transaccionales

        public void InsertarApostillador(EApostillador objApostillador)
        {
            IPrimitiveTransaction objTx = null;
            IDApostillador objDApostillador = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDApostillador = new DApostillador();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDApostillador.InsertarApostillador(objTx.Transaction, objApostillador);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDApostillador != null) ((IDisposable)objDApostillador).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDApostillador = null;
                objTx = null;
            }
        }

        public void ModificarApostillador(EApostillador pobjApostillador)
        {
            IPrimitiveTransaction objTx = null;
            IDApostillador objDApostillador = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDApostillador = new DApostillador();

                objTx.BeginTransaction(this.gstrStringConnection);

                objDApostillador.ModificarApostillador(objTx.Transaction, pobjApostillador);

                //if (pobjApostillador.Firma != null)objDApostillador.ActualizarFirmaApostillador(objTx.Transaction, pobjApostillador);
                
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDApostillador != null) ((IDisposable)objDApostillador).Dispose();
                if (objTx != null) ((IDisposable)objTx).Dispose();
                objDApostillador = null;
                objTx = null;
            }
        }

        public void EliminarApostillador(int pintCodigo)
        {
            IPrimitiveTransaction objTx = null;
            IDApostillador objDApostillador = null;
            string strResultado = string.Empty;
            try
            {

                objTx = new PrimitiveTransaction();
                objDApostillador = new DApostillador();
                
                objTx.BeginTransaction(this.gstrStringConnection);
                objDApostillador.EliminarApostillador(objTx.Transaction, pintCodigo);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                if (objDApostillador != null)
                    ((IDisposable)objDApostillador).Dispose();
                if (objTx != null)
                    ((IDisposable)objTx).Dispose();
                objDApostillador = null;
                objTx = null;
            }
        }


        #endregion


    }
}
