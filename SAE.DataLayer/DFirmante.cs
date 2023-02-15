//--------------------------------------------------------------------------------
//  
//
// Archivo     : DFirmante.cs
// Descripción : Lógica de negocio de Firmantes.
// Empresa     : MRE
// Autor       : Daniel Balvis
// Modificado  : 
//--------------------------------------------------------------------------------
 
using SAE.EntityLayer;
using SAE.Nullables;
using System;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

namespace SAE.DataLayer
{
    public interface IDFirmante
    {
        void Constructor(string pstrCadenaConexion);



        DataTable ListarFirmantes(EFirmante objFirmante);
        DataTable ListarFirmantes_X_Proceso(Int32 pintCodigoProceso);
        DataTable ListarFirmantes_X_Proceso_Region_Partido(Int32 pintCodigoProceso, Int32 pintCodigoRegion, Int32 pintCodigoPartido);
        DataTable ListarFirmantes_X_Proceso_Encuesta_Pendiente(Int32 pintCodigoProceso);

        void InsertarFirmante(SqlTransaction pobjTx, EFirmante pobjFirmante);
        void ModificarFirmante(SqlTransaction pobjTx, EFirmante pobjFirmante);
        void EliminarFirmante(SqlTransaction pobjTx, int pintCodigo);



    }

    public class DFirmante : PrimitiveEntity, IDFirmante
    {
        private string _strCadenaConexion;
        public DFirmante() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No TranSAEcionales

        public DataTable ListarFirmantes_X_Proceso_Region_Partido(Int32 pintCodigoProceso, Int32 pintCodigoRegion, Int32 pintCodigoPartido)
        {

            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PROCESO", pintCodigoProceso));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_REGION", pintCodigoRegion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PARTIDO", pintCodigoPartido));

                dt = ExecuteDataTable("SETSS_LISTAR_FIRMANTE_X_REGION_Y_PARTIDO", this._strCadenaConexion);

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
        public DataTable ListarFirmantes_X_Proceso_Encuesta_Pendiente(Int32 pintCodigoProceso)
        {
            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PROCESO", pintCodigoProceso));

                dt = ExecuteDataTable("SETSS_LISTAR_FIRMANTE_X_PROCESO_ENCUESTA_PENDIENTE", this._strCadenaConexion);

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
        public DataTable ListarFirmantes_X_Proceso(Int32 pintIdProceso)
        {

            DataTable dt;
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PROCESO", pintIdProceso));

                dt = ExecuteDataTable("SETSS_LISTAR_FIRMANTE_X_PROCESO", this._strCadenaConexion);

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
       
        public DataTable ListarFirmantes(EFirmante objFirmante)
        {

            DataTable dt;
            try
            {

                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", objFirmante.CodigoFirmante));
                Add(PrimitiveParameter.CreateInputChar("@PV_NOMBRE", objFirmante.Nombres, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_PATERNO", objFirmante.Paterno, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_MATERNO", objFirmante.Materno, 255));
                Add(PrimitiveParameter.CreateInput("@PI_DNI", objFirmante.Dni));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_CARGO", objFirmante.CodigoCargo));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ENTIDAD", objFirmante.CodigoEntidad));


                dt = ExecuteDataTable("SAESS_LISTAR_FIRMANTE", this._strCadenaConexion);

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

        public void InsertarFirmante(SqlTransaction pobjTx, EFirmante pobjFirmante)
        {
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInputChar("@PV_VNOMBRE", pobjFirmante.Nombres, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_VPATERNO", pobjFirmante.Paterno, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_VMATERNO", pobjFirmante.Materno, 255));
                Add(PrimitiveParameter.CreateInput("@PI_IDNI", pobjFirmante.Dni));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_CARGO", pobjFirmante.CodigoCargo));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ENTIDAD", pobjFirmante.CodigoEntidad));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjFirmante.UsuarioRegistro));
                ExecuteNonQuery("SAESI_INSERTAR_FIRMANTE", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarFirmante(SqlTransaction pobjTx, EFirmante pobjFirmante)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", pobjFirmante.CodigoFirmante));
                Add(PrimitiveParameter.CreateInputChar("@PV_VNOMBRE", pobjFirmante.Nombres, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_VPATERNO", pobjFirmante.Paterno, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_VMATERNO", pobjFirmante.Materno, 255));
                Add(PrimitiveParameter.CreateInput("@PI_IDNI", pobjFirmante.Dni));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_CARGO", pobjFirmante.CodigoCargo));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_ENTIDAD", pobjFirmante.CodigoEntidad));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjFirmante.UsuarioModifica));

                ExecuteNonQuery("SAESU_ACTUALIZAR_FIRMANTE", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void EliminarFirmante(SqlTransaction pobjTx, int pintCodigo)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_FIRMANTE", pintCodigo));

                ExecuteNonQuery("SAESD_ELIMINAR_FIRMANTE", pobjTx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}