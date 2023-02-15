//--------------------------------------------------------------------------------
// MRE
// Sistema ......
//
// Archivo     : BOficina.cs
// Descripción : Lógica de negocio de Oficina.
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
    public interface IBOficina
    {
        void Constructor(string pstrStringConnection);
      //  IEOficinaCollection ListarOficina(NullInt32 CodOficina, Int32 pintNumeroPagina, Int32 pintTamanioPaginacion);
        IEOficinaCollection ListarOficina(NullInt32 pintCodOficina, NullInt32 pintCodUbicacion);
        IEOficina ObtenerOficina(NullInt32 pintCodOficina);
        int NumeroRegistrosListarOficina(NullInt32 CodOficina);
        void Insertar(IEOficina pobjOficina);
        void Actualizar(IEOficina pobjOficina);
        void Eliminar(Int32 pi_codigo);


    }

    [Transaction(TransactionOption.Supported)]
    public class BOficina : ServicedComponent, IBOficina
    {
        private string gstrStringConnection;

        public BOficina()
        {
        }

        public void Constructor(string pstrStringConnection)
        {
            this.gstrStringConnection = pstrStringConnection;
        }

        #region Métodos No Transaccionales

        public int NumeroRegistrosListarOficina(NullInt32 CodOficina)
        {
            try
            {
                DOficina objDOficina = null;
                objDOficina = new DOficina();
                objDOficina.Constructor(gstrStringConnection);

                return objDOficina.FNC_ObtieneNumeroRegistros(CodOficina);

                //return objDOficina.ListarOficina(pstrCodOficina, pstrNombre, pstrPaterno, pstrMaterno, pstrSituacion,
                //                       pintNumeroPagina, pintNumeroRegistros, out pintRegistrosGenerados);
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
        //public IEOficinaCollection ListarOficina(NullInt32 CodOficina, Int32 pintNumeroPagina, Int32 pintTamanioPaginacion)
        //{
        //    IDOficina objDOficina = null;
        //    try
        //    {
        //        objDOficina = new DOficina();
        //        objDOficina.Constructor(gstrStringConnection);

        //        return objDOficina.ListarOficina(CodOficina, pintNumeroPagina, pintTamanioPaginacion);


        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        if (objDOficina != null) ((IDisposable)objDOficina).Dispose();
        //        objDOficina = null;
        //    }
        //}
        public IEOficinaCollection ListarOficina(NullInt32 pintCodOficina, NullInt32 pintCodUbicacion)
        {
            IDOficina objDOficina = null;
            try
            {
                objDOficina = new DOficina();
                objDOficina.Constructor(gstrStringConnection);

                return objDOficina.ListarOficina(pintCodOficina, pintCodUbicacion);


            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDOficina != null) ((IDisposable)objDOficina).Dispose();
                objDOficina = null;
            }
        }

        public IEOficina ObtenerOficina(NullInt32 pstrCodOficina)
        {
            IDOficina objDOficina = null;
            IEOficina objOficina = null;

            try
            {
                objDOficina = new DOficina();
                objDOficina.Constructor(gstrStringConnection);
                objOficina = objDOficina.ListarOficina(pstrCodOficina,NullInt32.Empty)[pstrCodOficina.UINullable];

                return objOficina;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (objDOficina != null) ((IDisposable)objDOficina).Dispose();
                objDOficina = null;
            }
        }


        #endregion

        #region Métodos Transaccionales
        public void Insertar(IEOficina pobjOficina)
        {
            IDOficina objDOficina = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDOficina = new DOficina();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDOficina.Insertar(objTx.Transaction, pobjOficina);
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

                if (objDOficina != null) ((IDisposable)objDOficina).Dispose();
                objDOficina = null;
            }
        }
        public void Actualizar(IEOficina pobjOficina)
        {
            IDOficina objDOficina = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDOficina = new DOficina();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);
                objDOficina.Actualizar(objTx.Transaction, pobjOficina);
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

                if (objDOficina != null) ((IDisposable)objDOficina).Dispose();
                objDOficina = null;
            }
        }


        public void Eliminar(Int32 pi_codigo)
        {
            IDOficina objDOficina = null;
            IPrimitiveTransaction objTx = null;
            try
            {
                objDOficina = new DOficina();
                objTx = new PrimitiveTransaction();
                objTx.BeginTransaction(this.gstrStringConnection);


                objDOficina.Eliminar(objTx.Transaction, pi_codigo);


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

                if (objDOficina != null) ((IDisposable)objDOficina).Dispose();
                objDOficina = null;
            }
        }

        #endregion
    }
}
