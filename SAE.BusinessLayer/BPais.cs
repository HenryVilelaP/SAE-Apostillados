using System;
using System.Collections.Generic;
using System.Data;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using SAE.DataLayer;
using SAE.EntityLayer;
//--------------------------------------------------------------------------------
// Sistema Gestion Consular - SAE
//
// Archivo     : BPais.cs
// Descripción : Lógica de negocio de Pais.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : N/A
// Fecha       : 01/04/2009
//--------------------------------------------------------------------------------
using SAE.EntityLayer.Collections;
using SAE.Nullables;

namespace SAE.BusinessLayer
{
    public interface IBPais
    {
        void Constructor(string pstrStringConnection);
        IEPaisCollection ListarPais(IEPais pobjPais);
        void Insertar(IEPais pobjPais);
        
        


    }

    [Transaction(TransactionOption.Supported)]
    public class BPais : ServicedComponent, IBPais
    {
         
        private string gstrStringConnection;
 
        public BPais()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales

      
        public IEPaisCollection ListarPais(IEPais pobjPais )
        {
            IDPais objDPais = null;
            try
            {
                objDPais = new DPais();
                objDPais.Constructor(gstrStringConnection);

                return objDPais.ListarPais(pobjPais );
                

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPais != null) ((IDisposable)objDPais).Dispose();
                objDPais = null;
            }
        }
        
        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEPais pobjPais)
        {
            IDPais objDPais = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPais = new DPais();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                NullInt32  pintCodigoPais;
                pintCodigoPais=objDPais.Insertar(objTx.Transaction, pobjPais);
                

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

                if (objDPais != null) ((IDisposable)objDPais).Dispose();
                objDPais = null;
            }
        }
        
     
        #endregion
    }
}
