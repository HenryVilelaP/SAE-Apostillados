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
    public interface IDPersona
    {
        void Constructor(string pstrCadenaConexion);
        IEPersonaCollection ListarPersona(IEPersona pobjPersona);
        Int32 FNC_ObtieneNumeroRegistros(NullInt32 CodPersona);
        IEPersonaCollection ListarPersonaPorDocumento(int pintCodigoTipoDocumento, int pintNumeroDoc);
        int Insertar(SqlTransaction pobjTx, IEPersona pobjPersona);
        void Actualizar(SqlTransaction pobjTx, IEPersona pobjPersona);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
    }

    public class DPersona : PrimitiveEntity, IDPersona
    {
        private string _strCadenaConexion;
        public DPersona() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales
        public Int32 FNC_ObtieneNumeroRegistros(NullInt32 CodPersona)
        {
            try
            {
                DataRow dr;
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERSONA", CodPersona));
                dr = this.ExecuteDataRow("SAESS_NUM_REGISTROS_LISTAR_PERSONA", this._strCadenaConexion);
                return (int)dr[0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public IEPersonaCollection ListarPersonaPorDocumento(int pintCodigoTipoDocumento, int pintNumeroDoc)
        {
            IEPersonaCollection collection = new EPersonaCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOCUMENTO", pintCodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PN_NUMERO_DOCUENTO", pintNumeroDoc));

                dt = ExecuteDataTable("SAESS_LISTAR_PERSONA_X_DOCUMENTO", this._strCadenaConexion);

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

        public IEPersonaCollection ListarPersona(IEPersona pobjPersona)
        {
            IEPersonaCollection collection = new EPersonaCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERSONA", pobjPersona.CodigoPersona.Value ));
                Add(PrimitiveParameter.CreateInput("@PV_NRO_DOCUMENTO", pobjPersona.NroDNI.UINullable, 15));
                Add(PrimitiveParameter.CreateInput("@PV_APELLIDO_PATERNO", pobjPersona.ApellidoPaterno.UINullable, 30));
                Add(PrimitiveParameter.CreateInput("@PV_APELLIDO_MATERNO", pobjPersona.ApellidoMaterno.UINullable, 30));
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRES", pobjPersona.Nombres.UINullable, 50));
                Add(PrimitiveParameter.CreateInput("@PV_SITUACION", pobjPersona.SituacionRegistro.UINullable, 1));
                dt = ExecuteDataTable("SAESS_LISTAR_PERSONA", this._strCadenaConexion);
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

        public int Insertar(SqlTransaction pobjTx, IEPersona pobjPersona)
        {
            try
            {
                
                Clear();
                Add(PrimitiveParameter.CreateOutputInt32("@PI_CODIGO_PERSONA"));
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE", pobjPersona.Nombres , 100));
                Add(PrimitiveParameter.CreateInput("@PV_APE_PATERNO", pobjPersona.ApellidoPaterno, 50));
                Add(PrimitiveParameter.CreateInput("@PV_APE_MATERNO", pobjPersona.ApellidoMaterno, 50));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PAIS", pobjPersona.CodigoPaisNacimineto));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjPersona.SituacionRegistro , 1));
                Add(PrimitiveParameter.CreateInput("@PC_SEXO", pobjPersona.Sexo , 1));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA_NAC", pobjPersona.FechaNacimineto ));
                

                ExecuteNonQuery("SAESI_INSERTAR_PERSONA", pobjTx);
                return Convert.ToInt32( Out(0) );
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Actualizar(SqlTransaction pobjTx, IEPersona pobjPersona)
        {
            try
            {
 
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_USUARIO", pobjPersona.CodigoPersona));
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE", pobjPersona.Nombres,100));
                Add(PrimitiveParameter.CreateInput("@PV_APE_PATERNO", pobjPersona.ApellidoPaterno, 50));
                Add(PrimitiveParameter.CreateInput("@PV_APE_MATERNO", pobjPersona.ApellidoMaterno, 50));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PAIS_NAC", pobjPersona.CodigoPaisNacimineto));
                Add(PrimitiveParameter.CreateInput("@PC_SEXO", pobjPersona.Sexo, 1));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjPersona.SituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA_NAC", pobjPersona.FechaNacimineto));

                ExecuteNonQuery("SAESU_ACTUALIZAR_PERSONA", pobjTx);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo)
        {
            try
            {
                /*
                Clear();
                Add(PrimitiveParameter.CreateInput("@pi_codigo", pi_codigo));
                ExecuteNonQuery("eliminar", pobjTx);
                 */
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
