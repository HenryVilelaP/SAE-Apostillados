//--------------------------------------------------------------------------------
//  
//
// Archivo     : DActuacion.cs
// Descripción : Lógica de negocio de Actuacions.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : 
//--------------------------------------------------------------------------------

using SAE.EntityLayer;
using SAE.Nullables;
using System;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public interface IDActuacion
    {
        void Constructor(string pstrCadenaConexion);


        int NumeroRegistrosEncontrados(EActuacion objActuacion, NullInt32 pintCodigoUbicacion);
        DataTable ListarActuacionPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion, int intPaginaInicial, int pintNumRegistros);
        DataTable ListarActuaciones(EActuacion objActuacion, NullInt32 pintCodigoUbicacion);
        DataTable ObtieneCorrelativoSerie(EActuacion objActuacion);


        int NumeroRegistrosEncontradosConPDF(EActuacion objActuacion, NullInt32 pintCodigoUbicacion);
        DataTable ListarActuacionConPDFPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion, int intPaginaInicial, int pintNumRegistros);
        DataTable ListarSerieActuacionConPDF();



        string InsertarActuacion(SqlTransaction pobjTx, EActuacion pobjActuacion);
        void ModificarActuacion(SqlTransaction pobjTx, EActuacion pobjActuacion);
        void ModificarActuacion_X_Apostilla(SqlTransaction pobjTx, EActuacion pobjActuacion);
        void EliminarActuacion(SqlTransaction pobjTx, int pintCodigo);
        void EliminarActuacionXnumeroApostilla(SqlTransaction pobjTx, string pstrNumeroApostilla);
        void ActualizarNombreArchivoApostilla(SqlTransaction pobjTx, string psrtNumeroApostilla, string pstrNombreArchivo, string pstrSituacion, string pstrSerie, string pstrNumeroSerie);
        void ActualizarSituacion(SqlTransaction pobjTx, Int32 pintCodigoActuacion, string pstrSituacion, Int32 pintAuditoria);
    }

    public class DActuacion : PrimitiveEntity, IDActuacion
    {
        private string _strCadenaConexion;

        public DActuacion() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No TranSAEcionales


        public DataTable ListarActuaciones(EActuacion objActuacion, NullInt32 pintCodigoUbicacion)
        {

            DataTable dt;
            try
            {
 
                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_APOSTILLA", objActuacion.NumeroApostilla,255));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ACTUACION", objActuacion.CodigoActuacion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", objActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOCUMENTO", objActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA_APOSTILLA", objActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInputChar("@PV_OPERACION_BANCARIA", objActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", objActuacion.SituacionRegistro,1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", objActuacion.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodigoUbicacion));
               
                
                
                dt = ExecuteDataTable("SAESS_LISTAR_ACTUACION", this._strCadenaConexion);

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
        public DataTable ListarActuacionPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion,int intPaginaInicial,int pintNumRegistros)
        {

            DataTable dt;
            try
            {

                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_APOSTILLA", objActuacion.NumeroApostilla, 255));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ACTUACION", objActuacion.CodigoActuacion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", objActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOCUMENTO", objActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA_APOSTILLA", objActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInputChar("@PV_OPERACION_BANCARIA", objActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", objActuacion.SituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", objActuacion.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodigoUbicacion));
                Add(PrimitiveParameter.CreateInput("@PI_PAGINA_ACTUAL", intPaginaInicial));
                Add(PrimitiveParameter.CreateInput("@PI_NUM_REGISTROS", pintNumRegistros));
 

                dt = ExecuteDataTable("SAESS_LISTAR_ACTUACION_PAGINADO", this._strCadenaConexion);

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
        public int NumeroRegistrosEncontrados(EActuacion objActuacion, NullInt32 pintCodigoUbicacion)
        {

            int pintNumeroRegistroEncontrados=0;
            DataTable dt;
            try
            {
                
                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_APOSTILLA", objActuacion.NumeroApostilla, 255));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ACTUACION", objActuacion.CodigoActuacion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", objActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOCUMENTO", objActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA_APOSTILLA", objActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInputChar("@PV_OPERACION_BANCARIA", objActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", objActuacion.SituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", objActuacion.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodigoUbicacion));

               DataRow dr= ExecuteDataRow("SAESS_TOTAL_REGISTRO_ACTUACION", this._strCadenaConexion);
               if (!(Convert.IsDBNull(dr[0])))pintNumeroRegistroEncontrados = Convert.ToInt32(dr[0]);


                return pintNumeroRegistroEncontrados;
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
        public DataTable ObtieneCorrelativoSerie(EActuacion objActuacion)
        {

            DataTable dt;
            try
            {

                Clear();

                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", objActuacion.CodigoOficina));



                dt = ExecuteDataTable("SAESS_OBTIENE_CORRELATIVO_SERIE", this._strCadenaConexion);

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

        public int NumeroRegistrosEncontradosConPDF(EActuacion objActuacion, NullInt32 pintCodigoUbicacion)
        {

            int pintNumeroRegistroEncontrados = 0;
            DataTable dt;
            try
            {

                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_APOSTILLA", objActuacion.NumeroApostilla, 255));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ACTUACION", objActuacion.CodigoActuacion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", objActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOCUMENTO", objActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA_APOSTILLA", objActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInputChar("@PV_OPERACION_BANCARIA", objActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", objActuacion.SituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", objActuacion.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodigoUbicacion));
                Add(PrimitiveParameter.CreateInput("@PC_SERIE", objActuacion.Serie, 50));

                DataRow dr = ExecuteDataRow("SAESS_TOTAL_REGISTRO_ACTUACION_CON_PDF", this._strCadenaConexion);
                if (!(Convert.IsDBNull(dr[0]))) pintNumeroRegistroEncontrados = Convert.ToInt32(dr[0]);


                return pintNumeroRegistroEncontrados;
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
        public DataTable ListarActuacionConPDFPaginado(EActuacion objActuacion, NullInt32 pintCodigoUbicacion, int intPaginaInicial, int pintNumRegistros)
        {

            DataTable dt;
            try
            {

                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_APOSTILLA", objActuacion.NumeroApostilla, 255));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ACTUACION", objActuacion.CodigoActuacion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", objActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_TIPO_DOCUMENTO", objActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA_APOSTILLA", objActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInputChar("@PV_OPERACION_BANCARIA", objActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", objActuacion.SituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", objActuacion.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodigoUbicacion));
                Add(PrimitiveParameter.CreateInput("@PI_PAGINA_ACTUAL", intPaginaInicial));
                Add(PrimitiveParameter.CreateInput("@PI_NUM_REGISTROS", pintNumRegistros));
                Add(PrimitiveParameter.CreateInput("@PC_SERIE", objActuacion.Serie, 50));


                dt = ExecuteDataTable("SAESS_LISTAR_ACTUACION_CON_PDF_PAGINADO", this._strCadenaConexion);

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
        public DataTable ListarSerieActuacionConPDF()
        {

            DataTable dt;
            try
            {

                Clear();
                dt = ExecuteDataTable("SAESS_LISTAR_SERIE_APOSTILLAS_CON_PDF", this._strCadenaConexion);

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

        public string InsertarActuacion(SqlTransaction pobjTx, EActuacion pobjActuacion)
        {
            try
            {
                Clear();

                
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", pobjActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_TIPO_DOCUMENTO", pobjActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PV_OPERACION_BANCARIA", pobjActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA", pobjActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjActuacion.UsuarioOficinaPerfilRegistro));
                Add(PrimitiveParameter.CreateOutputString("@PV_NUMERO_APOSTILLA", 255));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pobjActuacion.SituacionRegistro,1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_OFICINA", pobjActuacion.CodigoOficina));
                Add(PrimitiveParameter.CreateInput("@PV_SERIE", pobjActuacion.Serie,50));
                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_SERIE ", pobjActuacion.NumeroSerie,250));
                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_TICKET ", pobjActuacion.NumeroTicket, 50));
 
                ExecuteNonQuery("SAESI_INSERTAR_ACTUACION", pobjTx);
                return Convert.ToString(Out(6));
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarActuacion(SqlTransaction pobjTx, EActuacion pobjActuacion)
        {
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ACTUACION", pobjActuacion.CodigoActuacion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", pobjActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_TIPO_DOCUMENTO", pobjActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PV_OPERACION_BANCARIA", pobjActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA", pobjActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjActuacion.UsuarioOficinaPerfilModifica));
                Add(PrimitiveParameter.CreateInput("@PV_SERIE", pobjActuacion.Serie, 50));
                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_SERIE ", pobjActuacion.NumeroSerie, 250));
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE_ARCHIVO ", pobjActuacion.NombreDocumento, 255));


                ExecuteNonQuery("SAESU_ACTUALIZAR_ACTUACION", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarActuacion_X_Apostilla(SqlTransaction pobjTx, EActuacion pobjActuacion)
        {
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_APOSTILLA", pobjActuacion.NumeroApostilla,255));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjActuacion.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", pobjActuacion.CodigoFirmante));
                Add(PrimitiveParameter.CreateInput("@PI_TIPO_DOCUMENTO", pobjActuacion.CodigoTipoDocumento));
                Add(PrimitiveParameter.CreateInput("@PV_OPERACION_BANCARIA", pobjActuacion.OperacionBancaria, 255));
                Add(PrimitiveParameter.CreateInput("@PD_FECHA", pobjActuacion.FechaApostilla));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjActuacion.UsuarioOficinaPerfilModifica));
                Add(PrimitiveParameter.CreateInput("@PV_SERIE", pobjActuacion.Serie, 50));
                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_SERIE ", pobjActuacion.NumeroSerie, 250));
                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_TICKET ", pobjActuacion.NumeroTicket, 50));

                ExecuteNonQuery("SAESU_ACTUALIZAR_ACTUACION_X_APOSTILLA", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarSituacion(SqlTransaction pobjTx, Int32 pintCodigoActuacion, string pstrSituacion, Int32 pintAuditoria)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLA", pintCodigoActuacion));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", pstrSituacion, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_AUDITORIA", pintAuditoria));
                ExecuteNonQuery("SAESU_ACTUALIZAR_SITUACION", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarNombreArchivoApostilla(SqlTransaction pobjTx, string psrtNumeroApostilla, string pstrNombreArchivo, string pstrSituacion, string pstrSerie, string pstrNumeroSerie)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_APOSTILLA", psrtNumeroApostilla,255));
                Add(PrimitiveParameter.CreateInputChar("@PV_NOMBRE_ARCHIVO", pstrNombreArchivo,255));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", pstrSituacion, 1));
                Add(PrimitiveParameter.CreateInputChar("@PV_SERIE", pstrSerie, 50));
                Add(PrimitiveParameter.CreateInputChar("@PV_NUMERO_SERIE", pstrNumeroSerie, 250));
                ExecuteNonQuery("SAESU_ACTUALIZAR_NOMBRE_ARCHIVO_APOSTILLA", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarActuacion(SqlTransaction pobjTx, int pintCodigo)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_Actuacion", pintCodigo));

                ExecuteNonQuery("SAESD_ELIMINAR_Actuacion", pobjTx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarActuacionXnumeroApostilla(SqlTransaction pobjTx, string pstrNumeroApostilla)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PV_NUMERO_APOSTILLA", pstrNumeroApostilla,255));

                ExecuteNonQuery("SAESD_ELIMINAR_ACTUACION_X_APOSTILLA", pobjTx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        
        #endregion
    }
}