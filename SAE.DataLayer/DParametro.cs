//--------------------------------------------------------------------------------
// SISTEMA GESTION CONSULAR
//
// Archivo     : DParametro.cs
// Descripción : Lógica de negocio de Parametros.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : 
//--------------------------------------------------------------------------------
using SAE.EntityLayer.Collections;
using SAE.EntityLayer;
using SAE.Nullables;
using System;
using System.Data;
using System.Data.SqlClient;
using  System.EnterpriseServices;
using  System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public interface IDParametro
    {
        void Constructor(string pstrCadenaConexion);

        IEParametro ObtenerParametro(EParametro objPamametro);
        IEParametroCollection ListarParametros(EParametro objPamametro, String strEstado);
        DataTable _ListarParametros(EParametro objPamametro, String strEstado);
        void InsertarParametro(SqlTransaction pobjTx, EParametro pobjParametro);
        void ModificarParametro(SqlTransaction pobjTx, EParametro pobjParametro);
        void EliminarParametro(SqlTransaction pobjTx,Int32  pintCodigo   );
        bool BooTipoDato(string strTabla, string pstrCodigoReg);
        DataTable ListarTablas();
        DataTable ListarTabla(string pstrCodigoTabla);
 
    }

    public class DParametro : PrimitiveEntity, IDParametro
    {
        private string _strCadenaConexion;
        public DParametro() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No TranSAEcionales

        public bool BooTipoDato(string strTabla, string pstrCodigoReg)
        {
            DataTable dtTemp = new DataTable();
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PARAC_CCODIGO_TABLA", strTabla, 4));
                Add(PrimitiveParameter.CreateInputChar("@PARAC_CCODIGO_Parametro", pstrCodigoReg, 4));
                dtTemp = ExecuteDataTable("SAESS_Parametro_RetornarTipoDato", this._strCadenaConexion);
                if (dtTemp == null)
                    return true;
                else if (dtTemp.Rows.Count == 0)
                    return true;
                else
                    return (bool)dtTemp.Rows[0][0];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dtTemp = null;
            }
        }

        public IEParametro ObtenerParametro(EParametro objPamametro)
        {
            DataRow row;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TABLA", objPamametro.CodigoTabla));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_REGISTRO", objPamametro.CodigoRegistro));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PARAMETRO", objPamametro.CodigoParametro));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", objPamametro.SituacionRegistro, 1));
                row = ExecuteDataRow("SAESS_LISTAR_PARAMETRO", this._strCadenaConexion);
                if (row != null) return EParametro.Create(row);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                row = null;
            }
        }

        public IEParametroCollection ListarParametros(EParametro objPamametro, String strEstado)
        {
            IEParametroCollection collection = new EParametroCollection();
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TABLA", objPamametro.CodigoTabla));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_REGISTRO", objPamametro.CodigoRegistro));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PARAMETRO", objPamametro.CodigoParametro));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", strEstado, 1));

                dt = ExecuteDataTable("SAESS_LISTAR_PARAMETRO", this._strCadenaConexion);

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
        public DataTable _ListarParametros(EParametro objPamametro, String strEstado)
        {
            
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TABLA", objPamametro.CodigoTabla));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_REGISTRO", objPamametro.CodigoRegistro));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PARAMETRO", objPamametro.CodigoParametro));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", strEstado, 1));

                dt = ExecuteDataTable("SAESS_LISTAR_PARAMETRO", this._strCadenaConexion);

                return  dt ;
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

        public DataTable ListarTablas()
        {
            DataTable dt;
            try
            {
                Clear();
                dt = ExecuteDataTable("SAESS_LISTAR_TABLAS", this._strCadenaConexion);
                return dt;
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
         
      
        public DataTable ListarTabla(string pstrCodigoTabla)
        {
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PC_CCODIGO_TABLA", pstrCodigoTabla, 4));
                dt = ExecuteDataTable("SETSS_LISTAR_PARAMETRO", this._strCadenaConexion);
                return dt;
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

        public void InsertarParametro(SqlTransaction pobjTx, EParametro pobjParametro)
        {
            try
            {
                Clear();
                
 
        
                Add(PrimitiveParameter.CreateInput("@pi_codigo_tabla", pobjParametro.CodigoTabla ));
                Add(PrimitiveParameter.CreateInput("@pv_nombre_parametro", pobjParametro.Descripcion, 255));
                Add(PrimitiveParameter.CreateInput("@pi_valor_numerico", pobjParametro.ValorNumerico));
                Add(PrimitiveParameter.CreateInput("@pv_valor_texto", pobjParametro.Valortexto,255));
                Add(PrimitiveParameter.CreateInput("@pc_flag_modificar", pobjParametro.FlagModificar,1));
                Add(PrimitiveParameter.CreateInput("@pc_flag_eliminar", pobjParametro.FlagEliminar, 1));
                ExecuteNonQuery("SAESI_INSERTAR_PARAMETRO", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void ModificarParametro(SqlTransaction pobjTx, EParametro pobjParametro)
        {
            try
            {
                Clear();
        
                Add(PrimitiveParameter.CreateInput("@pi_codigo_tabla", pobjParametro.CodigoTabla ));
                Add(PrimitiveParameter.CreateInput("@pi_codigo_parametro", pobjParametro.CodigoParametro ));
                Add(PrimitiveParameter.CreateInput("@pv_nombre_parametro", pobjParametro.Descripcion, 255));
                Add(PrimitiveParameter.CreateInput("@pi_valor_numerico", pobjParametro.ValorNumerico));
                Add(PrimitiveParameter.CreateInput("@pv_valor_texto", pobjParametro.Valortexto, 1000));
 
                ExecuteNonQuery("SAESU_ACTUALIZAR_PARAMETRO", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public void EliminarParametro(SqlTransaction pobjTx, string pstrCodigo, string pstrCodigoTabla, string pstrAuditoria, out string pstrResultado)
        //{
        //    try
        //    {
        //        Clear();
        //        Add(PrimitiveParameter.CreateInputChar("@pc_codtabla", pstrCodigoTabla, 4));
        //        Add(PrimitiveParameter.CreateInputChar("@pc_codParametro", pstrCodigo, 4));
        //        Add(PrimitiveParameter.CreateInputChar("@pc_auditoria", pstrAuditoria, 10));
        //        Add(PrimitiveParameter.CreateOutputChar("@pc_resultado", 1));
        //        ExecuteNonQuery("SAESD_Parametro_ELIMINAR", pobjTx);
        //        pstrResultado = Out(3).ToString();
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}


        public void EliminarParametro(SqlTransaction pobjTx, Int32 pintCodigo)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@pi_codtabla", pintCodigo  ));
                ExecuteNonQuery("SAESD_PARAMETRO_ELIMINAR", pobjTx);
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}