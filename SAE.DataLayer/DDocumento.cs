using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Runtime.InteropServices;
using SAE.EntityLayer.Collections;
using SAE.EntityLayer;
using SAE.Nullables;

namespace SAE.DataLayer
{
    public interface IDDocumento
    {
        void Constructor(string pstrCadenaConexion);
        IEDocumentoCollection ListarDocumento(IEDocumento pobjDocumento );
        void Insertar(SqlTransaction pobjTx, IEDocumento pobjDocumento);
    }

    public class DDocumento : PrimitiveEntity, IDDocumento
    {
        private string _strCadenaConexion;
        public DDocumento() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales
     
        public IEDocumentoCollection ListarDocumento(IEDocumento pobjDocumento)
        {
            IEDocumentoCollection collection = new EDocumentoCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_Documento", pobjDocumento.CodigoDocumento.Value));
                dt = ExecuteDataTable("SAESS_LISTAR_DOCUMENTO", this._strCadenaConexion);

                return collection.Fill(dt);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dt = null;
            }
        }


        
        #endregion

        #region Métodos Transaccionales
        public void Insertar(SqlTransaction pobjTx, IEDocumento pobjDocumento)
        {
            try
            {
                Clear();
  
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERSONA", pobjDocumento.CodigoPersona));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOC", pobjDocumento.CodigoTipoDoc));
                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_DOCUMENTO", pobjDocumento.NumeroDocumento ,12));



                ExecuteNonQuery("SAESI_INSERTAR_DOCUMENTO", pobjTx);

                 

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    

        #endregion








    }
}
