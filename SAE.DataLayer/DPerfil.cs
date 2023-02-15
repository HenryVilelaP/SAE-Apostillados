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
    public interface IDPerfil
    {
        void Constructor(string pstrCadenaConexion);
        void Eliminar(SqlTransaction pobjTx, Int32 pi_codigo);
        IEPerfilCollection ListarPerfil(NullInt32 pintCodigoPerfil);
        IEPerfilCollection ListarPerfil(NullInt32 pintCodigoUbicacion, NullInt32 pintCodigoUnidad, NullString pstrSituacionRegistro, NullInt32 pintCodigoModulo);
        NullString Insertar(SqlTransaction pobjTx, IEPerfil pobjPerfil);
        NullString Actualizar(SqlTransaction pobjTx, IEPerfil pobjPerfil);

    }

    public class DPerfil : PrimitiveEntity, IDPerfil
    {
        private string _strCadenaConexion;
        public DPerfil() { }

        public void Constructor(string pstrCadenaConexion)
        {
            this._strCadenaConexion = pstrCadenaConexion;
        }

        #region Métodos No Transaccionales



        public IEPerfilCollection ListarPerfil(NullInt32 pintCodigoPerfil)
        {
            IEPerfilCollection collection = new EPerfilCollection();
            DataTable dt;
            try
            {
                Clear();

                 Add(PrimitiveParameter.CreateInput("@PI_CODIGO_PERFIL", pintCodigoPerfil));

                 dt = ExecuteDataTable("SAESS_LISTAR_PERFIL", this._strCadenaConexion);

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

        public IEPerfilCollection ListarPerfil(NullInt32 pintCodigoUbicacion,NullInt32 pintCodigoUnidad,NullString pstrSituacionRegistro,NullInt32 pintCodigoModulo)
        {
            IEPerfilCollection collection = new EPerfilCollection();
            DataTable dt;
            try
            {
                Clear();

                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UBICACION", pintCodigoUbicacion));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_UNIDAD", pintCodigoUnidad));
                Add(PrimitiveParameter.CreateInput("@PC_SITUACION", pstrSituacionRegistro, 1));
                Add(PrimitiveParameter.CreateInput("@PI_CODIGO_MODULO", pintCodigoModulo ));
                

                dt = ExecuteDataTable("SAESS_LISTAR_PERFIL_X_UBICACION", this._strCadenaConexion);

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
        public NullString Insertar(SqlTransaction pobjTx, IEPerfil pobjPerfil)
        {
            try
            {
                Clear();

                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Perfil", pobjPerfil.NombrePerfil , 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjPerfil.DescripcionPerfil , 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjPerfil.DiferenciaHoraria , 1));


                return NullString.Create(ExecuteNonQuery("INSERTAR_Perfil", pobjTx).ToString());

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public NullString Actualizar(SqlTransaction pobjTx, IEPerfil pobjPerfil)
        {
            try
            {
                Clear();
                //Add(PrimitiveParameter.CreateInput("@pi_codigo", pobjPerfil.CodigoPerfil.Value ));
                //Add(PrimitiveParameter.CreateInput("@pv_nombre_Perfil", pobjPerfil.NombrePerfil, 100));
                //Add(PrimitiveParameter.CreateInput("@pv_descripcion", pobjPerfil.DescripcionPerfil, 250));
                //Add(PrimitiveParameter.CreateInput("@pc_diferencia_horaria", pobjPerfil.DiferenciaHoraria, 1));


                return NullString.Create(ExecuteNonQuery("ACTUALIZAR_Perfil", pobjTx).ToString());

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
                Clear();

                Add(PrimitiveParameter.CreateInput("@pi_codigo", pi_codigo));
                ExecuteNonQuery("eliminar", pobjTx);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}



