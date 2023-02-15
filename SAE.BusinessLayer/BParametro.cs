//--------------------------------------------------------------------------------
// SISTEMA GESTION CONSULAR
//
// Archivo     : BParametro.cs
// Descripción : Lógica de negocio de Parametros.
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
using  System.EnterpriseServices;
using  System.Runtime.InteropServices;

namespace SAE.BusinessLayer
{
    public interface IBParametro
    {
        void Constructor(string pstrStringConnection);

        IEParametro ObtenerParametro(EParametro objPamametro);
        IEParametroCollection ListarParametros(EParametro objParam, String strEstado);
        DataTable _ListarParametros(EParametro objParam, String strEstado);
        bool BooTipoDato(string strTabla, string pstrCodigoReg);
        void InsertarParametro(EParametro pobjParametro);
        void ModificarParametro(EParametro pobjParametro);
        void EliminarParametros(string[] parrCodigos, string pstrCodigoTabla, string pstrAuditoria, out int pintContadorNoEliminadas);
        DataTable ListarTabla(string pstrCodigoTabla);
        DataTable ListarTablas();
        


        void EliminarParametro(Int32 parrCodigo);
    }

    [Transaction(TransactionOption.Supported)]
    public class BParametro : ServicedComponent, IBParametro
    {
        private string gstrStringConnection;

        public BParametro()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }



        #region Métodos No TranSAEcionales

        public bool BooTipoDato(string strTabla, string pstrCodigoReg)
        {
            IDParametro objDParametro = new DParametro();
            objDParametro.Constructor(gstrStringConnection);
            return objDParametro.BooTipoDato(strTabla, pstrCodigoReg);
        }

        public IEParametro ObtenerParametro(EParametro objParametro)
        {
            IDParametro objDParametro = null;
            try
            {
                objDParametro = new DParametro();
                objDParametro.Constructor(gstrStringConnection);
                return objDParametro.ObtenerParametro(objParametro);

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDParametro != null) ((IDisposable)objDParametro).Dispose();
                objDParametro = null;
               
            }
        }

        public IEParametroCollection ListarParametros(EParametro objParam, String strEstado)
        {
            IDParametro objDParametro = null;
            try
            {
                objDParametro = new DParametro();
                objDParametro.Constructor(gstrStringConnection);
                return objDParametro.ListarParametros(objParam, strEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDParametro != null) ((IDisposable)objDParametro).Dispose();
                objDParametro = null;
            }
        }
        public DataTable _ListarParametros(EParametro objParam, String strEstado)
        {
            IDParametro objDParametro = null;
            try
            {
                objDParametro = new DParametro();
                objDParametro.Constructor(gstrStringConnection);
                return objDParametro._ListarParametros(objParam, strEstado);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                  if (objDParametro != null) ((IDisposable)objDParametro).Dispose();
                objDParametro = null;
            }
        }

        public DataTable ListarTablas()
        {
            IDParametro objDParametro = null;
            try
            {
                objDParametro = new DParametro();
                objDParametro.Constructor(gstrStringConnection);
                return objDParametro.ListarTablas();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
              //  if (objDParametro != null) ((IDisposable)objDParametro).Dispose();
                objDParametro = null;
            }
        }
   
        

        public DataTable ListarTabla(string pstrCodigoTabla)
        {
            IDParametro objDParametro = null;
            try
            {
                objDParametro = new DParametro();
                objDParametro.Constructor(gstrStringConnection);
                return objDParametro.ListarTabla(pstrCodigoTabla);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
               // if (objDParametro != null) ((IDisposable)objDParametro).Dispose();
                objDParametro = null;
            }
        }
        

        

        #endregion

        #region Métodos Transaccionales

        public void InsertarParametro(EParametro pobjParametro)
        {
            IPrimitiveTransaction objTx = null;
            IDParametro objDParametro = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDParametro = new DParametro();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDParametro.InsertarParametro(objTx.Transaction, pobjParametro);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                //if (objDParametro != null) ((IDisposable)objDParametro).Dispose();
                //if (objTx != null) ((IDisposable)objTx).Dispose();
                objDParametro = null;
                objTx = null;
            }
        }

        public void ModificarParametro(EParametro pobjParametro)
        {
            IPrimitiveTransaction objTx = null;
            IDParametro objDParametro = null;
            try
            {
                objTx = new PrimitiveTransaction();
                objDParametro = new DParametro();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDParametro.ModificarParametro(objTx.Transaction, pobjParametro);
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                //if (objDParametro != null) ((IDisposable)objDParametro).Dispose();
                //if (objTx != null) ((IDisposable)objTx).Dispose();
                objDParametro = null;
                objTx = null;
            }
        }


        public void EliminarParametro(Int32 parrCodigo)
        {
            IPrimitiveTransaction objTx = null;
            IDParametro objDParametro = null;
            string strResultado = string.Empty;
            try
            {
                 
                objTx = new PrimitiveTransaction();
                objDParametro = new DParametro();

                objTx.BeginTransaction(this.gstrStringConnection);
                objDParametro.EliminarParametro(objTx.Transaction, parrCodigo);
                    
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                //if (objDParametro != null)
                //    ((IDisposable)objDParametro).Dispose();
                //if (objTx != null)
                //    ((IDisposable)objTx).Dispose();
                objDParametro = null;
                objTx = null;
            }
        }
        public void EliminarParametros(string[] parrCodigos, string pstrCodigoTabla, string pstrAuditoria, out int pintContadorNoEliminadas)
        {
            IPrimitiveTransaction objTx = null;
            IDParametro objDParametro = null;
            string strResultado = string.Empty;
            try
            {
                pintContadorNoEliminadas = 0;
                objTx = new PrimitiveTransaction();
                objDParametro = new DParametro();

                objTx.BeginTransaction(this.gstrStringConnection);

                foreach (string strCodigo in parrCodigos)
                {
                 //   objDParametro.EliminarParametro(objTx.Transaction, strCodigo, pstrCodigoTabla, pstrAuditoria, out strResultado);
                    if (strResultado == "1")
                    {
                        pintContadorNoEliminadas++;
                    }
                }
                objTx.Commit();
            }
            catch (Exception ex)
            {
                objTx.Rollback();
                throw ex;
            }
            finally
            {
                //if (objDParametro != null)
                //    ((IDisposable)objDParametro).Dispose();
                //if (objTx != null)
                //    ((IDisposable)objTx).Dispose();
                objDParametro = null;
                objTx = null;
            }
        }


        #endregion

    
    }
}
