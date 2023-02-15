//--------------------------------------------------------------------------------
// MRE
// Sistema Registro de Personas de DNI
// Archivo     : BPersona.cs
// Descripción : Lógica de negocio de Persona.
// Empresa     : MRE
// Autor       : Juan Mori
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
    public interface IBPersona
    {
        void Constructor(string pstrStringConnection);
        IEPersonaCollection ListarPersona(IEPersona pobjPersona);
        IEPersona ListarPersonaPorDocumento(int pintCodigoTipoDocumento, int pintNumeroDoc);
        IEPersona ObtenerPersona(IEPersona pobjPersona);
        int NumeroRegistrosListarPersona(NullInt32 CodPersona);
        void Insertar(IEPersona pobjPersona);
        void Actualizar(IEPersona pobjPersona);
        void Eliminar(Int32 pi_codigo);
    }

    [Transaction(TransactionOption.Supported)]
    public class BPersona : ServicedComponent, IBPersona
    {
        private string gstrStringConnection;

        public BPersona()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales
        public IEPersona ListarPersonaPorDocumento(int pintCodigoTipoDocumento, int pintNumeroDoc)
        {

            IDPersona objDPersona = null;


            try
            {
                IEPersona objEPersona = new EPersona();  
                IEPersonaCollection objPersonas = null;

                objDPersona = new DPersona();

                objDPersona.Constructor(gstrStringConnection);
                objPersonas = objDPersona.ListarPersonaPorDocumento(pintCodigoTipoDocumento, pintNumeroDoc);

                if (objPersonas.Count > 1) throw new Exception("La consulta tiene como resultado mas de un registro, el numero de documento es único.");
                if (objPersonas.Count == 0) objEPersona = null;
                else objEPersona = objPersonas.Valores[0];

                return objEPersona;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
            }


        }
        public int NumeroRegistrosListarPersona(NullInt32 CodPersona)
        {
            try
            {
                DPersona objDPersona = null;
                objDPersona = new DPersona();
                objDPersona.Constructor(gstrStringConnection);
                return objDPersona.FNC_ObtieneNumeroRegistros(CodPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public IEPersonaCollection ListarPersona(IEPersona pobjPersona)
        {
            IDPersona objDPersona = null;
            try
            {
                objDPersona = new DPersona();
                objDPersona.Constructor(gstrStringConnection);
                return objDPersona.ListarPersona(pobjPersona);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
            }
        }

        public IEPersona ObtenerPersona(IEPersona pobjPersona)
        {
            IDPersona objDPersona = null;
            IEPersona objEPersonaFound = null;
            IEPersonaCollection objPersonaCollection = null;
            IEPersona objEPersona = null;
            try
            {
                objDPersona = new DPersona();
                objDPersona.Constructor(gstrStringConnection);
                objPersonaCollection = objDPersona.ListarPersona(pobjPersona);
                int intNumReg = objPersonaCollection.Count;

                if (intNumReg > 1) { throw new Exception ("Error: Se encontro más de un registro con el criterio definido");}
                if (intNumReg < 1) { throw new Exception("Error: No existe registro con el criterio definido"); }

                foreach (IEPersona _objIEPersona in objPersonaCollection)
                {
                    objEPersonaFound = _objIEPersona;
                }

                return objEPersonaFound;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
                objEPersona = null;
            }
        }


        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEPersona pobjPersona)
        {
            IDPersona objDPersona = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPersona = new DPersona();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                 objDPersona.Insertar(objTx.Transaction, pobjPersona);
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

                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
            }
        }

        public void Actualizar(IEPersona pobjPersona)
        {
            IDPersona objDPersona = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPersona = new DPersona();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDPersona.Actualizar(objTx.Transaction, pobjPersona);
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

                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
            }
        }


        public void Eliminar(Int32 pi_codigo)
        {
            IDPersona objDPersona = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDPersona = new DPersona();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                objDPersona.Eliminar(objTx.Transaction, pi_codigo);


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

                if (objDPersona != null) ((IDisposable)objDPersona).Dispose();
                objDPersona = null;
            }
        }

        #endregion
    }
}
