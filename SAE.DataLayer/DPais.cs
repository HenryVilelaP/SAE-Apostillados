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
    public interface IDPais
    {
        void Constructor(string pstrCadenaConexion);
        IEPaisCollection ListarPais(IEPais pobjPais );
        NullInt32 Insertar(SqlTransaction pobjTx, IEPais pobjPais);
    }

    public class DPais : PrimitiveEntity, IDPais
    {
        private string _strCadenaConexion;
        public DPais() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales
     
        public IEPaisCollection ListarPais(IEPais pobjPais)
        {
            IEPaisCollection collection = new EPaisCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PAIS", pobjPais.CodigoPais.Value));
                dt = ExecuteDataTable("SAESS_LISTAR_PAIS", this._strCadenaConexion);

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
        public NullInt32 Insertar(SqlTransaction pobjTx, IEPais pobjPais)
        {
            try
            {
                Clear();
                                 
                
                
               // Add(PrimitiveParameter.CreateInput("@PV_NOMBRE", pobjPais.Nombres.UINullable , 50));
               // Add(PrimitiveParameter.CreateInput("@PV_APE_PATERNO", pobjPais.ApellidoPaterno.UINullable, 50));
               // Add(PrimitiveParameter.CreateInput("@PV_APE_MATERNO", pobjPais.ApellidoMaterno.UINullable, 50));
               // Add(PrimitiveParameter.CreateInput("@PV_Pais_RED", pobjPais.PaisRed.UINullable, 100));
               // Add(PrimitiveParameter.CreateInput("@PV_DOMINIO", pobjPais.Dominio.UINullable, 100));
               // Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjPais.SituacionRegistro, 1));
               //// Add(PrimitiveParameter.CreateInput("@PI_CODIGO_MISION", pobjPais.CodigoMision));
               // Add(PrimitiveParameter.CreateInput("@PV_CORREO", pobjPais.Correo, 50));                 
               // Add(PrimitiveParameter.CreateOutputInt32("@PI_CODIGO_Pais"));
               // Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjPais.PaisRegistro ));                 
           
               // ExecuteNonQuery("SAESI_INSERTAR_Pais", pobjTx);

                return NullInt32.Create(Convert.ToInt32(Out(8)));

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    

        #endregion








    }
}
