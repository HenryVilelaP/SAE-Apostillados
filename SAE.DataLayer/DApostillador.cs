//--------------------------------------------------------------------------------
//  
//
// Archivo     : DApostillador.cs
// Descripción : Lógica de negocio de Apostilladors.
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
    public interface IDApostillador
    {
        void Constructor(string pstrCadenaConexion);



        DataTable ListarApostilladores(EApostillador objApostillador, NullInt32 pintOficina);
        byte[] VerFirma(int pintCodigoApostillador  );
       

        void InsertarApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador);
        void ModificarApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador);
        void EliminarApostillador(SqlTransaction pobjTx, int pintCodigo);
        void ModificarSituacionApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador);
        void ActualizarFirmaApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador);

    }

    public class DApostillador : PrimitiveEntity, IDApostillador
    {
        private string _strCadenaConexion;

        public DApostillador() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No TranSAEcionales


        public byte[] VerFirma(int pintCodigoApostillador)
        {
            DataRow dr = null;
            byte[] bfirma = null;
            try
            {

                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pintCodigoApostillador));
                
                dr=ExecuteDataRow ("SAESS_VER_FIRMA", this._strCadenaConexion);

                if (!(Convert.IsDBNull(dr["FIRMA"])))
                {
                    bfirma = (byte[])dr["FIRMA"];
                }
                
                 return bfirma;
            }
            catch (Exception ex)
            {
                throw ex;
            }
           
        }
        public DataTable ListarApostilladores(EApostillador objApostillador, NullInt32  pintOficina)
        {

            DataTable dt;
            try
            {
 
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", objApostillador.CodigoApostillador));
                Add(PrimitiveParameter.CreateInputChar("@PV_NOMBRE", objApostillador.Nombres, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_PATERNO", objApostillador.Paterno, 255));
                Add(PrimitiveParameter.CreateInputChar("@PV_MATERNO", objApostillador.Materno, 255));
                Add(PrimitiveParameter.CreateInput("@PI_DNI", objApostillador.Dni));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_CARGO", objApostillador.CodigoCargo));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", objApostillador.SituacionRegistro,1));
                Add(PrimitiveParameter.CreateInput("@PI_ICODIGO_OFICINA", pintOficina));
                
                

                dt = ExecuteDataTable("SAESS_LISTAR_APOSTILLADOR", this._strCadenaConexion);

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

        public void InsertarApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjApostillador.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjApostillador.UsuarioRegistro));
                ExecuteNonQuery("SAESI_INSERTAR_APOSTILLADOR", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ModificarApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjApostillador.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_CARGO", pobjApostillador.CodigoCargo));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjApostillador.UsuarioOficinaPerfilModifica));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", pobjApostillador.SituacionRegistro,1));
                Add(PrimitiveParameter.CreateInput("@PV_NOMBRE_ARCHIVO_FIRMA", pobjApostillador.NombreArchivoFirma,50));

                ExecuteNonQuery("SAESU_ACTUALIZAR_APOSTILLADOR", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ActualizarFirmaApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjApostillador.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_FIRMA", pobjApostillador.Firma, 8000));
                ExecuteNonQuery("SAESU_ACTUALIZAR_FIRMA_APOSTILLADOR", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
          public void ModificarSituacionApostillador(SqlTransaction pobjTx, EApostillador pobjApostillador)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_APOSTILLADOR", pobjApostillador.CodigoApostillador));
                Add(PrimitiveParameter.CreateInput("@PI_AUDITORIA", pobjApostillador.UsuarioModifica));
                Add(PrimitiveParameter.CreateInputChar("@PC_SITUACION", pobjApostillador.SituacionRegistro,1));
                ExecuteNonQuery("SAESU_ACTUALIZAR_SITUACION_APOSTILLADOR", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void EliminarApostillador(SqlTransaction pobjTx, int pintCodigo)
        {
            try
            {
                Clear();
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_Apostillador", pintCodigo));

                ExecuteNonQuery("SAESD_ELIMINAR_APOSTILLADOR", pobjTx);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}